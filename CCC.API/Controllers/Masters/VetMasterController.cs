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
    public class VetMasterController : Controller
    {
        private readonly IVetMasterService _iVetMasterService;

        public VetMasterController(IVetMasterService VetMasterService)
        {
            _iVetMasterService = VetMasterService;
        }


        [HttpPost(ApiRoutes.VetMaster.AddEditVetDetail), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> AddEditVetDetail([FromBody] VetMaster request)
        {
            var areaId = await _iVetMasterService.AddEditVetDetail(request);
            return Ok(areaId);

        }


        [HttpGet(ApiRoutes.VetMaster.GetVetDetail)]
        [ProducesResponseType(typeof(VetMaster), statusCode: 200)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> GetVetDetail([FromQuery] string vetId)
        {
            var objResponse = await _iVetMasterService.GetAsync(new VetMaster { VetId = vetId });
            return Ok(objResponse);
        }


        [HttpDelete(ApiRoutes.VetMaster.DeleteVet)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> DeleteVet([FromQuery] string vetId)
        {
            var objResponse = await _iVetMasterService.DeleteAsync(new VetMaster { VetId = vetId });
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.VetMaster.GetAllVetList)]
        [ProducesResponseType(typeof(VetMaster), statusCode: 200)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> GetAllVetList(VetMaster request)
        {
            var objResponse = await _iVetMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.VetMaster.IsVetNameInUse)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> IsVetNameInUse([FromQuery] string vetName)
        {
            //if (string.IsNullOrEmpty(CountryName))
            //{
            //    return ReturnErrorIfUserIDIsEmpty("CountryName");
            //}

            var user = await _iVetMasterService.IsVetNameInUse(vetName);
            if (user == null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }

        }


        [HttpGet(ApiRoutes.VetMaster.GetAllVetDetails)]
        [ProducesResponseType(typeof(VetMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        public async Task<IActionResult> GetAllVetDetails()
        {
            var objResponse = await _iVetMasterService.GetAllVetDetails();
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.VetMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageVet)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string vetId)
        {
            var objResponse = await _iVetMasterService.IsInUseCount(vetId);
            return Ok(objResponse.TotalCount);
        }
    }
}
