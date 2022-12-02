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
    public class UserMasterController : Controller
    {

        public async Task<ActionResult> ManageUsers()
        {
            UserMasterRequest obj = new UserMasterRequest();
            return View(obj);
        }

        [HttpPost("/UserMaster/FillTableUserMasterAsync")]
        public async Task<IActionResult> FillTableUserMasterAsync([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest dt)
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

            UserMasterRequest searchObj = new UserMasterRequest();
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
                        case "UserName":
                            if (!string.IsNullOrEmpty(col.Search.Value))
                            {
                                searchObj.UserName = col.Search.Value.Trim();
                            }
                            break;
                    }
                }
            }

            var cachedToken = HttpContext.Session.GetBearerToken();

            var UserAPI = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
            var apiResponse = await UserAPI.GetAllUserDetailList(searchObj);
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
        public async Task<IActionResult> AddEditUser(string userId)
        {
            var objSessionUser = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var UserAPI = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var CenterMasterAPI = RestService.For<ICenterMasterApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var centerRes = await CenterMasterAPI.GetAllCenters();
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            UserMasterRequest model = new UserMasterRequest();
            if (!string.IsNullOrEmpty(userId))
            {
                var updateResponse = await UserAPI.GetUser(userId);
                model = updateResponse.Content;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditUser(UserMasterRequest model)
        {
            bool IsNewRecord = string.IsNullOrEmpty(model.UserId) ? true : false;
            UserMasterRequest modelobj = new UserMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();

            var UserAPI = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            string[] userCenters = Request.Form["lstCentr"].ToString().Split(",");
            if (userCenters.Length > 0)
            {
                model.CenterIds = Request.Form["lstCentr"].ToString();
            }

            model.CreatedBy = objSessionUSer.UserId;
            var apiResponse = await UserAPI.AddEditUser(model);
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
        public async Task<IActionResult> IsInUseCount(string userId)
        {
            UserMasterRequest modelobj = new UserMasterRequest();
            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var iUserApi = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken),

            });
            var apiResponse = await iUserApi.IsInUseCount(userId);
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
        public async Task<IActionResult> DeleteUser(string userId)
        {
            UserMasterRequest modelobj = new UserMasterRequest();

            var objSessionUSer = HttpContext.Session.GetSessionUser();
            var cachedToken = HttpContext.Session.GetBearerToken();
            var iUserApi = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken),

            });
            var apiResponse = await iUserApi.DeleteUser(userId);

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
        public async Task<JsonResult> IsUserNameInUse(string userName, string userId = "")
        {
            if (userName == null || string.IsNullOrEmpty(userName.Trim()))
            {
                return Json("Please enter user Name");
            }
            else
            {
                var objSessionUser = HttpContext.Session.GetSessionUser();
                var cachedToken = HttpContext.Session.GetBearerToken();
                var iUserApi = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl, new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken),

                });
                var IsNameExists = false;
                var apiResponse = await iUserApi.IsUserNameInUse(userName.Trim());
                if (apiResponse != null)
                {
                    if (string.IsNullOrEmpty(userId))
                    {
                        IsNameExists = (apiResponse.Content == null) ? false : true;
                    }
                    else
                    {
                        IsNameExists = apiResponse.Content == null ? false :
                            (userId != apiResponse.Content.UserId) ? true : false;
                    }
                }

                return Json(IsNameExists);
            }
        }
    }
}
