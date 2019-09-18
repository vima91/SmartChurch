using System;
using Microsoft.AspNetCore.Mvc;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Services;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public ActionResult<string> SendEmail([FromBody]SendEmailDto dto)
        {
            return _notificationService.SendEmail(dto);
        }
    }
}