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
    public class BirthdayRemindersService : SiriusRepository<Person, BirthdayReminderDto>
    {
        private readonly int _currentYear = DateTime.Now.Year;

        public BirthdayRemindersService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<BirthdayReminderDto> GetAll()
        {
            return Mapper.Map<List<BirthdayReminderDto>>(
                Context
                    .Set<Person>()
                    .Where(IsNotDeletedExpression)
                    .Where(s => s.LastVisitYearOfBirthday < _currentYear 
                                && DateTime.Now >= s.Birthday));
        }

        public override BirthdayReminderDto Update(int id, BirthdayReminderDto dto)
        {
            var existingEntity = Context.Set<Person>().FirstOrDefault(s => !s.IsDeleted() && s.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Cannot find entity to update");
            }

            existingEntity.LastVisitYearOfBirthday = _currentYear;

            Context.SaveChanges();

            return Mapper.Map<BirthdayReminderDto>(existingEntity);
        }
    }
}