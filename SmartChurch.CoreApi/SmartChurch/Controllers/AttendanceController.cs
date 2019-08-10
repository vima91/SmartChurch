using System.Collections.Generic;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Services;
using SmartChurch.Services.ChurchServices;
using Microsoft.AspNetCore.Mvc;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(SiriusDbContext context, IMapper mapper,
            PersonService personService, ChurchServicesService churchServicesService, ServiceSubscriptionService serviceSubscriptionService)
        {
            _attendanceService = new AttendanceService(context, mapper, personService, churchServicesService, serviceSubscriptionService);
        }

        [HttpGet("{serviceId}")]
        public ActionResult<IEnumerable<AttendanceDto>> AttendancesByService(int serviceId)
        {
            return Ok(_attendanceService.GetAllByService(serviceId));
        }
        
        [HttpPost("{id}")]
        public ActionResult<AttendanceDto> UpdateAttendance(int id, [FromBody] AttendanceDto dto)
        {
            try
            {
                return Ok(_attendanceService.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }
    }
}