using CCC.API.ApiPath;
using CCC.API.Filters;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CCC.API.Controllers.Masters
{
    public class CenterMasterController : Controller
    {
        private readonly ICenterMasterService _iCenterMasterService;

        public CenterMasterController(ICenterMasterService CenterMasterService)
        {
            _iCenterMasterService = CenterMasterService;
        }


        [HttpPost(ApiRoutes.CenterMaster.AddEditCenter), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> AddEditCenter([FromBody] CenterMaster request)
        {
            var centerId = await _iCenterMasterService.AddEditCenter(request);
            return Ok(centerId);

        }


        [HttpGet(ApiRoutes.CenterMaster.GetCenter)]
        [ProducesResponseType(typeof(CenterMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> GetCenter([FromQuery] string centerId)
        {
            var objResponse = await _iCenterMasterService.GetAsync(new CenterMaster { CenterId = centerId });
            return Ok(objResponse);
        }



        [HttpDelete(ApiRoutes.CenterMaster.DeleteCenter)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> DeleteCenter([FromQuery] string centerId)
        {
            var objResponse = await _iCenterMasterService.DeleteAsync(new CenterMaster { CenterId = centerId });
            return Ok(objResponse);
        }




        [HttpGet(ApiRoutes.CenterMaster.GetAllCenterList)]
        [ProducesResponseType(typeof(CenterMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> GetAllCenterList(CenterMaster request)
        {
            var objResponse = await _iCenterMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.CenterMaster.IsCenterNameInUse)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> IsCenterNameInUse([FromQuery] string centerName)
        {
            //if (string.IsNullOrEmpty(CountryName))
            //{
            //    return ReturnErrorIfUserIDIsEmpty("CountryName");
            //}

            var user = await _iCenterMasterService.IsCenterNameInUse(centerName);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }



        [HttpGet(ApiRoutes.CenterMaster.GetAllCenters)]
        [ProducesResponseType(typeof(CenterMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        public async Task<IActionResult> GetAllCenters()
        {
            var objResponse = await _iCenterMasterService.GetAllCenters();
            return Ok(objResponse);
        }



        [HttpGet(ApiRoutes.CenterMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCenter)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string centerId)
        {
            var objResponse = await _iCenterMasterService.IsInUseCount(centerId);
            return Ok(objResponse.TotalCount);
        }
    }
}
