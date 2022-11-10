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

            var LookupMasterAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });


            var centerRes = await CenterMasterAPI.GetAllCenters();
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
            ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

            var vetRes = await VetMasterAPI.GetAllVetDetails();
            ViewBag.lstVet = new SelectList(vetRes.Content, "VetId", "VetName");

            var petTypes = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_PETTYPE);
            ViewBag.lstPetType = new SelectList(vetRes.Content, "LookupId", "LookupValue");

            return View(obj);

        }

        [HttpPost("/PetService/FillTablePetServiceAsync")]
        public async Task<IActionResult> FillTablePetServiceAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt, string Active = "1")
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
                        case "VetId":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.VetId = col.Search.Value.Trim();
                            }
                            break;
                        case "SurgeryDate":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.SurgeryDate = Convert.ToDateTime(col.Search.Value.Trim());
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
            var apiResponse = await PetServiceAPI.GetAllPetDataList(searchObj);
            var response = apiResponse.Content;

            var lst = response;

            var lst1 = lst?.ToList();

            //if (lst1 != null && lst1.Count > 0)
            //{
            //    TotalCount = lst1[0].TotalCount;
            //}
            bool set = false;
            if (searchObj.PageIndex > 1 && TotalCount == 0)
                set = true;
            return Json(new DataTablesResponse(dt.Draw, lst1, TotalCount, TotalCount, colList, set));
        }

        [HttpGet]
        public async Task<IActionResult> AddEditPetData(string serviceId)
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

            var LookupMasterAPI = RestService.For<ILookupMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });


            var centerRes = await CenterMasterAPI.GetAllCenters();
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
            ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

            var vetRes = await VetMasterAPI.GetAllVetDetails();
            ViewBag.lstVet = new SelectList(vetRes.Content, "VetId", "VetName");
            
            var petTypes = await LookupMasterAPI.GetLookupData(CommonConstants.LOOKUPTYPE_PETTYPE);
            ViewBag.lstPetType = new SelectList(petTypes.Content, "LookupId", "LookupValue");


            CreatePetService model = new CreatePetService();
            if (!string.IsNullOrEmpty(serviceId))
            {
                var updateResponse = await PetServiceAPI.GetPetData(serviceId);
                model = updateResponse.Content;
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
            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await PetServiceAPI.AddEditPetData(model);
            string CountryID = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                string msg = IsNewRecord ? "Country added successfully." : "Country updated successfully.";
                return Json(new { CountryID = CountryID, isSuccess = true, message = msg });
            }
            else
            {

                return Json(new { CountryID = 0, isSuccess = false, message = "" });
            }
        }
    }
}
