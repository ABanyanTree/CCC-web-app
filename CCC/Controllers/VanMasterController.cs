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
    public class VanMasterController : Controller
    {
        public async Task<ActionResult> ManageVan()
        {
            VanMasterRequest obj = new VanMasterRequest();
            return View(obj);
        }

        [HttpPost("/VanMaster/FillTableVanMasterAsync")]
        public async Task<IActionResult> FillTableVanMasterAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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

            VanMasterRequest searchObj = new VanMasterRequest();
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
                        case "VanNumber":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.VanNumber = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await VanMasterAPI.GetAllVanDetailList(searchObj);
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
        public async Task<IActionResult> AddEditVan(string vanId)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            VanMasterRequest model = new VanMasterRequest();
            if (!string.IsNullOrEmpty(vanId))
            {
                var updateResponse = await VanMasterAPI.GetVanDetail(vanId);
                model = updateResponse.Content;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditVan(VanMasterRequest model)
        {
            bool IsNewRecord = string.IsNullOrEmpty(model.VanId) ? true : false;
            VanMasterRequest modelobj = new VanMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await VanMasterAPI.AddEditVanDetail(model);
            string vetId = apiResponse?.Content?.ReadAsStringAsync().Result;

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                string msg = IsNewRecord ? "Van Details added successfully." : "Van Details updated successfully.";
                return Json(new { VetId = vetId, isSuccess = true, message = msg });
            }
            else
            {
                return Json(new { VetId = 0, isSuccess = false, message = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> IsInUseCount(string vanId)
        {
            VetMasterRequest modelobj = new VetMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await VanMasterAPI.IsInUseCount(vanId);
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
        public async Task<IActionResult> DeleteVan(string vanId)
        {
            VetMasterRequest modelobj = new VetMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await VanMasterAPI.DeleteVan(vanId);

            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true });
            }
            else
            {
                return Json(new { isSuccess = false });
            }

        }

        [HttpGet]
        public async Task<JsonResult> IsVanNumberInUse(string vanNumber)
        {
            if (vanNumber == null || string.IsNullOrEmpty(vanNumber.Trim()))
            {
                return Json("Please enter van number");
            }
            else
            {
                var objSessionUser = HttpContext.Session.GetSessionUser();
                var cachedToken = HttpContext.Session.GetBearerToken();
                var VanMasterAPI = RestService.For<IVanMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
                });
                var res = "";
                var apiResponse = await VanMasterAPI.IsVanNumberInUse(vanNumber);
                if (apiResponse != null)
                {
                    if (apiResponse.Content.ReadAsStringAsync().Result == "true")
                    {
                        res = apiResponse.Content.ReadAsStringAsync().Result;
                    }
                }

                return Json(res);
            }
        }
    }
}
