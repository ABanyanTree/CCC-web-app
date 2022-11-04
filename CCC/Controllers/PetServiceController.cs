using CCC.UI.RefitClientFactory;
using CCC.UI.Utility;
using CCC.UI.ViewModels;
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


            var centerRes = await CenterMasterAPI.GetAllCenters();
            ViewBag.lstCenter = new SelectList(centerRes.Content, "CenterId", "CenterName");

            var cityAreaRes = await CityAreaMasterAPI.GetAllCityAreas();
            ViewBag.lstCityArea = new SelectList(cityAreaRes.Content, "AreaId", "AreaName");

            var vetRes = await VetMasterAPI.GetAllVetDetails();
            ViewBag.lstVet = new SelectList(vetRes.Content, "VetId", "VetName");

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
