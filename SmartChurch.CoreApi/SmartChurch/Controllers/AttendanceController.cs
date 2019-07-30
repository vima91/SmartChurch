using System;
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
            PersonService personService, ChurchServicesService churchServicesService)
        {
            _attendanceService = new AttendanceService(context, mapper, personService, churchServicesService);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceDto>> Attendances()
        {
            return Ok(_attendanceService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AttendanceDto> Attendance(int id)
        {
            var res = _attendanceService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<AttendanceDto> CreateAttendance([FromBody] AttendanceDto dto)
        {
            AttendanceDto createdDto;

            try
            {
                createdDto = _attendanceService.Create(dto);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(createdDto);
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

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteAttendance(int id)
        {
            try
            {
                _attendanceService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }
    }
}