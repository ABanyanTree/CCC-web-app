using CCC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using DataTables.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Refit;


namespace CCC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Dashboard()
        {
            SearchPetData obj = new SearchPetData();
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var objResponse = await PetServiceAPI.GetPetUnReadData(objSessionUSer.UserId, objSessionUSer.IsAdmin);
            obj.TotalCount = objResponse.Content != null ? objResponse.Content.TotalCount : 0;
            return View(obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> CenterManagerDashnoard()
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

            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var objResponse = await PetServiceAPI.GetPetUnReadData(objSessionUser.UserId, objSessionUser.IsAdmin);
            obj.TotalCount = objResponse.Content != null ? objResponse.Content.TotalCount : 0;

            var centerRes = await CenterMasterAPI.GetAllCenters(objSessionUser.UserCenters);
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
            ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

            return View(obj);
        }

        [HttpPost("/Home/FillTableCMDashboardAsync")]
        public async Task<IActionResult> FillTableCMDashboardAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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
                    }
                }
            }

            searchObj.RequesterUserId = objSessionUSer.UserId;
            searchObj.UserCenters = objSessionUSer.UserCenters;
            var cachedToken = HttpContext.Session.GetBearerToken();

            var PetServiceAPI = RestService.For<IPetServiceApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await PetServiceAPI.GetCenterMgrDashboardList(searchObj);
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
    }
}
