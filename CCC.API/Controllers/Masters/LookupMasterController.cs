using CCC.API.ApiPath;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CCC.API.Controllers.Masters
{
	public class LookupMasterController : Controller
    {
        private readonly ILookupMasterService _iLookupMasterService;

        public LookupMasterController(ILookupMasterService LookupMasterService)
        {
            _iLookupMasterService = LookupMasterService;
        }

        [HttpPost(ApiRoutes.LookupMaster.AddEditLookup), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> AddEditLookup([FromBody] LookupMaster request)
        {
            var areaId = await _iLookupMasterService.AddEditLookup(request);
            return Ok(areaId);

        }

        [HttpGet(ApiRoutes.LookupMaster.GetLookup)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> GetLookup([FromQuery] string lookupId)
        {
            var objResponse = await _iLookupMasterService.GetAsync(new LookupMaster { LookupId = lookupId });
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.LookupMaster.GetAllLookupList)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        public async Task<IActionResult> GetAllLookupList(LookupMaster request)
        {
            var objResponse = await _iLookupMasterService.GetAllLookupList(request);
            return Ok(objResponse);
        }
        [HttpGet(ApiRoutes.LookupMaster.GetLookupByType)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        public async Task<IActionResult> GetLookupByType(string lookupType)
        {
            var objResponse = await _iLookupMasterService.GetLookupByType(lookupType);
            return Ok(objResponse);
        }

        [HttpGet(ApiRoutes.LookupMaster.IsLookupNameInUse)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> IsLookupNameInUse([FromQuery] string lookupValue)
        {
            var objResponse = await _iLookupMasterService.IsLookupNameInUse(lookupValue);
            return Ok(objResponse);

        }

        [HttpGet(ApiRoutes.LookupMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string lookupId)
        {
            var objResponse = await _iLookupMasterService.IsInUseCount(lookupId);
            return Ok(objResponse.TotalCount);
        }

        [HttpDelete(ApiRoutes.LookupMaster.DeleteLookup)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> DeleteCityArea([FromQuery] string lookupId)
        {
            var objResponse = await _iLookupMasterService.DeleteAsync(new LookupMaster { LookupId = lookupId });
            return Ok(objResponse);
        }


        [HttpGet(ApiRoutes.LookupMaster.GetLookupTypes)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        public async Task<IActionResult> GetLookupTypes()
        {
            var objResponse = await _iLookupMasterService.GetLookupTypes();
            return Ok(objResponse);
        }

    }
}
