using CCC.API.ApiPath;
using CCC.API.APIUtility;
using CCC.Domain;
using CCC.Service.Infra;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CCC.API.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IPetServices _iPetService;
        private readonly ICenterMasterService _iCenterMasterService;
        private readonly IPetDataNotificationService _iPetDataNotificationService;
        private readonly IUserMasterService _iUserMasterService;
        private IWebHostEnvironment Environment;

        public NotificationController(IPetServices petServices, IPetDataNotificationService PetDataNotificationService,
            ICenterMasterService CenterMasterService, IUserMasterService UserMasterService, IWebHostEnvironment _environment)
        {
            _iPetService = petServices;
            _iPetDataNotificationService = PetDataNotificationService;
            _iCenterMasterService = CenterMasterService;
            _iUserMasterService = UserMasterService;
            Environment = _environment;
        }

        [HttpGet(ApiRoutes.Notification.DailyDataCheck)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        public async Task<IActionResult> DailyDataCheck()
        {
            var objResponse = await _iCenterMasterService.DailyDataCheck();
            var admins = await _iUserMasterService.GetAllUsers();
            //EmailSender obj = new EmailSender();
            //var responceObj = obj.SendDailyNotificationToAdmin(objResponse, admins);

            return Ok(objResponse);
        }

        [HttpGet(ApiRoutes.Notification.VetReportNotification)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        public async Task<IActionResult> VetReportNotification()
        {
            DateTime today = DateTime.Now;
            if (today.Day == 1)
            {
                var month = new DateTime(today.Year, today.Month, 1);
                var firstDayOfMonth = month.AddMonths(-1);
                var lastDayOfMonth = month.AddDays(-1);

                int days = DateTime.DaysInMonth(firstDayOfMonth.Year, firstDayOfMonth.Month);

                var objResponse = await _iCenterMasterService.GetAllCenters(new CenterMaster());

                foreach (var centers in objResponse)
                {
                    var centerManagers = await _iUserMasterService.GetUsersByCenter(new UserMaster() { CenterIds = centers.CenterId });
                    string CM_Emails = string.Join(",", centerManagers.Select(x => x.Email));

                    PetServiceDetails searchObj = new PetServiceDetails();
                    searchObj.CenterId = centers.CenterId;
                    searchObj.SurgeryDateFrom = firstDayOfMonth;
                    searchObj.SurgeryDateTo = lastDayOfMonth;

                    var response = await _iPetService.GetVetReport(searchObj);

                    string path = Path.Combine(this.Environment.WebRootPath, "VetReports");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string centerName = response.Select(x => x.CenterName).FirstOrDefault();
                    string reportFileName = centerName + "_" + firstDayOfMonth.Month + "-" + firstDayOfMonth.Year;
                    FileInfo newFile = new FileInfo(Path.Combine(path, "VetReport_" + reportFileName));
                    using (ExcelPackage package = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("VetReport");
                        List<string> lstVetNames = response.Select(x => x.VetName).Distinct().ToList();

                        int rowCnt = 1;
                        int colCnt = 1;


                        rowCnt = rowCnt + 2;
                        int petTotal = 0, m_DogTotal = 0, f_DogTotal = 0, m_CatTotal = 0, f_CatTotal = 0;

                        for (int i = 1; i <= days; i++)
                        {
                            rowCnt = rowCnt + 1;
                            colCnt = 1;
                            string date = firstDayOfMonth.Month + '/' + i.ToString() + '/' + firstDayOfMonth.Year;
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

                                int optDogsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                                int optDogsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                                int optCatsCount_m = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE).ToList().Count;
                                int optCatsCount_f = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE).ToList().Count;

                                int mCncDog = 0; int fCncDog = 0; int mCncCat = 0; int fCncCat = 0;
                                int mDeathDog = 0; int fDeathDog = 0; int mDeathCat = 0; int fDeathCat = 0;

                                mCncDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;
                                fCncDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;

                                mCncCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;
                                fCncCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE && x.IsOnHold == true && x.ExpiredDate == null).ToList().Count;

                                mDeathDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                                fDeathDog = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_DOG && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;

                                mDeathCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_MALE && x.ExpiredDate != null).ToList().Count;
                                fDeathCat = response.Where(x => x.SurgeryDate.Value.Date == sDate.Date && x.PetType == CommonConst.LOOKUPTYPE_PETTYPE_Cat && x.Gender == CommonConst.LOOKUPTYPE_PETGENDER_FEMALE && x.ExpiredDate != null).ToList().Count;

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
                                int complicationCount = response.Where(x => x.VetName.Trim().ToLower() == item.Trim().ToLower() && x.MedicalNoteId != null).ToList().Count;
                                totalComplicationCount = totalComplicationCount + complicationCount;
                                Color specialVetColor = Color.FromArgb(18, 143, 139); //lstVetColor.Where(x => x.Key.Trim().ToLower() == item.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

                                DesignVetCell(workSheet, item, rowCnt + 1, colCnt, specialVetColor);
                                DesignVetTotalOperation(workSheet, deathCount, rowCnt + 1, colCnt + 1, specialVetColor, false);
                                DesignVetTotalOperation(workSheet, complicationCount, rowCnt + 1, colCnt + 2, specialVetColor, false);
                                rowCnt = rowCnt + 1;
                            }
                            rowCnt = rowCnt + 1;
                            workSheet.Cells[rowCnt, colCnt].Value = "*Deaths due to other reasons -2*";
                            workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Merge = true;
                            workSheet.Cells[rowCnt, colCnt, rowCnt, colCnt + 2].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);

                            rowCnt = rowCnt + 1;
                            DesignVetTotalOperation(workSheet, "Total", rowCnt, colCnt, new Color(), true);
                            DesignVetTotalOperation(workSheet, totalDeathCount, rowCnt, colCnt + 1, new Color(), true);
                            DesignVetTotalOperation(workSheet, totalComplicationCount, rowCnt, colCnt + 2, new Color(), true);
                        }

                        #endregion


                        package.Save();
                    }



                    //Email the file to respective centerManagers
                    var IsEmailSend = await _iPetDataNotificationService.SendMonthlyNotification(reportFileName, CommonConst.FEATURE_VetReport, CM_Emails);

                }


            }
            return Ok(false);

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


    }
}
