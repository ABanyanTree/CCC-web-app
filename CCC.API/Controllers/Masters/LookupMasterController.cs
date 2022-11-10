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
    public class LookupMasterController : Controller
    {
        private readonly ILookupMasterService _iLookupMasterService;

        public LookupMasterController(ILookupMasterService LookupMasterService)
        {
            _iLookupMasterService = LookupMasterService;
        }

        [HttpGet(ApiRoutes.LookupMaster.GetLookupByType)]
        [ProducesResponseType(typeof(LookupMaster), statusCode: 200)]
        public async Task<IActionResult> GetLookupByType(string lookupType)
        {
            var objResponse = await _iLookupMasterService.GetLookupByType(lookupType);
            return Ok(objResponse);
        }
    }
}
