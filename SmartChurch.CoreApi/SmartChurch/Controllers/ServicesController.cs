using System;
using SmartChurch.DataModel.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Services;
using SmartChurch.Services.ChurchServices;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private readonly ChurchServicesService _churchServicesService;
        private readonly ServiceLeaderService _serviceLeaderService;
        private readonly ServiceSubscriptionService _serviceSubscriptionService;

        public ServicesController(SiriusDbContext context, IMapper mapper,
               PersonService personService, ChurchServicesService churchServicesService)
        {
            _churchServicesService = new ChurchServicesService(context, mapper);
            _serviceLeaderService = new ServiceLeaderService(context, mapper, personService, churchServicesService);
            _serviceSubscriptionService = new ServiceSubscriptionService(context, mapper, personService, churchServicesService);
        }

        #region Service

        #region Service Queries

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> UpcomingServices()
        {
            return Ok(_churchServicesService.GetUpcomingServices());
        }

        #endregion

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> Services()
        {
            var services = _churchServicesService.GetAll();
            foreach (var service in services)
            {
                if (service.Weekday != null)
                {
                    DayOfWeek dayOfWeek = (DayOfWeek) service.Weekday;
                    service.DayOfWeek = dayOfWeek.ToString();
                }
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceDto> Service(int id)
        {
            var res = _churchServicesService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ServiceDto> CreateService([FromBody] ServiceDto dto)
        {
            ServiceDto createdDto;
            try
            {
                createdDto = _churchServicesService.Create(dto);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadDtoException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(createdDto);
        }

        [HttpPost("{id}")]
        public ActionResult<ServiceDto> UpdateService(int id, [FromBody] ServiceDto dto)
        {
            try
            {
                return Ok(_churchServicesService.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
            catch (BadDtoException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteService(int id)
        {
            try
            {
                _churchServicesService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Service Leader

        [HttpGet]
        public ActionResult<IEnumerable<ServiceLeaderDto>> ServiceLeaders()
        {
            return Ok(_serviceLeaderService.GetAll());
        }

        [HttpGet("{serviceId}")]
        public ActionResult<IEnumerable<ServiceLeaderDto>> ServiceLeadersByService(int serviceId)
        {
            return Ok(_serviceLeaderService.Find(s => s.ServiceId == serviceId));
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceLeaderDto> GetServiceLeader(int id)
        {
            var res = _serviceLeaderService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ServiceLeaderDto> CreateServiceLeader([FromBody] ServiceLeaderDto dto)
        {
            ServiceLeaderDto createdDto;
            try
            {
                createdDto = _serviceLeaderService.Create(dto);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(createdDto);
        }

        [HttpPost("{id}")]
        public ActionResult<ServiceLeaderDto> UpdateServiceLeader(int id, [FromBody] ServiceLeaderDto dto)
        {
            try
            {
                return Ok(_serviceLeaderService.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteServiceLeader(int id)
        {
            try
            {
                _serviceLeaderService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion

        #region Service Subscription

        [HttpGet]
        public ActionResult<IEnumerable<ServiceSubscriptionDto>> ServiceSubscriptions()
        {
            return Ok(_serviceSubscriptionService.GetAll());
        }

        [HttpGet("{serviceId}")]
        public ActionResult<IEnumerable<ServiceSubscriptionDto>> ServiceSubscriptionsByService(int serviceId)
        {
            return Ok(_serviceSubscriptionService.Find(s => s.ServiceId == serviceId));
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceSubscriptionDto> GetServiceSubscription(int id)
        {
            var res = _serviceSubscriptionService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<ServiceSubscriptionDto> CreateServiceSubscription([FromBody] ServiceSubscriptionDto dto)
        {
            ServiceSubscriptionDto createdDto;

            try
            {
                createdDto = _serviceSubscriptionService.Create(dto);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(createdDto);
        }

        [HttpPost("{id}")]
        public ActionResult<ServiceSubscriptionDto> UpdateServiceSubscription(int id, [FromBody] ServiceSubscriptionDto dto)
        {
            try
            {
                return Ok(_serviceSubscriptionService.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeleteServiceSubscription(int id)
        {
            try
            {
                _serviceSubscriptionService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        #endregion
    }
}