using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace CCC.UI.Controllers
{
    public class ReportController : Controller
    {
        public async Task<ActionResult> ManageVetReport()
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            SearchPetData obj = new SearchPetData();

            var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var CityAreaMasterAPI = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            ViewBag.lstMonth = GetAllMonths();
            ViewBag.lstYears = GetAllYears();

            var centerRes = await CenterMasterAPI.GetAllCenters();
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            return View(obj);

        }

        private SelectList GetAllYears()
        {
            List<SelectListItem> objData = new List<SelectListItem>();
            for (int i = 2015; i <= 2030; i++)
            {
                objData.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return new SelectList(objData, "Value", "Text", null);
        }

        private SelectList GetAllMonths()
        {

            List<SelectListItem> objData = new List<SelectListItem>();
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            for (int i = 1; i < 13; i++)
            {
                objData.Add(new SelectListItem { Text = info.GetMonthName(i), Value = i.ToString() });
            }
            return new SelectList(objData, "Value", "Text", null);
        }

        [HttpPost("/Report/FillTableVetReportAsync")]
        public async Task<IActionResult> FillTableVetReportAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
        {
            var objSessionUSer = HttpContext.Session.GetSessionUser();

            List<ColumnNameValue> colList = new List<ColumnNameValue>();
            ColumnNameValue columns = new ColumnNameValue();

            int iPageSize;
            string sortdir = " asc ";
            int TotalCount = 0;

            if (dt.Length <= 0)
                iPageSize = 10;
            else
                iPageSize = dt.Length;

            if (dt.SortDirection.Equals(Column.OrderDirection.Ascendant))
                sortdir = " asc ";
            else
                sortdir = " desc ";

            SearchPetData searchObj = new SearchPetData();
            //searchObj. = objSessionUSer.UserId;
            //if (Active == "1")
            //    searchObj.Status = true;

            if (!string.IsNullOrEmpty(dt.SortColumnName))
                searchObj.SortExp = dt.SortColumnName + " " + sortdir;

            searchObj.PageSize = iPageSize;

            if (dt.PageIndex == 0)
                searchObj.PageIndex = 1;
            else
                searchObj.PageIndex = dt.PageIndex;

            foreach (var col in dt.Columns)
            {
                columns = new ColumnNameValue();
                if (!string.IsNullOrEmpty(col.Search.Value))
                {
                    columns.ColName = col.Name;
                    columns.ColValue = col.Search.Value;
                    colList.Add(columns);
                    switch (col.Name)
                    {
                        case "CenterId":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.CenterId = col.Search.Value.Trim();
                            }
                            break;

                        case "AreaId":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.AreaId = col.Search.Value.Trim();
                            }
                            break;
                        case "AdmissionDateFrom":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.AdmissionDateFrom = Convert.ToDateTime(col.Search.Value);
                            }
                            break;
                        case "AdmissionDateTo":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.AdmissionDateTo = Convert.ToDateTime(col.Search.Value);
                            }
                            break;
                        case "SurgeryDateFrom":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.SurgeryDateFrom = Convert.ToDateTime(col.Search.Value);
                            }
                            break;
                        case "SurgeryDateTo":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.SurgeryDateTo = Convert.ToDateTime(col.Search.Value);
                            }
                            break;
                        case "ReleaseDateFrom":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.ReleaseDateFrom = Convert.ToDateTime(col.Search.Value);
                            }
                            break;
                        case "ReleaseDateTo":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.ReleaseDateTo = Convert.ToDateTime(col.Search.Value.Trim());
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await PetServiceAPI.GetVetReport(searchObj);
            var response = apiResponse.Content;

            var lst = response;

            var lst1 = lst?.ToList();

            if (lst1 != null && lst1.Count > 0)
            {
                TotalCount = lst1[0].TotalCount;
            }
            bool set = false;
            if (searchObj.PageIndex > 1 && TotalCount == 0)
                set = true;
            return Json(new DataTablesResponse(dt.Draw, lst1, TotalCount, TotalCount, colList, set));
        }

        //[HttpPost]
        public async Task<IActionResult> ExportVetReport(string CenterId, string selectedMonth, string selectedYear)
        {
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            SearchPetData searchObj = new SearchPetData();
            searchObj.CenterId = CenterId;
            //searchObj.SurgeryDateFrom = SurgeryDateFrom;
            //searchObj.SurgeryDateTo = SurgeryDateTo;
            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await PetServiceAPI.GetVetReport(searchObj);
            var response = apiResponse.Content;

            FileInfo newFile = new FileInfo("D:\\Shahen-WorkFront\\sample1.xlsx");
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("VetReport");

            int rowCnt = 1;
            int colCnt = 1;
            int days = DateTime.DaysInMonth(Convert.ToInt32(selectedYear), Convert.ToInt32(selectedMonth));

            DesignCalenderTableHeader(days, workSheet, rowCnt, colCnt);

            #region -- Assign unique color for every Vet --
            List<string> lstVetNames = response.Select(x => x.VetName).Distinct().ToList();
            Random rnd = new Random();
            Byte[] b = new Byte[3];

            Dictionary<string, Color> lstVetColor = new Dictionary<string, Color>();
            foreach (var item in lstVetNames)
            {
                rnd.NextBytes(b);
                Color color = Color.FromArgb(255, b[0], b[1], b[2]);
                lstVetColor.Add(item, color);
            }
            #endregion

            rowCnt = rowCnt + 2;
            int petTotal = 0, m_DogTotal = 0, f_DogTotal = 0, m_CatTotal = 0, f_CatTotal = 0;

            for (int i = 1; i <= days; i++)
            {
                rowCnt = rowCnt + 1;
                colCnt = 1;
                string date = selectedMonth + '/' + i.ToString() + '/' + selectedYear;
                DateTime sDate = DateTime.Parse(date);
                int totalSurgeryCountOnDay = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date).ToList().Count;
                string centerName = response.Select(x => x.CenterName).FirstOrDefault();

                workSheet.Cells[rowCnt, colCnt].Value = GetDaywithSuffix(sDate.Day);
                workSheet.Cells[rowCnt, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt + 1].Value = centerName;
                workSheet.Cells[rowCnt, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

                if (totalSurgeryCountOnDay > 0)
                {
                    string drName = response.Where(x => x.SurgeryDate == sDate).Select(x => x.VetName).FirstOrDefault();
                    Color specialVetColor = lstVetColor.Where(x => x.Key.Trim().ToLower() == drName.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

                    int optDogsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                    int optDogsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                    int optCatsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                    int optCatsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                    m_DogTotal = m_DogTotal + optDogsCount_m;
                    f_DogTotal = f_DogTotal + optDogsCount_f;

                    m_CatTotal = m_CatTotal + optCatsCount_m;
                    f_CatTotal = f_CatTotal + optCatsCount_f;

                    int totalOpt = optDogsCount_m + optDogsCount_f + optCatsCount_m + optCatsCount_f;
                    petTotal = petTotal + totalOpt;

                    DesignVetCell(workSheet, drName, rowCnt, colCnt + 2, specialVetColor);
                    DesignVetCell(workSheet, optDogsCount_m, rowCnt, colCnt + 3, specialVetColor);
                    DesignVetCell(workSheet, optDogsCount_f, rowCnt, colCnt + 4, specialVetColor);
                    DesignVetCell(workSheet, optCatsCount_m, rowCnt, colCnt + 5, specialVetColor);
                    DesignVetCell(workSheet, optCatsCount_f, rowCnt, colCnt + 6, specialVetColor);
                    DesignVetCell(workSheet, "", rowCnt, colCnt + 7, specialVetColor);

                    //workSheet.Cells[rowCnt, colCnt + 2].Value = drName;
                    //workSheet.Cells[rowCnt, colCnt + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 2].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 2].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    //workSheet.Cells[rowCnt, colCnt + 3].Value = optDogsCount_m;
                    //workSheet.Cells[rowCnt, colCnt + 3].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 3].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 3].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    //workSheet.Cells[rowCnt, colCnt + 4].Value = optDogsCount_f;
                    //workSheet.Cells[rowCnt, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 4].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 4].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    //workSheet.Cells[rowCnt, colCnt + 5].Value = optCatsCount_m;
                    //workSheet.Cells[rowCnt, colCnt + 5].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 5].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 5].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    //workSheet.Cells[rowCnt, colCnt + 6].Value = optCatsCount_f;
                    //workSheet.Cells[rowCnt, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 6].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 6].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    //workSheet.Cells[rowCnt, colCnt + 7].Value = "";
                    //workSheet.Cells[rowCnt, colCnt + 7].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    //workSheet.Cells[rowCnt, colCnt + 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    //workSheet.Cells[rowCnt, colCnt + 7].Style.Font.Color.SetColor(specialVetColor);
                    //workSheet.Cells[rowCnt, colCnt + 7].Style.Font.Bold = true;
                    //workSheet.Cells[rowCnt, colCnt + 7].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));

                    workSheet.Cells[rowCnt, colCnt + 8].Value = totalOpt;
                    workSheet.Cells[rowCnt, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                    workSheet.Cells[rowCnt, colCnt + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[rowCnt, colCnt + 8].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                    workSheet.Cells[rowCnt, colCnt + 8].Style.Fill.BackgroundColor.SetColor(specialVetColor);
                    workSheet.Cells[rowCnt, colCnt + 8].Style.Font.Bold = true;

                }
                else
                {
                    //no surgery
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Value = "No Ops";
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Merge = true;
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 0, 0));

                    workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                }
            }

            DesignCalenderTableTotal(workSheet, rowCnt, colCnt, m_DogTotal, f_DogTotal, m_CatTotal, f_CatTotal, petTotal);
            var exportbytes = excel.GetAsByteArray();
            return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", newFile.Name);

        }

        private void DesignVetCell(ExcelWorksheet workSheet, dynamic val, int rowCnt, int colCnt, Color specialVetColor)
        {
            workSheet.Cells[rowCnt, colCnt].Value = val;
            workSheet.Cells[rowCnt, colCnt].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(specialVetColor);
            workSheet.Cells[rowCnt, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt, colCnt].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        }

        private void DesignCalenderTableTotal(ExcelWorksheet workSheet, int rowCnt, int colCnt, int m_DogTotal, int f_DogTotal, int m_CatTotal, int f_CatTotal, int petTotal)
        {
            workSheet.Cells[rowCnt + 1, colCnt + 3].Value = m_DogTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Fill.BackgroundColor.SetColor(Color.Chocolate);

            workSheet.Cells[rowCnt + 1, colCnt + 4].Value = f_DogTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Fill.BackgroundColor.SetColor(Color.Chocolate);

            workSheet.Cells[rowCnt + 1, colCnt + 5].Value = m_CatTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Fill.BackgroundColor.SetColor(Color.Chocolate);

            workSheet.Cells[rowCnt + 1, colCnt + 6].Value = f_CatTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Fill.BackgroundColor.SetColor(Color.Chocolate);

            workSheet.Cells[rowCnt + 1, colCnt + 8].Value = petTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Fill.BackgroundColor.SetColor(Color.Chocolate);
        }

        private void DesignCalenderTableHeader(int days, ExcelWorksheet workSheet, int rowCnt, int colCnt)
        {
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2 + days, colCnt + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2 + days, colCnt + 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            workSheet.Cells[rowCnt, colCnt].Value = "Date";
            workSheet.Cells[rowCnt, colCnt].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 1].Value = "Venue";
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt, colCnt + 2].Value = "Vet";
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 3].Value = "Dogs";
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt + 1, colCnt + 3].Value = "Male";
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 2, colCnt + 3].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 2, colCnt + 3].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt + 1, colCnt + 4].Value = "Female";
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 4, rowCnt + 2, colCnt + 4].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 4, rowCnt + 2, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 5].Value = "Cats";
            workSheet.Cells[rowCnt, colCnt + 5].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 5, rowCnt, colCnt + 6].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 5, rowCnt, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt + 1, colCnt + 5].Value = "Male";
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 2, colCnt + 5].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 2, colCnt + 5].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt + 1, colCnt + 6].Value = "Female";
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 6, rowCnt + 2, colCnt + 6].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 6, rowCnt + 2, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt, colCnt + 7].Value = "Deaths/Notes";
            workSheet.Cells[rowCnt, colCnt + 7].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 7, rowCnt + 2, colCnt + 7].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 7, rowCnt + 2, colCnt + 7].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);


            workSheet.Cells[rowCnt, colCnt + 8].Value = "Total";
            workSheet.Cells[rowCnt, colCnt + 8].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt + 8, rowCnt + 2, colCnt + 8].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 8, rowCnt + 2, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
        }

        private string GetDaywithSuffix(int Day)
        {
            string suffixDay;

            if (new[] { 11, 12, 13 }.Contains(Day))
            {
                suffixDay = Day + "th";
            }
            else if (Day % 10 == 1)
            {
                suffixDay = Day + "st";
            }
            else if (Day % 10 == 2)
            {
                suffixDay = Day + "nd";
            }
            else if (Day % 10 == 3)
            {
                suffixDay = Day + "rd";
            }
            else
            {
                suffixDay = Day + "th";
            }
            return suffixDay;
        }
    }
}
