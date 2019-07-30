using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Helpers;

namespace SmartChurch.Services.RemindersServices
{
    public class MarriageAnniversaryRemindersService : SiriusRepository<Person, MarriageAnniversaryReminderDto>
    {
        private readonly int _currentYear = DateTime.Now.Year;

        public MarriageAnniversaryRemindersService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<MarriageAnniversaryReminderDto> GetAll()
        {
            
            return Mapper.Map<List<MarriageAnniversaryReminderDto>>(
                Context
                    .Set<Person>()
                    .Where(IsNotDeletedExpression)
                    .Where(s => s.LastVisitYearOfMarriageAnniversary < _currentYear 
                                && DateTime.Now >= s.MarriageAnniversary));
        }

        public override MarriageAnniversaryReminderDto Update(int id, MarriageAnniversaryReminderDto dto)
        {
            var existingEntity = Context.Set<Person>().FirstOrDefault(s => !s.IsDeleted() && s.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Cannot find entity to update");
            }
            
            existingEntity.LastVisitYearOfMarriageAnniversary = _currentYear;

            Context.SaveChanges();

            return Mapper.Map<MarriageAnniversaryReminderDto>(existingEntity);
        }
    }
}