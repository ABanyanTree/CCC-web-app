using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
	public class CityAreaMasterController : Controller
    {
        public async Task<ActionResult> ManageCityArea()
        {
            CityAreaMasterRequest obj = new CityAreaMasterRequest();
            return View(obj);
        }

        [HttpPost("/CityAreaMaster/FillTableCityAreaMasterAsync")]
        public async Task<IActionResult> FillTableCityAreaMasterAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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

            CityAreaMasterRequest searchObj = new CityAreaMasterRequest();
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
                        case "AreaName":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.AreaName = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var CityAreaAPI = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await CityAreaAPI.GetAllCityAreaList(searchObj);
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

        [HttpGet]
        public async Task<IActionResult> AddEditCityArea(string areaId)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();


            var CityAreaApi = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            CityAreaMasterRequest model = new CityAreaMasterRequest();
            if (!string.IsNullOrEmpty(areaId))
            {
                var updateResponse = await CityAreaApi.GetCityArea(areaId);
                model = updateResponse.Content;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCityArea(CityAreaMasterRequest model)
        {
            bool IsNewRecord = string.IsNullOrEmpty(model.AreaId) ? true : false;
            CityAreaMasterRequest modelobj = new CityAreaMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var CityAreaApi = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await CityAreaApi.AddEditCityArea(model);
            string areaId = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                string msg = IsNewRecord ? "Area added successfully." : "Area updated successfully.";
                return Json(new { AreaId = areaId, AreaName = model.AreaName, isSuccess = true, message = msg });
            }
            else
            {
                return Json(new { areaId = 0, isSuccess = false, message = "" });
            }
        }


        [HttpPost]
        public async Task<IActionResult> IsInUseCount(string areaId)
        {
            CityAreaMasterRequest modelobj = new CityAreaMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var CityAreaApi = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await CityAreaApi.IsInUseCount(areaId);
            string Count = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true, Count = Count });
            }
            else
            {
                return Json(new { isSuccess = false, Count = 0 });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCityArea(string areaId)
        {
            CityAreaMasterRequest modelobj = new CityAreaMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var CityAreaApi = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await CityAreaApi.DeleteArea(areaId);

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
        public async Task<JsonResult> IsAreaNameInUse(string areaName, string areaId = "")
        {
            if (areaName == null || string.IsNullOrEmpty(areaName.Trim()))
            {
                return Json("Please enter area Name");
            }
            else
            {
                var objSessionUser = HttpContext.Session.GetSessionUser();
                var cachedToken = HttpContext.Session.GetBearerToken();
                var CityAreaApi = RestService.For<ICityAreaMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
                });
                var IsNameExists = false;
                var apiResponse = await CityAreaApi.IsCityAreaNameInUse(areaName.Trim());
                if (apiResponse != null)
                {
                    if (string.IsNullOrEmpty(areaId))
                    {
                        IsNameExists = (apiResponse.Content == null) ? false : true;
                    }
                    else
                    {
                        IsNameExists = apiResponse.Content == null ? false :
                            (areaId != apiResponse.Content.AreaId) ? true : false;
                    }
                }

                return Json(IsNameExists);
            }
        }

        public async Task<IActionResult> AddAreaQuick()
        {
            CityAreaMasterRequest model = new CityAreaMasterRequest();
            return PartialView("_AddAreaQuick", model);
        }

    }
}
