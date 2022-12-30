using CCC.API.ApiPath;
using CCC.Domain;
using CCC.Service.Infra.EmailStuff;
using CCC.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CCC.API.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IPetServices _iPetService;
        private readonly ICenterMasterService _iCenterMasterService;
        private readonly IPetDataNotificationService _iPetDataNotificationService;
        private readonly IUserMasterService _iUserMasterService;
        public NotificationController(IPetServices petServices, IPetDataNotificationService PetDataNotificationService,
            ICenterMasterService CenterMasterService, IUserMasterService UserMasterService)
        {
            _iPetService = petServices;
            _iPetDataNotificationService = PetDataNotificationService;
            _iCenterMasterService = CenterMasterService;
            _iUserMasterService = UserMasterService;
        }

        [HttpGet(ApiRoutes.Notification.DailyDataCheck)]
        [ProducesResponseType(typeof(bool), statusCode: 200)]
        public async Task<IActionResult> DailyDataCheck()
        {
            var objResponse = await _iCenterMasterService.DailyDataCheck();
            var admins = await _iUserMasterService.GetAllUsers();
            //EmailSender obj = new EmailSender();
            //var responceObj = obj.SendDailyNotificationToAdmin(objResponse, admins);

            return Ok(objResponse);
        }

    }
}
