using CCC.API.ApiPath;
using CCC.API.Filters;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Controllers
{
    public class VanMasterController : Controller
    {
        private readonly IVanMasterService _iVanMasterService;

        public VanMasterController(IVanMasterService VanMasterService)
        {
            _iVanMasterService = VanMasterService;
        }


        [HttpPost(ApiRoutes.VanMaster.AddEditVanDetail), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> AddEditVanDetail([FromBody] VanMaster request)
        {
            var centerId = await _iVanMasterService.AddEditVanDetails(request);
            return Ok(centerId);

        }


        [HttpGet(ApiRoutes.VanMaster.GetVanDetail)]
        [ProducesResponseType(typeof(VanMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> GetVanDetail([FromQuery] string vanId)
        {
            var objResponse = await _iVanMasterService.GetAsync(new VanMaster { VanId = vanId });
            return Ok(objResponse);
        }



        [HttpDelete(ApiRoutes.VanMaster.DeleteVan)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> DeleteVan([FromQuery] string vanId)
        {
            var objResponse = await _iVanMasterService.DeleteAsync(new VanMaster { VanId = vanId });
            return Ok(objResponse);
        }




        [HttpGet(ApiRoutes.VanMaster.GetAllVanDetailList)]
        [ProducesResponseType(typeof(VanMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> GetAllVanDetailList(VanMaster request)
        {
            var objResponse = await _iVanMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.VanMaster.IsVanNumberInUse)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
       // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> IsVanNumberInUse([FromQuery] string vanNumber)
        {
            //if (string.IsNullOrEmpty(CountryName))
            //{
            //    return ReturnErrorIfUserIDIsEmpty("CountryName");
            //}

            var user = await _iVanMasterService.IsVanNumberInUse(vanNumber);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }



        [HttpGet(ApiRoutes.VanMaster.GetAllVansDetails)]
        [ProducesResponseType(typeof(VanMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        public async Task<IActionResult> GetAllVansDetails()
        {
            var objResponse = await _iVanMasterService.GetAllVansDetails();
            return Ok(objResponse);
        }



        [HttpGet(ApiRoutes.VanMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string vanId)
        {
            var objResponse = await _iVanMasterService.IsInUseCount(vanId);
            return Ok(objResponse.TotalCount);
        }
    }
}
