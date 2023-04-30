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
using System.Text;
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

            ViewBag.lstMonth = GetAllMonths();
            ViewBag.lstYears = GetAllYears();

            var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            return View(obj);

        }

        #region -- Vet Report Stuff --

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
                        case "Month":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.Month = col.Search.Value.Trim();
                            }
                            break;
                        case "Year":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.Year = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            if (string.IsNullOrEmpty(searchObj.Month)) { searchObj.Month = DateTime.Now.Month.ToString(); }
            if (string.IsNullOrEmpty(searchObj.Year)) { searchObj.Year = DateTime.Now.Year.ToString(); }

            int days = DateTime.DaysInMonth(Convert.ToInt32(searchObj.Year), Convert.ToInt32(searchObj.Month));
            string firstDate = searchObj.Month + "/1/" + searchObj.Year;
            DateTime firstDayOfMonth = DateTime.Parse(firstDate);
            string lastDate = searchObj.Month + '/' + days.ToString() + '/' + searchObj.Year;
            DateTime lastDayOfMonth = DateTime.Parse(lastDate);
            searchObj.SurgeryDateFrom = firstDayOfMonth;
            searchObj.SurgeryDateTo = lastDayOfMonth;

            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await PetServiceAPI.GetCenterReportData(searchObj);
            var response = apiResponse.Content;

            var lst = response;

            var lst1 = lst?.ToList();
            var newList = new List<GetAllPetDataResponse>();
            if (lst1 != null && lst1.Count > 0)
            {
                var lstTotalVet = lst1.Select(x => x.VetId).Distinct().ToList();
                if (lstTotalVet.Count > 0)
                {
                    foreach (var vet in lstTotalVet)
                    {
                        GetAllPetDataResponse data = new GetAllPetDataResponse();
                        data.VetName = lst1.Where(x => x.VetId == vet).Select(x => x.VetName).FirstOrDefault();
                        //data.totalSurgeryCount = lst1.Where(x => x.VetId == vet && x.SurgeryDate != null).ToList().Count;

                        data.totalSurgeryCount = lst1.Where(x => x.VetId == vet && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        data.totalComplicationCount = lst1.Where(x => x.VetId == vet && x.IsOnHold == false && x.ExpiredDate == null &&
                         (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        decimal complication = Convert.ToDecimal(data.totalComplicationCount) / Convert.ToDecimal(data.totalSurgeryCount);
                        data.complicationPercentage = Convert.ToDecimal(complication * 100);


                        data.totalDeathCount = lst1.Where(x => x.VetId == vet && x.ExpiredDate != null).ToList().Count;
                        newList.Add(data);
                    }
                }
                TotalCount = newList.Count;
            }
            bool set = false;
            if (searchObj.PageIndex > 1 && TotalCount == 0)
                set = true;
            return Json(new DataTablesResponse(dt.Draw, newList, TotalCount, TotalCount, colList, set));
        }

        //[HttpPost]

        public async Task<IActionResult> ExportVetReport(string CenterId, string selectedMonth, string selectedYear)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            int days = DateTime.DaysInMonth(Convert.ToInt32(selectedYear), Convert.ToInt32(selectedMonth));

            string firstDate = selectedMonth + "/1/" + selectedYear;
            DateTime firstDayOfMonth = DateTime.Parse(firstDate);

            string lastDate = selectedMonth + '/' + days.ToString() + '/' + selectedYear;
            DateTime lastDayOfMonth = DateTime.Parse(lastDate);


            string monthName = firstDayOfMonth.Date.ToString("MMM");
            FileInfo newFile = new FileInfo("D:\\Shahen-WorkFront\\VetReport_" + monthName + "_" + selectedYear + "_.xlsx");
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Vet Report");


            var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            string selectedCenters = string.Empty;
            if (string.IsNullOrEmpty(CenterId)) { selectedCenters = objSessionUser.UserCenters; }
            else { selectedCenters = CenterId; }

            SearchPetData searchObj = new SearchPetData();
            searchObj.CenterId = selectedCenters;
            searchObj.AdmissionDateFrom = firstDayOfMonth;
            searchObj.AdmissionDateTo = lastDayOfMonth;

            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var apiResponse = await PetServiceAPI.GetCenterReportData(searchObj);
            var response = apiResponse.Content;

            var lstCenters = response.Select(x => x.CenterId).Distinct().ToList();

            int rowCnt = 1;
            int colCnt = 1;


            DesignVetReportTableHeader(workSheet, rowCnt, colCnt);

            rowCnt = 3;
            foreach (var cen in lstCenters)
            {
                rowCnt = rowCnt + 1; colCnt = 1;
                string centerName = response.Where(x => x.CenterId == cen).Select(x => x.CenterName).FirstOrDefault();
                var lstCenterManagers = response.Where(x => x.CenterId == cen).Select(s => s.CreatedBy).Distinct().ToList();
                int totalMgrCount = lstCenterManagers.Count;

                int totalvetCountByCenter = 0;// response.Where(x => x.CenterId == cen).Select(x => x.VetId).Distinct().ToList().Count;

                foreach (var mgr in lstCenterManagers)
                {
                    int vetcnt = response.Where(x => x.CenterId == cen && x.CreatedBy == mgr).Select(x => x.VetId).Distinct().ToList().Count;
                    totalvetCountByCenter += vetcnt;
                }

                //var totalvetByCenter = response.Where(x => x.CenterId == cen).Select(x => x.VetId).Distinct().ToList();
                //int vetCount = totalvetByCenter.Count;

                workSheet.Cells[rowCnt, colCnt].Value = centerName;
                if (totalMgrCount > 1)
                {
                    workSheet.Cells[rowCnt, colCnt, rowCnt + (totalMgrCount - 1), colCnt].Merge = true;
                }

                int mgrcount = 0;
                int d_Complication_FinalTotal = 0;
                int d_Sterilised_FinalTotal = 0;
                int c_Complication_FinalTotal = 0;
                int c_Sterilised_FinalTotal = 0;
                int totalvetCountByMgr = 0;
                foreach (var mgr in lstCenterManagers)
                {
                    mgrcount = mgrcount + 1;

                    if (mgrcount != 1)//first record
                    {
                        rowCnt = rowCnt + 1;
                    }
                    string mgrName = response.Where(x => x.CenterId == cen && x.CreatedBy == mgr).Select(x => x.CreatorName).FirstOrDefault();
                    workSheet.Cells[rowCnt, colCnt + 1].Value = mgrName;

                    var lstVets = response.Where(x => x.CreatedBy == mgr && x.CenterId == cen).Select(x => x.VetId).Distinct().ToList();
                    var totalVetCount = lstVets.Count;
                    if (totalVetCount > 1)
                    {
                        workSheet.Cells[rowCnt, colCnt + 1, rowCnt + (totalVetCount - 1), colCnt + 1].Merge = true;
                    }

                    int vetCount = 0;
                    foreach (var vet in lstVets)
                    {
                        vetCount = vetCount + 1;
                        totalvetCountByMgr = totalvetCountByMgr + 1;
                        if (vetCount != 1)//first record
                        {
                            rowCnt = rowCnt + 1;
                        }
                        string vetName = response.Where(x => x.CenterId == cen && x.CreatedBy == mgr && x.VetId == vet).Select(x => x.VetName).FirstOrDefault();
                        workSheet.Cells[rowCnt, colCnt + 2].Value = vetName;

                        var dogData = response.Where(x => x.CenterId == cen && x.CreatedBy == mgr && x.VetId == vet & x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG).ToList();
                        var catData = response.Where(x => x.CenterId == cen && x.CreatedBy == mgr && x.VetId == vet && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat).ToList();

                        //dog
                        //int d_complication_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && !string.IsNullOrEmpty(x.MedicalNoteId) && x.IsOnHold == false && x.ExpiredDate == null && x.SurgeryDate != null &&
                        // (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int d_complication_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && !string.IsNullOrEmpty(x.MedicalNoteId) && x.IsOnHold == false && x.ExpiredDate == null && x.SurgeryDate != null &&
                        // (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int d_complication_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int d_complication_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == false && x.ExpiredDate == null &&
                         (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int d_sterilised_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ReleaseDate != null && x.ExpiredDate == null &&
                        //(string.IsNullOrEmpty(x.MedicalNoteId) || x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int d_sterilised_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        //(string.IsNullOrEmpty(x.MedicalNoteId) || x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int d_sterilised_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int d_sterilised_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;


                        int d_OnHold_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true).ToList().Count;
                        int d_OnHold_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true).ToList().Count;
                        int d_Died_Male = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                        int d_Died_FeMale = dogData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;

                        //cats
                        //int c_complication_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && !string.IsNullOrEmpty(x.MedicalNoteId) && x.IsOnHold == false && x.ExpiredDate == null && x.SurgeryDate != null &&
                        // (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int c_complication_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && !string.IsNullOrEmpty(x.MedicalNoteId) && x.IsOnHold == false && x.ExpiredDate == null && x.SurgeryDate != null &&
                        // (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int c_sterilised_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        //(string.IsNullOrEmpty(x.MedicalNoteId) || x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        //int c_sterilised_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        //(string.IsNullOrEmpty(x.MedicalNoteId) || x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;


                        int c_complication_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == false && x.ExpiredDate == null &&
                         (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int c_complication_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == false && x.ExpiredDate == null &&
                         (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int c_sterilised_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;

                        int c_sterilised_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ReleaseDate != null && x.IsOnHold == false && x.ExpiredDate == null &&
                        (x.ReleaseDate.Value.Date <= x.AdmissionDate.Date.AddDays(7))).ToList().Count;


                        int c_OnHold_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true).ToList().Count;
                        int c_OnHold_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true).ToList().Count;
                        int c_Died_Male = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                        int c_Died_FeMale = catData.Where(x => x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;



                        workSheet.Cells[rowCnt, colCnt + 3].Value = d_complication_Male;
                        workSheet.Cells[rowCnt, colCnt + 4].Value = d_complication_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 5].Value = d_sterilised_Male;
                        workSheet.Cells[rowCnt, colCnt + 6].Value = d_sterilised_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 7].Value = d_Died_Male;
                        workSheet.Cells[rowCnt, colCnt + 8].Value = d_Died_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 9].Value = d_OnHold_Male;
                        workSheet.Cells[rowCnt, colCnt + 10].Value = d_OnHold_FeMale;

                        int d_Complication_total = d_complication_Male + d_complication_FeMale;
                        int d_Sterilised_total = d_sterilised_Male + d_sterilised_FeMale;

                        if (d_Sterilised_total == 0)
                        {
                            if (d_Complication_total == 0)
                            {
                                workSheet.Cells[rowCnt, colCnt + 11].Value = "00.00";
                            }
                            else
                            {
                                workSheet.Cells[rowCnt, colCnt + 11].Value = "100.00";
                            }
                        }
                        else
                        {
                            decimal vetCross = Convert.ToDecimal(d_Complication_total) / Convert.ToDecimal(d_Sterilised_total);
                            decimal d_ComplicationOfVet = Convert.ToDecimal(vetCross * 100);
                            workSheet.Cells[rowCnt, colCnt + 11].Value = Decimal.Round(d_ComplicationOfVet, 2);
                        }


                        d_Complication_FinalTotal += d_Complication_total;
                        d_Sterilised_FinalTotal += d_Sterilised_total;

                        if (totalvetCountByMgr == totalvetCountByCenter)
                        {
                            if (d_Sterilised_FinalTotal == 0)
                            {
                                if (d_Complication_total == 0)
                                {
                                    workSheet.Cells[rowCnt, colCnt + 12].Value = "00.00";
                                }
                                else
                                {
                                    workSheet.Cells[rowCnt, colCnt + 12].Value = "100.00";
                                }

                            }
                            else
                            {
                                decimal vetCrossFinal = Convert.ToDecimal(d_Complication_FinalTotal) / Convert.ToDecimal(d_Sterilised_FinalTotal);
                                decimal d_ComplicationOfCenter = Convert.ToDecimal(vetCrossFinal * 100);
                                workSheet.Cells[rowCnt, colCnt + 12].Value = Decimal.Round(d_ComplicationOfCenter, 2);
                            }
                        }
                        else
                        {
                            workSheet.Cells[rowCnt, colCnt + 12].Value = "";
                        }

                        workSheet.Cells[rowCnt, colCnt + 13].Value = c_complication_Male;
                        workSheet.Cells[rowCnt, colCnt + 14].Value = c_complication_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 15].Value = c_sterilised_Male;
                        workSheet.Cells[rowCnt, colCnt + 16].Value = c_sterilised_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 17].Value = c_Died_Male;
                        workSheet.Cells[rowCnt, colCnt + 18].Value = c_Died_FeMale;

                        workSheet.Cells[rowCnt, colCnt + 19].Value = c_OnHold_Male;
                        workSheet.Cells[rowCnt, colCnt + 20].Value = c_OnHold_FeMale;


                        int c_Complication_total = c_complication_Male + c_complication_FeMale;
                        int c_Sterilised_total = c_sterilised_Male + c_sterilised_FeMale;

                        if (c_Sterilised_total == 0)
                        {
                            if (c_Complication_total == 0)
                            {
                                workSheet.Cells[rowCnt, colCnt + 21].Value = "00.00";
                            }
                            else
                            {
                                workSheet.Cells[rowCnt, colCnt + 21].Value = "100.00";
                            }
                        }
                        else
                        {
                            decimal c_vetCross = Convert.ToDecimal(c_Complication_total) / Convert.ToDecimal(c_Sterilised_total);
                            decimal c_ComplicationOfVet = Convert.ToDecimal(c_vetCross * 100);
                            workSheet.Cells[rowCnt, colCnt + 21].Value = Decimal.Round(c_ComplicationOfVet);
                        }


                        c_Complication_FinalTotal += c_Complication_total;
                        c_Sterilised_FinalTotal += c_Sterilised_total;
                        if (totalvetCountByMgr == totalvetCountByCenter)
                        {
                            if (c_Sterilised_FinalTotal == 0)
                            {
                                if (c_Complication_FinalTotal == 0)
                                {
                                    workSheet.Cells[rowCnt, colCnt + 22].Value = "00.00";
                                }
                                else
                                {
                                    workSheet.Cells[rowCnt, colCnt + 22].Value = "100.00";
                                }
                            }
                            else
                            {
                                decimal c_vetCrossFinal = Convert.ToDecimal(c_Complication_FinalTotal) / Convert.ToDecimal(c_Sterilised_FinalTotal);
                                decimal c_ComplicationOfCenter = Convert.ToDecimal(c_vetCrossFinal * 100);
                                workSheet.Cells[rowCnt, colCnt + 22].Value = Decimal.Round(c_ComplicationOfCenter, 2);
                            }

                        }
                        else
                        {
                            workSheet.Cells[rowCnt, colCnt + 22].Value = "";
                        }

                        var FirstTableRange = workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 22];
                        workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 22].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        FirstTableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        FirstTableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        FirstTableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        FirstTableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    }
                }
            }

            var exportbytes = excel.GetAsByteArray();
            return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", newFile.Name);

            // return null;
        }

        private void DesignVetReportTableHeader(ExcelWorksheet workSheet, int rowCnt, int colCnt)
        {
            Color voiletBGColor = Color.FromArgb(76, 82, 112);
            Color greenBGColor = Color.FromArgb(18, 143, 139);
            Color blueBGColor = Color.FromArgb(83, 142, 213);

            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22].Style.Font.Bold = true;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));


            var FirstTableRange = workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 22];
            FirstTableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            FirstTableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            FirstTableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            FirstTableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            workSheet.Cells[rowCnt, colCnt].Value = "Center Name";
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt].Merge = true;

            workSheet.Cells[rowCnt, colCnt + 1].Value = "Center Manager";
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Merge = true;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 1].Style.Fill.BackgroundColor.SetColor(greenBGColor);

            workSheet.Cells[rowCnt, colCnt + 2].Value = "Vet Name";
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Merge = true;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt + 2].Style.Fill.BackgroundColor.SetColor(greenBGColor);

            workSheet.Cells[rowCnt, colCnt + 3].Value = "Dogs";
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 12].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 12].Style.Fill.BackgroundColor.SetColor(greenBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 3].Value = "Complications";
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 1, colCnt + 4].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 1, colCnt + 4].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 3].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 4].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 3, rowCnt + 2, colCnt + 4].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 5].Value = "Sterilised";
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 1, colCnt + 6].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 1, colCnt + 6].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 5].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 6].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 4, rowCnt + 2, colCnt + 6].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 7].Value = "Expired";
            workSheet.Cells[rowCnt + 1, colCnt + 7, rowCnt + 1, colCnt + 8].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 7, rowCnt + 1, colCnt + 8].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 7].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 8].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 7, rowCnt + 2, colCnt + 8].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 9].Value = "OnHold";
            workSheet.Cells[rowCnt + 1, colCnt + 9, rowCnt + 1, colCnt + 10].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 9, rowCnt + 1, colCnt + 10].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 9].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 10].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 9, rowCnt + 2, colCnt + 10].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 11].Value = "% of Complication of Vet";
            workSheet.Cells[rowCnt + 1, colCnt + 11].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 11].Value = "";
            workSheet.Cells[rowCnt + 2, colCnt + 11].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 12].Value = "% of Complication of Center";
            workSheet.Cells[rowCnt + 1, colCnt + 12].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 12].Value = "";
            workSheet.Cells[rowCnt + 2, colCnt + 12].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt, colCnt + 13].Value = "Cats";
            workSheet.Cells[rowCnt, colCnt + 13, rowCnt, colCnt + 22].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 13, rowCnt, colCnt + 22].Style.Fill.BackgroundColor.SetColor(greenBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 13].Value = "Complications";
            workSheet.Cells[rowCnt + 1, colCnt + 13, rowCnt + 1, colCnt + 14].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 13, rowCnt + 1, colCnt + 14].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 13].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 14].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 13, rowCnt + 2, colCnt + 14].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 15].Value = "Sterilised";
            workSheet.Cells[rowCnt + 1, colCnt + 15, rowCnt + 1, colCnt + 16].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 15, rowCnt + 1, colCnt + 16].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 15].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 16].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 15, rowCnt + 2, colCnt + 16].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 17].Value = "Expired";
            workSheet.Cells[rowCnt + 1, colCnt + 17, rowCnt + 1, colCnt + 18].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 17, rowCnt + 1, colCnt + 18].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 17].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 18].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 17, rowCnt + 2, colCnt + 18].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 19].Value = "OnHold";
            workSheet.Cells[rowCnt + 1, colCnt + 19, rowCnt + 1, colCnt + 20].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 19, rowCnt + 1, colCnt + 20].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 19].Value = "Male";
            workSheet.Cells[rowCnt + 2, colCnt + 20].Value = "Female";
            workSheet.Cells[rowCnt + 2, colCnt + 19, rowCnt + 2, colCnt + 20].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 21].Value = "% of Complication of Vet";
            workSheet.Cells[rowCnt + 1, colCnt + 21].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 1, colCnt + 22].Value = "% of Complication of Center";
            workSheet.Cells[rowCnt + 1, colCnt + 22].Style.Fill.BackgroundColor.SetColor(voiletBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 21].Value = "";
            workSheet.Cells[rowCnt + 2, colCnt + 21].Style.Fill.BackgroundColor.SetColor(blueBGColor);

            workSheet.Cells[rowCnt + 2, colCnt + 22].Value = "";
            workSheet.Cells[rowCnt + 2, colCnt + 22].Style.Fill.BackgroundColor.SetColor(blueBGColor);

        }

        #endregion



        #region -- Center Report Stuff --

        public async Task<ActionResult> ManageCenterReport()
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            SearchPetData obj = new SearchPetData();

            var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            ViewBag.lstMonth = GetAllMonths();
            ViewBag.lstYears = GetAllYears();

            var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            return View(obj);
        }

        public async Task<IActionResult> ExportCenterReport(string CenterId, string selectedMonth, string selectedYear)
        {
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            int days = DateTime.DaysInMonth(Convert.ToInt32(selectedYear), Convert.ToInt32(selectedMonth));

            string firstDate = selectedMonth + "/1/" + selectedYear;
            DateTime firstDayOfMonth = DateTime.Parse(firstDate);

            string lastDate = selectedMonth + '/' + days.ToString() + '/' + selectedYear;
            DateTime lastDayOfMonth = DateTime.Parse(lastDate);

            SearchPetData searchObj = new SearchPetData();
            searchObj.CenterId = CenterId;
            searchObj.SurgeryDateFrom = firstDayOfMonth;
            searchObj.SurgeryDateTo = lastDayOfMonth;
            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await PetServiceAPI.GetVetReport(searchObj); //Its actually center report we swap the name
            var response = apiResponse.Content;
            //if (response.Count == 0)
            //{
            //    return Ok(false);
            //}
            string monthName = firstDayOfMonth.Date.ToString("MMM");
            FileInfo newFile = new FileInfo("D:\\Shahen-WorkFront\\CenterReport_" + monthName + "_" + selectedYear + "_.xlsx");
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("CenterReport");

            int rowCnt = 1;
            int colCnt = 1;


            DesignCalenderTableHeader(days, workSheet, rowCnt, colCnt);

            #region -- Assign unique color for every Vet --
            List<string> lstVetNames = response.Select(x => x.VetName).Distinct().ToList();
            //Random rnd = new Random();
            //Byte[] b = new Byte[3];

            //Dictionary<string, Color> lstVetColor = new Dictionary<string, Color>();
            //foreach (var item in lstVetNames)
            //{
            //    rnd.NextBytes(b);
            //    Color color = Color.FromArgb(255, b[0], b[1], b[2]);
            //    lstVetColor.Add(item, color);
            //}
            #endregion

            string centerName = response.Select(x => x.CenterName).FirstOrDefault();
            rowCnt = rowCnt + 2;
            int petTotal = 0, m_DogTotal = 0, f_DogTotal = 0, m_CatTotal = 0, f_CatTotal = 0;

            for (int i = 1; i <= days; i++)
            {
                rowCnt = rowCnt + 1;
                colCnt = 1;
                string date = selectedMonth + '/' + i.ToString() + '/' + selectedYear;
                DateTime sDate = DateTime.Parse(date);
                int totalSurgeryCountOnDay = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date).ToList().Count;

                workSheet.Cells[rowCnt, colCnt].Value = GetDaywithSuffix(sDate.Day);
                workSheet.Cells[rowCnt, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt + 1].Value = centerName;
                workSheet.Cells[rowCnt, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

                if (totalSurgeryCountOnDay > 0)
                {
                    string drName = response.Where(x => x.SurgeryDate == sDate).Select(x => x.VetName).FirstOrDefault();
                    Color specialVetColor = Color.FromArgb(18, 143, 139); //lstVetColor.Where(x => x.Key.Trim().ToLower() == drName.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

                    int optDogsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                    int optDogsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                    int optCatsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                    int optCatsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                    int mCncDog = 0; int fCncDog = 0; int mCncCat = 0; int fCncCat = 0;
                    int mDeathDog = 0; int fDeathDog = 0; int mDeathCat = 0; int fDeathCat = 0;

                    mCncDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;
                    fCncDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;

                    mCncCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;
                    fCncCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;

                    mDeathDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                    fDeathDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;

                    mDeathCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                    fDeathCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConstants.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConstants.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;

                    StringBuilder sb = new StringBuilder();

                    if (mCncDog > 0 || mCncCat > 0) { sb.Append((mCncDog + mCncCat) + "m Canc +"); }
                    if (fCncDog > 0 || fCncCat > 0) { sb.Append((fCncDog + fCncCat) + "f Canc +"); }

                    if (mDeathDog > 0 || mDeathCat > 0) { sb.Append((mDeathDog + mDeathCat) + "m death +"); }
                    if (fDeathDog > 0 || fDeathCat > 0) { sb.Append((fDeathDog + fDeathCat) + "f death +"); }

                    m_DogTotal = m_DogTotal + optDogsCount_m;
                    f_DogTotal = f_DogTotal + optDogsCount_f;

                    m_CatTotal = m_CatTotal + optCatsCount_m;
                    f_CatTotal = f_CatTotal + optCatsCount_f;

                    int totalOpt = (optDogsCount_m + optDogsCount_f + optCatsCount_m + optCatsCount_f) - (mCncDog + mCncCat + fCncDog + fCncCat + mDeathDog + mDeathCat + fDeathDog + fDeathCat);
                    petTotal = petTotal + totalOpt;

                    string deathNotes = sb.ToString();
                    deathNotes = (!string.IsNullOrEmpty(deathNotes)) ? deathNotes.Remove(deathNotes.Length - 1, 1) : "";

                    DesignVetCell(workSheet, drName, rowCnt, colCnt + 2, specialVetColor);
                    DesignVetCell(workSheet, optDogsCount_m, rowCnt, colCnt + 3, specialVetColor);
                    DesignVetCell(workSheet, optDogsCount_f, rowCnt, colCnt + 4, specialVetColor);
                    DesignVetCell(workSheet, optCatsCount_m, rowCnt, colCnt + 5, specialVetColor);
                    DesignVetCell(workSheet, optCatsCount_f, rowCnt, colCnt + 6, specialVetColor);
                    DesignVetCell(workSheet, deathNotes, rowCnt, colCnt + 7, specialVetColor);

                    DesignVetTotalOperation(workSheet, totalOpt, rowCnt, colCnt + 8, specialVetColor, false);

                }
                else
                {
                    //no surgery
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Value = "No Ops";
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Merge = true;
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Font.Color.SetColor(Color.FromArgb(0, 0, 0));
                    workSheet.Cells[rowCnt, colCnt + 2, rowCnt, colCnt + 8].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(246, 253, 252));
                    workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                }
            }

            DesignCalenderTableTotal(workSheet, rowCnt, colCnt, m_DogTotal, f_DogTotal, m_CatTotal, f_CatTotal, petTotal);

            Color bgColor = Color.FromArgb(76, 82, 112);
            #region -- Vet Total Table --

            if (lstVetNames.Count > 0)
            {
                rowCnt = 1;
                colCnt = 11;
                int totalvets = lstVetNames.Count + 1;  //add 1 for total row
                string totalByCenter = "Total (@ " + centerName + ")";

                SetCellAlignment(workSheet, rowCnt, colCnt, rowCnt + totalvets, colCnt + 1);

                workSheet.Cells[rowCnt, colCnt].Value = totalByCenter;
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Merge = true;
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.BackgroundColor.SetColor(bgColor);

                int grandTotalByVet = 0;
                foreach (var item in lstVetNames)
                {
                    int vetOperatedCount = response.Where(x => x.VetName.Trim().ToLower() == item.Trim().ToLower()).ToList().Count;
                    int exCanCount = response.Where(x => x.VetName.Trim().ToLower() == item.Trim().ToLower() && (x.IsOnHold == true || x.ExpiredDate != null)).ToList().Count;
                    int opCountFinal = vetOperatedCount - exCanCount;
                    grandTotalByVet = (grandTotalByVet + opCountFinal);
                    Color specialVetColor = Color.FromArgb(18, 143, 139); //lstVetColor.Where(x => x.Key.Trim().ToLower() == item.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

                    DesignVetCell(workSheet, item, rowCnt + 1, colCnt, specialVetColor);
                    DesignVetTotalOperation(workSheet, opCountFinal, rowCnt + 1, colCnt + 1, specialVetColor, false);
                    rowCnt = rowCnt + 1;
                }
                rowCnt = rowCnt + 1;
                DesignVetTotalOperation(workSheet, totalByCenter, rowCnt, colCnt, new Color(), true);
                DesignVetTotalOperation(workSheet, grandTotalByVet, rowCnt, colCnt + 1, new Color(), true);
            }

            #endregion


            #region -- Dogs total(Dale/Female) --

            if (lstVetNames.Count > 0)
            {
                rowCnt = rowCnt + 2;
                colCnt = 11;

                SetCellAlignment(workSheet, rowCnt, colCnt, rowCnt + 3, colCnt + 1);

                workSheet.Cells[rowCnt, colCnt].Value = "Dogs";
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Merge = true;
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.BackgroundColor.SetColor(bgColor);

                DesignPetGenderData(workSheet, "Male", m_DogTotal, rowCnt, colCnt);
                DesignPetGenderData(workSheet, "Female", f_DogTotal, rowCnt + 1, colCnt);
            }


            #endregion


            #region -- Cat total(Dale/Female) --

            if (lstVetNames.Count > 0)
            {
                rowCnt = rowCnt + 4;
                colCnt = 11;

                SetCellAlignment(workSheet, rowCnt, colCnt, rowCnt + 3, colCnt + 1);

                workSheet.Cells[rowCnt, colCnt].Value = "Cats";
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Merge = true;
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 1].Style.Fill.BackgroundColor.SetColor(bgColor);

                DesignPetGenderData(workSheet, "Male", m_CatTotal, rowCnt, colCnt);
                DesignPetGenderData(workSheet, "Female", f_CatTotal, rowCnt + 1, colCnt);
            }

            #endregion


            #region -- Death & Complication --

            if (lstVetNames.Count > 0)
            {
                rowCnt = 1;
                colCnt = 14;
                int totalreason = lstVetNames.Count + 3;  //add 3:(subHeader/oter reason dath/total)

                SetCellAlignment(workSheet, rowCnt, colCnt, rowCnt + totalreason, colCnt + 2);
                workSheet.Cells[rowCnt, colCnt].Value = "Deaths & Complications";
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Merge = true;
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Style.Fill.BackgroundColor.SetColor(bgColor);

                rowCnt = rowCnt + 1;
                workSheet.Cells[rowCnt, colCnt].Value = "Dr. Name";
                workSheet.Cells[rowCnt, colCnt + 1].Value = "Deaths";
                workSheet.Cells[rowCnt, colCnt + 2].Value = "Complications";
                workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

                int totalDeathCount = 0;
                int totalComplicationCount = 0;
                foreach (var item in lstVetNames)
                {
                    int deathCount = response.Where(x => x.VetName.Trim().ToLower() == item.Trim().ToLower() && x.ExpiredDate != null).ToList().Count;
                    totalDeathCount = totalDeathCount + deathCount;
                    int complicationCount = response.Where(x => x.VetName.Trim().ToLower() == item.Trim().ToLower() && x.MedicalNoteId != null
                    && x.IsOnHold == false && x.ExpiredDate == null && x.SurgeryDate != null && (x.ReleaseDate == null || x.ReleaseDate.Value.Date > x.AdmissionDate.Date.AddDays(7))).ToList().Count;
                    totalComplicationCount = totalComplicationCount + complicationCount;
                    Color specialVetColor = Color.FromArgb(18, 143, 139); //lstVetColor.Where(x => x.Key.Trim().ToLower() == item.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

                    DesignVetCell(workSheet, item, rowCnt + 1, colCnt, specialVetColor);
                    DesignVetTotalOperation(workSheet, deathCount, rowCnt + 1, colCnt + 1, specialVetColor, false);
                    DesignVetTotalOperation(workSheet, complicationCount, rowCnt + 1, colCnt + 2, specialVetColor, false);
                    rowCnt = rowCnt + 1;
                }

                rowCnt = rowCnt + 1;
                DesignVetTotalOperation(workSheet, "Total", rowCnt, colCnt, new Color(), true);
                DesignVetTotalOperation(workSheet, totalDeathCount, rowCnt, colCnt + 1, new Color(), true);
                DesignVetTotalOperation(workSheet, totalComplicationCount, rowCnt, colCnt + 2, new Color(), true);
            }

            #endregion

            var exportbytes = excel.GetAsByteArray();
            return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", newFile.Name);

        }


        #region -- All Excel Design Stuff --

        private void SetCellAlignment(ExcelWorksheet workSheet, int rowCntFrom, int colCntFrom, int rowCntTo, int colCntTo)
        {
            workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.Font.Bold = true;
        }
        private void DesignPetGenderData(ExcelWorksheet workSheet, string gender, int totalCount, int rowCnt, int colCnt)
        {
            workSheet.Cells[rowCnt + 1, colCnt].Value = gender;
            workSheet.Cells[rowCnt + 1, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 1].Value = totalCount;
            workSheet.Cells[rowCnt + 1, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
        }

        private void DesignVetTotalOperation(ExcelWorksheet workSheet, dynamic vetOperatedCount, int rowCnt, int colCnt, Color specialVetColor, bool IsGrandTotal = false)
        {
            Color bgColor = Color.FromArgb(76, 82, 112);
            workSheet.Cells[rowCnt, colCnt].Value = vetOperatedCount;
            workSheet.Cells[rowCnt, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt, colCnt].Style.Font.Bold = true;
            if (IsGrandTotal == false)
            {
                workSheet.Cells[rowCnt, colCnt].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt].Style.Fill.BackgroundColor.SetColor(specialVetColor);
            }
            else
            {
                workSheet.Cells[rowCnt, colCnt].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[rowCnt, colCnt].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
                workSheet.Cells[rowCnt, colCnt].Style.Fill.BackgroundColor.SetColor(bgColor);
            }

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
            Color bgColor = Color.FromArgb(76, 82, 112);
            workSheet.Cells[rowCnt + 1, colCnt + 3].Value = m_DogTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 3].Style.Fill.BackgroundColor.SetColor(bgColor);

            workSheet.Cells[rowCnt + 1, colCnt + 4].Value = f_DogTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 4].Style.Fill.BackgroundColor.SetColor(bgColor);

            workSheet.Cells[rowCnt + 1, colCnt + 5].Value = m_CatTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 5].Style.Fill.BackgroundColor.SetColor(bgColor);

            workSheet.Cells[rowCnt + 1, colCnt + 6].Value = f_CatTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 6].Style.Fill.BackgroundColor.SetColor(bgColor);

            workSheet.Cells[rowCnt + 1, colCnt + 8].Value = petTotal;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Font.Bold = true;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Font.Color.SetColor(Color.FromArgb(255, 255, 255));
            workSheet.Cells[rowCnt + 1, colCnt + 8].Style.Fill.BackgroundColor.SetColor(bgColor);
        }

        private void DesignCalenderTableHeader(int days, ExcelWorksheet workSheet, int rowCnt, int colCnt)
        {
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2 + days, colCnt + 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2 + days, colCnt + 8].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2 + days, colCnt + 8].Style.Font.Bold = true;

            workSheet.Cells[rowCnt, colCnt].Value = "Date";
            workSheet.Cells[rowCnt, colCnt, rowCnt + 2, colCnt].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 1].Value = "Venue";
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 1, rowCnt + 2, colCnt + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 2].Value = "Vet";
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 2, rowCnt + 2, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 3].Value = "Dogs";
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 3, rowCnt, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt + 1, colCnt + 3].Value = "Male";
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 2, colCnt + 3].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 3, rowCnt + 2, colCnt + 3].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt + 1, colCnt + 4].Value = "Female";
            workSheet.Cells[rowCnt + 1, colCnt + 4, rowCnt + 2, colCnt + 4].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 4, rowCnt + 2, colCnt + 4].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 5].Value = "Cats";
            workSheet.Cells[rowCnt, colCnt + 5, rowCnt, colCnt + 6].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 5, rowCnt, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt + 1, colCnt + 5].Value = "Male";
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 2, colCnt + 5].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 5, rowCnt + 2, colCnt + 5].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt + 1, colCnt + 6].Value = "Female";
            workSheet.Cells[rowCnt + 1, colCnt + 6, rowCnt + 2, colCnt + 6].Merge = true;
            workSheet.Cells[rowCnt + 1, colCnt + 6, rowCnt + 2, colCnt + 6].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 7].Value = "Deaths/Notes";
            workSheet.Cells[rowCnt, colCnt + 7, rowCnt + 2, colCnt + 7].Merge = true;
            workSheet.Cells[rowCnt, colCnt + 7, rowCnt + 2, colCnt + 7].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

            workSheet.Cells[rowCnt, colCnt + 8].Value = "Total";
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
        #endregion

        #endregion




        private SelectList GetAllYears()
        {
            int currentYear = DateTime.Now.Year;
            List<SelectListItem> objData = new List<SelectListItem>();
            for (int i = 2015; i <= 2030; i++)
            {
                if (i == currentYear)
                {
                    objData.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = true });
                }
                else
                {
                    objData.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                }

            }
            return new SelectList(objData, "Value", "Text", currentYear);
        }

        private SelectList GetAllMonths()
        {

            List<SelectListItem> objData = new List<SelectListItem>();
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            int currentMonth = DateTime.Now.Month;
            for (int i = 1; i < 13; i++)
            {
                if (i == currentMonth)
                {
                    objData.Add(new SelectListItem { Text = info.GetMonthName(i), Value = i.ToString(), Selected = true });
                }
                else
                {
                    objData.Add(new SelectListItem { Text = info.GetMonthName(i), Value = i.ToString() });
                }

            }

            return new SelectList(objData, "Value", "Text", currentMonth);
        }

    }
}



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