using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CCC.Service.Infra;
using CCC.UI.Models;
using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Refit;

namespace CCC.UI.Controllers
{
	public class PetServiceController : Controller
	{
		private readonly IOptions<MySettingsModel> appSettings;

		public PetServiceController(IOptions<MySettingsModel> appSettings)
		{
			ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<ActionResult> ManagePetService()
		{
			var objSessionUser = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();

			SearchPetData obj = new SearchPetData();
			obj.IsAdmin = objSessionUser.IsAdmin;

			var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var CityAreaMasterAPI = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var LookupMasterAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
			ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

			var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
			ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

			var Colors = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_COLOR);
			ViewBag.lstColors = new SelectList(Colors.Content, "LookupId", "LookupValue");

			var objResponse = await PetServiceAPI.GetPetUnReadData(objSessionUser.UserId, objSessionUser.IsAdmin);
			obj.TotalCount = objResponse.Content != null ? objResponse.Content.TotalCount : 0;

			return View(obj);

		}

		[HttpPost("/PetService/FillTablePetServiceAsync")]
		public async Task<IActionResult> FillTablePetServiceAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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
			{
				if (dt.SortColumnName == "PetType")
				{
					searchObj.SortExp = "lk.LookupValue" + " " + sortdir;
				}
				else
				{
					searchObj.SortExp = dt.SortColumnName + " " + sortdir;
				}

			}

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
						case "Color":
							if (!string.IsNullOrEmpty(col.Search.Value))
							{
								searchObj.Color = col.Search.Value.Trim();
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
						case "ShowReleasedPet":
							if (!string.IsNullOrEmpty(col.Search.Value))
							{
								if (col.Search.Value == "1")
								{
									searchObj.ShowReleasedPet = true;
								}
								else
								{
									searchObj.ShowReleasedPet = false;
								}
							}
							break;
						case "TagId":
							searchObj.TagId = col.Search.Value.Trim();
							break;

					}
				}
			}

			var cachedToken = HttpContext.Session.GetBearerToken();
			searchObj.RequesterUserId = objSessionUSer.UserId;
			searchObj.UserCenters = objSessionUSer.UserCenters;
			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});
			var apiResponse = await PetServiceAPI.GetAllPetDataList(searchObj);
			var response = apiResponse.Content;

			response = response.Select(x => { x.IsAdmin = objSessionUSer.IsAdmin; return x; }).ToList();

			var lst = response;

			var lst1 = lst?.ToList();

			if (lst1 != null && lst1.Count > 0)
			{
				TotalCount = lst1[0].TotalCount;
			}
			bool set = false;
			if (searchObj.PageIndex > 1 && TotalCount == 0)
				set = true;



			// ExportReport(lst1);

			//HttpContext.Session.SetObject("ExportReport", lst1);

			//var objComplex = HttpContext.Session.GetObject<List<GetAllPetDataResponse>>("ExportReport");

			return Json(new DataTablesResponse(dt.Draw, lst1, TotalCount, TotalCount, colList, set));
		}		

		[HttpGet("/PetService/ExportReportPetServiceAsync")]
		public async Task<IActionResult> ExportReportPetServiceAsync(string CenterId, string areaId, string color, string admissionDateFrom, string admissionDateTo, string surgeryDateFrom, string surgeryDateTo, string releaseDateFrom, string releaseDateTo, string showReleasedPet, string tagId)
		{
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
           
            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            SearchPetData searchObj = new SearchPetData();			
		
			searchObj.TagId = tagId;

            if (!string.IsNullOrEmpty(CenterId)) searchObj.CenterId = CenterId.Trim();
            else searchObj.CenterId = CenterId;

            if (!string.IsNullOrEmpty(areaId)) searchObj.AreaId = areaId.Trim();
			else searchObj.AreaId = areaId;

			if (!string.IsNullOrEmpty(color)) searchObj.Color = color.Trim();
			else searchObj.Color = color;

			if (!string.IsNullOrEmpty(Convert.ToString(admissionDateFrom))) searchObj.AdmissionDateFrom = Convert.ToDateTime(admissionDateFrom);
		
			if (!string.IsNullOrEmpty(Convert.ToString(admissionDateTo))) searchObj.AdmissionDateTo = Convert.ToDateTime(admissionDateTo);

            if (!string.IsNullOrEmpty(Convert.ToString(surgeryDateFrom))) searchObj.SurgeryDateFrom = Convert.ToDateTime(surgeryDateFrom);
            
            if (!string.IsNullOrEmpty(Convert.ToString(surgeryDateTo))) searchObj.SurgeryDateTo = Convert.ToDateTime(surgeryDateTo);

            if (!string.IsNullOrEmpty(Convert.ToString(releaseDateFrom))) searchObj.ReleaseDateFrom = Convert.ToDateTime(releaseDateFrom);
      
            if (!string.IsNullOrEmpty(Convert.ToString(releaseDateTo)))  searchObj.ReleaseDateTo = Convert.ToDateTime(releaseDateTo);
        
            if (!string.IsNullOrEmpty(showReleasedPet))
            {
                if (showReleasedPet == "1")
                {
                    searchObj.ShowReleasedPet = true;
                }
                else
                {
                    searchObj.ShowReleasedPet = false;
                }
            }

            searchObj.RequesterUserId = objSessionUSer.UserId;
            searchObj.UserCenters = objSessionUSer.UserCenters;

            var apiResponse = await PetServiceAPI.GetAllPetReportDataList(searchObj);
            var response = apiResponse.Content;

            var lst = response;

            var lst1 = lst?.ToList();

            FileInfo newFile = new FileInfo("D:\\Shahen-WorkFront\\PetServiceReport_" + Guid.NewGuid().ToString() + "_.xlsx");
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = excel.Workbook.Worksheets.Add("Vet Report");            
            var exportbytes = ExportReport(lst1, newFile); ;
            return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", newFile.Name);
        }

		public byte[] ExportReport(List<GetAllPetDataResponse> lst1, FileInfo newFile)
		{
			DateTime today = DateTime.Now;
			var month = new DateTime(today.Year, today.Month, 1);
			var firstDayOfMonth = month.AddMonths(-1);

			using (ExcelPackage package = new ExcelPackage(newFile))
			{
				ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("VetReport");
				var lstVetNames = lst1.ToList();

				int rowCnt = 1;
				int colCnt = 1;

				//Add Header 
				string monthName = HelperUtility.GetMonthName(firstDayOfMonth.Month);
				workSheet.Cells[rowCnt, colCnt].Value = string.Format("Vet Report for Month of {0} - {1}", monthName, firstDayOfMonth.Year.ToString());
				workSheet.Cells[rowCnt, colCnt].Style.Border.BorderAround(ExcelBorderStyle.Thick, Color.Black);
				workSheet.Cells[rowCnt, colCnt].Style.Font.Bold = true;

				workSheet.Cells[rowCnt + 1, colCnt].Value = "Admission Date";
                workSheet.Cells[rowCnt + 1, colCnt + 1].Value = "Surgery Date";
                workSheet.Cells[rowCnt + 1, colCnt + 2].Value = "Vet Name";
                workSheet.Cells[rowCnt + 1, colCnt + 3].Value = "Species";
                workSheet.Cells[rowCnt + 1, colCnt + 4].Value = "Colour";
                workSheet.Cells[rowCnt + 1, colCnt + 5].Value = "Gender";
                workSheet.Cells[rowCnt + 1, colCnt + 6].Value = "Tag Id";
                workSheet.Cells[rowCnt + 1, colCnt + 7].Value = "Center Name";
                workSheet.Cells[rowCnt + 1, colCnt + 8].Value = "Area Name";
                workSheet.Cells[rowCnt + 1, colCnt + 9].Value = "Care Giver";
                workSheet.Cells[rowCnt + 1, colCnt + 10].Value = "Release Date";
                workSheet.Cells[rowCnt + 1, colCnt + 11].Value = "Medical Comments";

                if (lstVetNames.Count > 0)
				{
					rowCnt = 1;
					colCnt = 1;
					int totalvets = lstVetNames.Count + 1;  //add 1 for total row	

					int grandTotalByVet = 0;
					foreach (var item in lstVetNames)
					{
						int vetOperatedCount = lstVetNames.Count();
						int exCanCount = lstVetNames.Count();
						int opCountFinal = vetOperatedCount - exCanCount;
						grandTotalByVet = (grandTotalByVet + opCountFinal);
						Color specialVetColor = Color.FromArgb(18, 143, 139); //lstVetColor.Where(x => x.Key.Trim().ToLower() == item.Trim().ToLower()).Select(x => x.Value).FirstOrDefault();

						DesignVetCell(workSheet, item.AdmissionDate, rowCnt + 2, colCnt, specialVetColor);
						DesignVetCell(workSheet, item.SurgeryDate, rowCnt + 2, colCnt + 1, specialVetColor);
                        DesignVetCell(workSheet, item.VetName, rowCnt + 2, colCnt + 2, specialVetColor);
                        DesignVetCell(workSheet, item.PetType, rowCnt + 2, colCnt + 3, specialVetColor);
                        DesignVetCell(workSheet, item.ColorValue, rowCnt + 2, colCnt + 4, specialVetColor);
                        DesignVetCell(workSheet, item.Gender, rowCnt + 2, colCnt + 5, specialVetColor);
                        DesignVetCell(workSheet, item.TagId, rowCnt + 2, colCnt + 6, specialVetColor);
                        DesignVetCell(workSheet, item.CenterName, rowCnt + 2, colCnt + 7, specialVetColor);
                        DesignVetCell(workSheet, item.AreaName, rowCnt + 2, colCnt + 8, specialVetColor);
                        DesignVetCell(workSheet, item.CareGiver, rowCnt + 2, colCnt + 9, specialVetColor);
                        DesignVetCell(workSheet, item.ReleaseDate, rowCnt + 2, colCnt + 10, specialVetColor);
                        DesignVetCell(workSheet, item.MedicalComments, rowCnt + 2, colCnt + 11, specialVetColor);
                        rowCnt = rowCnt + 1;

					}					
				}
               // package.Save(); ;
				return package.GetAsByteArray();
            }

		}

		private void DesignVetCell(ExcelWorksheet workSheet, dynamic val, int rowCnt, int colCnt, Color specialVetColor)
		{
			workSheet.Cells[rowCnt, colCnt].Value = val;
		}

		private void SetCellAlignment(ExcelWorksheet workSheet, int rowCntFrom, int colCntFrom, int rowCntTo, int colCntTo)
		{
			workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			workSheet.Cells[rowCntFrom, colCntFrom, rowCntTo, colCntTo].Style.Font.Bold = true;
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

		[HttpGet]
		public async Task<IActionResult> AddEditPetData(string serviceId, string redirectFrom = "")
		{
			var objSessionUser = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();

			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var CityAreaMasterAPI = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var VetMasterAPI = RestService.For<IVetMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			var LookupMasterAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});


			var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
			ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

			var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
			ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

			var vetRes = await VetMasterAPI.GetAllVetDetails();
			ViewBag.lstVet = new SelectList(vetRes.Content, "VetId", "VetName");

			var vanRes = await VanMasterAPI.GetAllVanDetail();
			ViewBag.lstVan = new SelectList(vanRes.Content, "VanId", "VanNumber");

			var petTypes = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_PETTYPE);
			ViewBag.lstPetType = new SelectList(petTypes.Content, "LookupId", "LookupValue");

			var MedicalNotes = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_MEDICALNOTES);
			ViewBag.lstMedicalNotes = new SelectList(MedicalNotes.Content, "LookupId", "LookupValue");


			var Colors = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_COLOR);
			ViewBag.lstColors = new SelectList(Colors.Content, "LookupId", "LookupValue");


			CreatePetService model = new CreatePetService();
			model.IsAdmin = objSessionUser.IsAdmin;
			model.redirectFrom = redirectFrom;
			if (!string.IsNullOrEmpty(serviceId))
			{
				var updateResponse = await PetServiceAPI.GetPetData(serviceId);
				model = updateResponse.Content;
			}
			else
			{
				//default selected as No
				model.AdmissionDate = DateTime.Now;
				model.IsARV = model.IsEarNotch = model.IsOnHold = model.IsNineInOne = false;

			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddEditPetData(CreatePetService model)
		{
			bool IsNewRecord = string.IsNullOrEmpty(model.ServiceId) ? true : false;
			CreatePetService modelobj = new CreatePetService();

			var objSessionUSer = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();

			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});
			if (IsNewRecord) { model.CreatedBy = objSessionUSer.UserId; }
			model.ModifiedBy = objSessionUSer.UserId;
			model.CertificateNo = "-"; // Not in use but kept if required then need to remove this line
			var apiResponse = await PetServiceAPI.AddEditPetData(model);
			string serviceId = apiResponse?.Content?.ReadAsStringAsync().Result;

			var IsNotificationUpdated = await UpdatePetDataForNotification(serviceId, objSessionUSer.UserId, objSessionUSer.IsAdmin);

			if (apiResponse != null && apiResponse.IsSuccessStatusCode)
			{
				string msg = IsNewRecord ? "Pet added successfully." : "Pet updated successfully.";
				return Json(new { serviceId = serviceId, isSuccess = true, message = msg, redirectFrom = model.redirectFrom });
			}
			else
			{
				return Json(new { CountryID = 0, isSuccess = false, message = "" });
			}
		}

		private async Task<IActionResult> UpdatePetDataForNotification(string serviceId, string userId, bool IsAdmin)
		{
			bool IsSuccess = false;
			var objSessionUSer = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();
			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});
			PetDataNotificationRequest model = new PetDataNotificationRequest();
			model.ServiceId = serviceId;
			model.UserId = userId;
			model.IsAdmin = IsAdmin;

			var apiResponse = await PetServiceAPI.AddPetDataNotification(model);
			return Ok(IsSuccess);

		}

		public async Task<IActionResult> ReadPetData()
		{
			var objSessionUSer = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();
			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});
			string userId = objSessionUSer.UserId;
			var apiResponse = await PetServiceAPI.ReadPetDataByUser(userId, objSessionUSer.IsAdmin);
			var data = (List<PetDataNotificationResponse>)apiResponse.Content;
			return PartialView("_OnHoldPetData", data);
		}



		public async Task<IActionResult> ChangeCenter(string serviceIds)
		{
			var objSessionUser = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();

			CreatePetService model = new CreatePetService();
			if (!string.IsNullOrEmpty(serviceIds))
			{
				List<string> serviceIdArray = serviceIds.Split(',').ToList();
				serviceIdArray.RemoveAll(x => string.IsNullOrEmpty(x) && x == "undefined");
				model.ServiceId = string.Join(",", serviceIdArray);

				//model.ServiceId = serviceIds;
				var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
				{
					AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
				});

				var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
				ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");
			}

			return PartialView("_ChangeCenter", model);
		}

		[HttpPost]
		public async Task<IActionResult> ChangeCenter(CreatePetService model)
		{
			var objSessionUSer = HttpContext.Session.GetSessionUser();
			var cachedToken = HttpContext.Session.GetBearerToken();

			var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
			{
				AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
			});

			model.CreatedBy = objSessionUSer.UserId;
			var apiResponse = await PetServiceAPI.ChangePetCenters(model);

			if (apiResponse != null && apiResponse.IsSuccessStatusCode)
			{
				return Json(new { isSuccess = true });
			}
			else
			{
				return Json(new { isSuccess = false });
			}
		}

		[HttpPost]
		public async Task<JsonResult> IsTagIdInUse(string tagId, string ServiceId = "")
		{
			if (tagId == null || string.IsNullOrEmpty(tagId.Trim()))
			{
				return Json("Please enter tag Id.");
			}
			else
			{
				var objSessionUser = HttpContext.Session.GetSessionUser();
				var cachedToken = HttpContext.Session.GetBearerToken();
				var petServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
				{
					AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
				});

				var IsTagIdExists = false;
				var apiResponse = await petServiceAPI.IsTagIdInUse(tagId.Trim());
				if (apiResponse != null)
				{
					if (string.IsNullOrEmpty(ServiceId))
					{
						IsTagIdExists = (apiResponse.Content == null) ? false : true;
					}
					else
					{
						IsTagIdExists = apiResponse.Content == null ? false :
							(ServiceId != apiResponse.Content.ServiceId) ? true : false;
					}
				}
				return Json(IsTagIdExists);
			}
		}
	}
}
