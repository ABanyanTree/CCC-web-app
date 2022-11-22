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
            return View();
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
    }
}
