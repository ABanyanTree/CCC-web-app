using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
    public class PetServiceController : Controller
    {
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
                            searchObj.TagId= col.Search.Value.Trim();
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
            return Json(new DataTablesResponse(dt.Draw, lst1, TotalCount, TotalCount, colList, set));
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
                model.IsARV = model.IsEarNotch = model.IsOnHold = false;

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
    }
}
