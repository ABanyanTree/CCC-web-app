using CCC.UI.Models;
using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private readonly IOptions<VersionSettings> versionSettings;

        public LoginController(IOptions<MySettingsModel> app, IOptions<VersionSettings> ver)
        {
            appSettings = app;
            versionSettings = ver;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        public IActionResult Login(string ReturnUrl)
        {
            var userAPI = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl);
            //If SignOut, then record signout time.
            string loginUniqueId = HttpContext.Session.GetObject<string>("LoginUniqueId");
            if (!string.IsNullOrEmpty(loginUniqueId))
            {
                userAPI.TrackSignOutTime(loginUniqueId);
            }
            HttpContext.Session.Clear();
            UserLoginRequestVM model = new UserLoginRequestVM();
            var result = userAPI.GetMD5Salt();
            if (result != null)
            {
                model.Salt = result.Result.Content.ReadAsStringAsync().Result;
            }

            //model.Association = association;
            //model.Brand = brand;
            ViewBag.ReturnUrl = ReturnUrl;

            ViewBag.loginPageText = appSettings.Value.LoginPageText;

            HttpContext.Session.SetObject("SessionVersionName", versionSettings.Value.VersionName);
            HttpContext.Session.SetObject("SessionFooterText", versionSettings.Value.FooterText);


            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestVM model, string ReturnUrl)
        {
            var userAPI = RestService.For<IUserApi>(hostUrl: ApplicationSettings.WebApiUrl);

            var apiResponse = await userAPI.LoginAsync(model);
            var response = apiResponse.Content;

            HttpContext.Session.SetObject("SessionVersionName", versionSettings.Value.VersionName);
            HttpContext.Session.SetObject("SessionFooterText", versionSettings.Value.FooterText);
            HttpContext.Session.SetObject("StagingSiteMessage", versionSettings.Value.StagingSiteMessage);

            if (response != null)
            {
                // SET FEATURES
                List<FeatureMasterResponseVM> lstFeatures = new List<FeatureMasterResponseVM>();
                readFeatureJson(lstFeatures);
                response = assignActions(response, lstFeatures);
                HttpContext.Session.SetSessionUser(response);
            }
            else
            {
                var lstErrors = JsonConvert.DeserializeObject<ErrorResponseVM>(apiResponse?.Error?.Content);
                string msg = "";
                foreach (var singleError in lstErrors.Errors)
                {
                    if (!string.IsNullOrEmpty(singleError.FieldName))
                    {
                        msg += singleError.FieldName + ": " + singleError.Message + "<br />";
                    }
                }
                TempData["alertMsg"] = msg;
                return View();
            }
            if (!string.IsNullOrEmpty(ReturnUrl) && ReturnUrl != "/")
            {
                return Redirect(ReturnUrl);
            }
            else if (response.IsAdmin)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                var adminHome = response.UserFeatures.Where(x => x.FeatureId == "FEA00007").FirstOrDefault();
                return RedirectToAction(adminHome.ActionName, adminHome.ControllerName);
            }

        }

        private void readFeatureJson(List<FeatureMasterResponseVM> lstFeatures)
        {
            string featureJson = string.Empty;
            string version = versionSettings.Value.VersionName;
            if (string.IsNullOrEmpty(version))
            {
                featureJson = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "features.json"));
            }
            else
            {
                featureJson = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "features", version, "features.json"));
            }

            var objFeatureJson = JObject.Parse(featureJson);
            var mainMenus = objFeatureJson.Values();
            foreach (var singleMenu in mainMenus)
            {
                var menuProp = objFeatureJson.Value<JObject>(singleMenu.Path).Properties();

                var menuDictonary = menuProp.ToDictionary(
                    k => k.Name,
                    v => v.Value.ToString()
                );

                var json = JsonConvert.SerializeObject(menuDictonary, Formatting.Indented);
                var objFeatures = JsonConvert.DeserializeObject<FeatureMasterResponseVM>(json);
                lstFeatures.Add(objFeatures);
            }
        }

        private AuthSuccessResponseVM assignActions(AuthSuccessResponseVM response, List<FeatureMasterResponseVM> lstFeatures)
        {
            List<string> removeMenus = new List<string>();
            foreach (FeatureMasterResponseVM singleMenu in response.UserFeatures)
            {
                FeatureMasterResponseVM objJson = lstFeatures.Where(x => x.FeatureId == singleMenu.FeatureId).SingleOrDefault();
                if (objJson != null)
                {
                    singleMenu.ControllerName = objJson.ControllerName;
                    singleMenu.ActionName = objJson.ActionName;
                    singleMenu.CssClass = objJson.CssClass;
                    singleMenu.IconName = objJson.IconName;
                }
                else
                {
                    removeMenus.Add(singleMenu.FeatureId);
                }
            }

            foreach (string menu in removeMenus)
            {
                var menuToRemove = response.UserFeatures.ToList().Where(x => x.FeatureId == menu).FirstOrDefault();
                response.UserFeatures.Remove(menuToRemove);
            }

            return response;
        }

    }
}
