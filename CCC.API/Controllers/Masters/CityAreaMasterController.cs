using CCC.API.ApiPath;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> AddEditCityArea([FromBody] CityAreaMaster request)
        {
            var areaId = await _iCityAreaMasterService.AddEditCityArea(request);
            return Ok(areaId);

        }


        [HttpGet(ApiRoutes.CityAreaMaster.GetCityArea)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> GetCityArea([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.GetAsync(new CityAreaMaster { AreaId = areaId });
            return Ok(objResponse);
        }



        [HttpDelete(ApiRoutes.CityAreaMaster.DeleteCityArea)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> DeleteCityArea([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.DeleteAsync(new CityAreaMaster { AreaId = areaId });
            return Ok(objResponse);
        }




        [HttpGet(ApiRoutes.CityAreaMaster.GetAllCityAreaList)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> GetAllCityAreaList(CityAreaMaster request)
        {
            var objResponse = await _iCityAreaMasterService.GetAllAsync(request);
            return Ok(objResponse);
        }


        /// <summary>
        /// Check if Country Name Exists
        /// </summary>
        /// <param name="CountryName"></param>
        /// <param name="CountryID"></param> 
        /// <response code="200">True if CountryName does not exists else error message</response>         
        /// <response code="401">Unauthorized</response>
        [HttpGet(ApiRoutes.CityAreaMaster.IsCityAreaNameInUse)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        // [CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> IsCityAreaNameInUse([FromQuery] string areaName)
        {
            //if (string.IsNullOrEmpty(CountryName))
            //{
            //    return ReturnErrorIfUserIDIsEmpty("CountryName");
            //}

            var user = await _iCityAreaMasterService.IsCityAreaNameInUse(areaName);
            if (user == null)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }

        }


        /// <summary>
        /// Get All Country
        /// </summary>   
        /// <returns>Get All Country </returns>
        /// <response code="200">Lists of all Dropdown Values</response>         
        /// <response code="401">Unauthorized</response>
        [HttpGet(ApiRoutes.CityAreaMaster.GetAllCityAreas)]
        [ProducesResponseType(typeof(CityAreaMaster), statusCode: 200)]
        [ProducesResponseType(typeof(ErrorLogs), statusCode: 400)]
        //[CustomAuthorizeAttribute]
        public async Task<IActionResult> GetAllCityAreas()
        {
            var objResponse = await _iCityAreaMasterService.GetAllCityAreas();
            return Ok(objResponse);
        }


        /// <summary>
        ///  Country IsInUseCount
        /// </summary>
        /// <param name="CountryID">Country ID</param>      
        /// <returns></returns>
        [HttpGet(ApiRoutes.CityAreaMaster.IsInUseCount)]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        //[CustomAuthorizeAttribute(FeatureId = FeatureMasterInfra.FEATURE_Country)]
        public async Task<IActionResult> IsInUseCount([FromQuery] string areaId)
        {
            var objResponse = await _iCityAreaMasterService.IsInUseCount(areaId);
            return Ok(objResponse.TotalCount);
        }
    }
}
