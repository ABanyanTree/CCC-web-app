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
        private readonly IPetDataNotificationService _iPetDataNotificationService;

        public PetServiceController(IPetServices petServices, IPetDataNotificationService PetDataNotificationService)
        {
            _iPetService = petServices;
            _iPetDataNotificationService = PetDataNotificationService;
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

        [HttpPost(ApiRoutes.PetServicesDetails.ChangePetCenters), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        [ProducesResponseType(typeof(List<ErrorLogs>), statusCode: 401)]
        [ProducesResponseType(typeof(List<ErrorLogs>), statusCode: 400)]
        public async Task<IActionResult> ChangePetCenters([FromBody] PetServiceDetails request)
        {
            var count = await _iPetService.ChangePetCenters(request);
            return Ok(count);
        }

        [HttpGet(ApiRoutes.PetServicesDetails.GetVetReport)]
        [ProducesResponseType(typeof(List<PetServiceDetails>), statusCode: 200)]
        public async Task<IActionResult> GetVetReport(PetServiceDetails searchRequest)
        {
            var objResponse = await _iPetService.GetVetReport(searchRequest);
            return Ok(objResponse);
        }

        [HttpGet(ApiRoutes.PetServicesDetails.GetCenterMgrDashboardList)]
        [ProducesResponseType(typeof(List<PetServiceDetails>), statusCode: 200)]
        public async Task<IActionResult> GetCenterMgrDashboardList(PetServiceDetails searchRequest)
        {
            var objResponse = await _iPetService.GetCenterMgrDashboardList(searchRequest);
            return Ok(objResponse);
        }

        [HttpPost(ApiRoutes.PetServicesDetails.AddPetDataNotification), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(string), statusCode: 200)]
        public async Task<IActionResult> AddPetDataNotification([FromBody] PetDataNotification request)
        {
            var successCount = await _iPetDataNotificationService.AddEditAsync(request);
            return Ok(successCount);
        }
        [HttpGet(ApiRoutes.PetServicesDetails.ReadPetDataByUser), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(List<PetDataNotification>), statusCode: 200)]
        public async Task<IActionResult> ReadPetDataByUser(string userId, bool IsAdmin)
        {
            var response = await _iPetDataNotificationService.ReadPetDataByUser(userId, IsAdmin);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.PetServicesDetails.GetPetUnReadData), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(PetDataNotification), statusCode: 200)]
        public async Task<IActionResult> GetPetUnReadData(string userId, bool IsAdmin)
        {
            var response = await _iPetDataNotificationService.GetPetUnReadData(userId, IsAdmin);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.PetServicesDetails.GetPetCountDetails), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(List<PetServiceDetails>), statusCode: 200)]
        public async Task<IActionResult> GetPetCountDetails()
        {
            var response = await _iPetService.GetPetCountDetails();
            return Ok(response);
        }


        [HttpGet(ApiRoutes.PetServicesDetails.GetCenterReportData), DisableRequestSizeLimit]
        [ProducesResponseType(typeof(PetDataNotification), statusCode: 200)]
        public async Task<IActionResult> GetCenterReportData(PetServiceDetails searchRequest)
        {
            var objResponse = await _iPetService.GetCenterReportData(searchRequest);
            return Ok(objResponse);
        }

    }
}
