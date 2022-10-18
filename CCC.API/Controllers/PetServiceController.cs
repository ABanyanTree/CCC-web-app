using CCC.API.ApiPath;
using CCC.Domain;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Controllers
{
    public class PetServiceController : Controller
    {
        private readonly IPetServices _iPetService;

        public PetServiceController(IPetServices petServices)
        {
            _iPetService = petServices;
        }

        [HttpPost(ApiRoutes.PetServicesDetails.AddEditPetData), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(List<ErrorLogs>), statusCode: 401)]
        [ProducesResponseType(typeof(List<ErrorLogs>), statusCode: 400)]
        public async Task<IActionResult> AddEditPetData([FromBody] PetServiceDetails request)
        {
            var serviceId = await _iPetService.AddEditPetData(request);
            return Ok(serviceId);
        }

        [HttpGet(ApiRoutes.PetServicesDetails.GetPetData)]
        [ProducesResponseType(typeof(PetServiceDetails), statusCode: 200)]
        public async Task<IActionResult> GetPetData([FromQuery] string serviceId)
        {
            var objResponse = await _iPetService.GetAsync(new PetServiceDetails { ServiceId = serviceId });
            return Ok(objResponse);
        }

        /// <summary>
        /// Get list of all Country
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(ApiRoutes.PetServicesDetails.GetAllPetData)]
        [ProducesResponseType(typeof(List<PetServiceDetails>), statusCode: 200)]
        public async Task<IActionResult> GetAllPetData(PetServiceDetails searchRequest)
        {
            var objResponse = await _iPetService.GetAllAsync(searchRequest);
            return Ok(objResponse);
        }

        [HttpDelete(ApiRoutes.PetServicesDetails.DeletePetData)]
        [ProducesResponseType(typeof(int), statusCode: 200)]
        public async Task<IActionResult> DeletePetData([FromQuery] string serviceId)
        {
            var objResponse = await _iPetService.DeleteAsync(new PetServiceDetails { ServiceId = serviceId });
            return Ok(objResponse);
        }
    }
}
