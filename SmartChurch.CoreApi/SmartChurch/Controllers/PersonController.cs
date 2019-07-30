using System.Collections.Generic;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly PersonService _personService;

        public PersonController(SiriusDbContext context, IMapper mapper)
        {
            _personService = new PersonService(context, mapper);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> Persons()
        {
            return Ok(_personService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> Person(int id)
        {
            var res = _personService.GetById(id);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPut]
        public ActionResult<PersonDto> CreatePerson([FromBody] PersonDto dto)
        {
            return Ok(_personService.Create(dto));
        }

        [HttpPost("{id}")]
        public ActionResult<PersonDto> UpdatePerson(int id, [FromBody] PersonDto dto)
        {
            try
            {
                return Ok(_personService.Update(id, dto));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> DeletePerson(int id)
        {
            try
            {
                _personService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound($"{e.Message} ID: {id}");
            }
        }
    }
}