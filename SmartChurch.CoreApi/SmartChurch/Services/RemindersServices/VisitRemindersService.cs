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
    public class VisitRemindersService : SiriusRepository<Person, VisitReminderDto>
    {
        public VisitRemindersService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<VisitReminderDto> GetAll()
        {
            
            return Mapper.Map<List<VisitReminderDto>>(
                Context
                    .Set<Person>()
                    .Where(IsNotDeletedExpression)
                    .Where(s => s.LastVisitDate.Value.AddDays(30) < DateTime.Now));
        }

        public override VisitReminderDto Update(int id, VisitReminderDto dto)
        {
            var existingEntity = Context.Set<Person>().FirstOrDefault(s => !s.IsDeleted() && s.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Cannot find entity to update");
            }

            existingEntity.LastVisitDate = DateTime.Now;

            Context.SaveChanges();

            return Mapper.Map<VisitReminderDto>(existingEntity);
        }
    }
}