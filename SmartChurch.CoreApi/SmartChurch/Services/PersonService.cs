using System;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services
{
    public class PersonService : SiriusRepository<Person, PersonDto>
    {
        public PersonService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override PersonDto Create(PersonDto dto)
        {
            var lastYear = DateTime.Now.AddYears(-1).Year;

            var entity = Mapper.Map<Person>(dto);

            entity.LastVisitYearOfMarriageAnniversary = lastYear;
            entity.LastVisitYearOfBirthday = lastYear;
            entity.LastVisitDate = DateTime.Now.AddMonths(-1);

            Context.Set<Person>().Add(entity);
            Context.SaveChanges();
            return Mapper.Map<PersonDto>(entity);
        }
    }
}