using CCC.API.ApiPath;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CCC.API.Controllers.Masters
{
	public class CityAreaMasterController : Controller
    {
        private readonly ICityAreaMasterService _iCityAreaMasterService;

        public CityAreaMasterController(ICityAreaMasterService CityAreaMasterService)
        {
            _iCityAreaMasterService = CityAreaMasterService;
        }


        [HttpPost(ApiRoutes.CityAreaMaster.AddEditCityArea), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 401)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> AddEditCityArea([FromBody] CityAreaMaster request)
        {
            var areaId = await _iCityAreaMasterService.AddEditCityArea(request);
            return Ok(areaId);

        }


        [HttpGet(ApiRoutes.CityAreaMaster.GetCityArea)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> GetCityArea([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.GetAsync(new CityAreaMaster { AreaId = areaId });
            return Ok(objResponse);
        }



        [HttpDelete(ApiRoutes.CityAreaMaster.DeleteCityArea)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> DeleteCityArea([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.DeleteAsync(new CityAreaMaster { AreaId = areaId });
            return Ok(objResponse);
        }




        [HttpGet(ApiRoutes.CityAreaMaster.GetAllCityAreaList)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> GetAllCityAreaList(CityAreaMaster request)
        {
            var objResponse = await _iCityAreaMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }



        [HttpGet(ApiRoutes.CityAreaMaster.GetAllCityAreas)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        public async Task<IActionResult> GetAllCityAreas()
        {
            var objResponse = await _iCityAreaMasterService.GetAllCityAreas();
            return Ok(objResponse);
        }



        [HttpGet(ApiRoutes.CityAreaMaster.IsCityAreaNameInUse)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> IsCityAreaNameInUse([FromQuery] string areaName)
        {
            var objResponse = await _iCityAreaMasterService.IsCityAreaNameInUse(areaName);
            return Ok(objResponse);

        }

        [HttpGet(ApiRoutes.CityAreaMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureAccess.FEATURE_ManageCityArea)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.IsInUseCount(areaId);
            return Ok(objResponse.TotalCount);
        }
    }
}
