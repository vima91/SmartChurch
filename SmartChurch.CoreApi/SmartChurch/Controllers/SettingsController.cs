using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingsController : Controller
    {
        private readonly SettingsService _settingsService;

        public SettingsController(SiriusDbContext context, IMapper mapper)
        {
            _settingsService = new SettingsService(context, mapper);
        }

        #region Country

        [HttpGet]
        public ActionResult<IEnumerable<CountryDto>> Countries()
        {
            return Ok(_settingsService.CountryRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CountryDto> Country(int id)
        {
            var res = _settingsService.CountryRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<CountryDto> CreateCountry([FromBody] CountryDto dto)
        {
            return Ok(_settingsService.CountryRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<CountryDto> UpdateCountry(int id, [FromBody] CountryDto dto)
        {
            try
            {
                return Ok(_settingsService.CountryRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteCountry(int id)
        {
            try
            {
                _settingsService.CountryRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Marriage Type

        [HttpGet]
        public ActionResult<IEnumerable<MarriageTypeDto>> MarriageTypes()
        {
            return Ok(_settingsService.MarriageTypeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MarriageTypeDto> MarriageType(int id)
        {
            var res = _settingsService.MarriageTypeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<MarriageTypeDto> CreateMarriageType([FromBody] MarriageTypeDto dto)
        {
            return Ok(_settingsService.MarriageTypeRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<MarriageTypeDto> UpdateMarriageType(int id, [FromBody] MarriageTypeDto dto)
        {
            try
            {
                return Ok(_settingsService.MarriageTypeRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteMarriageType(int id)
        {
            try
            {
                _settingsService.MarriageTypeRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Marital Status

        [HttpGet]
        public ActionResult<IEnumerable<MaritalStatusDto>> MaritalStatuses()
        {
            return Ok(_settingsService.MaritalStatusRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MaritalStatusDto> MaritalStatus(int id)
        {
            var res = _settingsService.MaritalStatusRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<MaritalStatusDto> CreateMaritalStatus([FromBody] MaritalStatusDto dto)
        {
            return Ok(_settingsService.MaritalStatusRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<MaritalStatusDto> UpdateMaritalStatus(int id, [FromBody] MaritalStatusDto dto)
        {
            try
            {
                return Ok(_settingsService.MaritalStatusRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteMaritalStatus(int id)
        {
            try
            {
                _settingsService.MaritalStatusRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Religious Background

        [HttpGet]
        public ActionResult<IEnumerable<ReligiousBackgroundDto>> ReligiousBackgrounds()
        {
            return Ok(_settingsService.ReligiousBackgroundRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ReligiousBackgroundDto> ReligiousBackground(int id)
        {
            var res = _settingsService.ReligiousBackgroundRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ReligiousBackgroundDto> CreateReligiousBackground([FromBody] ReligiousBackgroundDto dto)
        {
            return Ok(_settingsService.ReligiousBackgroundRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<ReligiousBackgroundDto> UpdateReligiousBackground(int id, [FromBody] ReligiousBackgroundDto dto)
        {
            try
            {
                return Ok(_settingsService.ReligiousBackgroundRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteReligiousBackground(int id)
        {
            try
            {
                _settingsService.ReligiousBackgroundRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Baptism Type

        [HttpGet]
        public ActionResult<IEnumerable<BaptismTypeDto>> BaptismTypes()
        {
            return Ok(_settingsService.BaptismTypeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BaptismTypeDto> BaptismType(int id)
        {
            var res = _settingsService.BaptismTypeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<BaptismTypeDto> CreateBaptismType([FromBody] BaptismTypeDto dto)
        {
            return Ok(_settingsService.BaptismTypeRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<BaptismTypeDto> UpdateBaptismType(int id, [FromBody] BaptismTypeDto dto)
        {
            try
            {
                return Ok(_settingsService.BaptismTypeRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteBaptismType(int id)
        {
            try
            {
                _settingsService.BaptismTypeRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Service Type

        [HttpGet]
        public ActionResult<IEnumerable<ServiceTypeDto>> ServiceTypes()
        {
            return Ok(_settingsService.ServiceTypeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceTypeDto> ServiceType(int id)
        {
            var res = _settingsService.ServiceTypeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ServiceTypeDto> CreateServiceType([FromBody] ServiceTypeDto dto)
        {
            return Ok(_settingsService.ServiceTypeRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<ServiceTypeDto> UpdateServiceType(int id, [FromBody] ServiceTypeDto dto)
        {
            try
            {
                return Ok(_settingsService.ServiceTypeRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteServiceType(int id)
        {
            try
            {
                _settingsService.ServiceTypeRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Expense Type

        [HttpGet]
        public ActionResult<IEnumerable<ExpenseTypeDto>> ExpenseTypes()
        {
            return Ok(_settingsService.ExpenseTypeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ExpenseTypeDto> ExpenseType(int id)
        {
            var res = _settingsService.ExpenseTypeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ExpenseTypeDto> CreateExpenseType([FromBody] ExpenseTypeDto dto)
        {
            return Ok(_settingsService.ExpenseTypeRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<ExpenseTypeDto> UpdateExpenseType(int id, [FromBody] ExpenseTypeDto dto)
        {
            try
            {
                return Ok(_settingsService.ExpenseTypeRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteExpenseType(int id)
        {
            try
            {
                _settingsService.ExpenseTypeRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Grade

        [HttpGet]
        public ActionResult<IEnumerable<GradeDto>> Grades()
        {
            return Ok(_settingsService.GradeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<GradeDto> Grade(int id)
        {
            var res = _settingsService.GradeRepo.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<GradeDto> CreateGrade([FromBody] GradeDto dto)
        {
            return Ok(_settingsService.GradeRepo.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<GradeDto> UpdateGrade(int id, [FromBody] GradeDto dto)
        {
            try
            {
                return Ok(_settingsService.GradeRepo.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteGrade(int id)
        {
            try
            {
                _settingsService.GradeRepo.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region App Settings

        [HttpGet]
        public ActionResult<AppSettingsDto> AppSettings()
        {
            //Should always get only one record.
            return Ok(_settingsService.AppSettingsRepo.GetAll().First());
        }

        [HttpPost]
        public ActionResult<AppSettingsDto> UpdateAppSettings([FromBody] AppSettingsDto dto)
        {
            try
            {
                return Ok(_settingsService.AppSettingsRepo.Update(1, dto));
            }
            catch (Exception e)
            {
                return NotFound($"Problem updating app settings, error occured: \n{e.Message}");
            }
        }

        #endregion
    }
}