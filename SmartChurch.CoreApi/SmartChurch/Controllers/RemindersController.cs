using System.Collections.Generic;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Services.RemindersServices;
using Microsoft.AspNetCore.Mvc;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RemindersController : Controller
    {
        private readonly VisitRemindersService _visitRemindersService;
        private readonly BirthdayRemindersService _birthdayRemindersService;
        private readonly MarriageAnniversaryRemindersService _marriageAnniversaryRemindersService;

        public RemindersController(SiriusDbContext context, IMapper mapper)
        {
            _visitRemindersService = new VisitRemindersService(context, mapper);
            _birthdayRemindersService = new BirthdayRemindersService(context, mapper);
            _marriageAnniversaryRemindersService = new MarriageAnniversaryRemindersService(context, mapper);
        }

        #region Visits Reminders

        [HttpGet]
        public ActionResult<IEnumerable<VisitReminderDto>> VisitReminders()
        {
            return Ok(_visitRemindersService.GetAll());
        }

        [HttpPost("{id}")]
        public ActionResult<VisitReminderDto> UpdatePersonLastVisit(int id)
        {
            try
            {
                return Ok(_visitRemindersService.Update(id, null));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Birthday Reminders

        [HttpGet]
        public ActionResult<IEnumerable<BirthdayReminderDto>> BirthdayReminders()
        {
            return Ok(_birthdayRemindersService.GetAll());
        }

        [HttpPost("{id}")]
        public ActionResult<BirthdayReminderDto> UpdatePersonBirthdayLastVisit(int id)
        {
            try
            {
                return Ok(_birthdayRemindersService.Update(id, null));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Marriage Anniversary Reminders

        [HttpGet]
        public ActionResult<IEnumerable<MarriageAnniversaryReminderDto>> MarriageAnniversaryReminders()
        {
            return Ok(_marriageAnniversaryRemindersService.GetAll());
        }

        [HttpPost("{id}")]
        public ActionResult<MarriageAnniversaryReminderDto> UpdatePersonMarriageAnniversaryLastVisit(int id)
        {
            try
            {
                return Ok(_marriageAnniversaryRemindersService.Update(id, null));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        } 

        #endregion
    }
}