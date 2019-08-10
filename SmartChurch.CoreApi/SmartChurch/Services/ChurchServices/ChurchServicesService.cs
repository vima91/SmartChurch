using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Infrastructure.Helpers;

namespace SmartChurch.Services.ChurchServices
{
    public class ChurchServicesService : SiriusRepository<Service, ServiceDto>
    {
        public ChurchServicesService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override ServiceDto Create(ServiceDto dto)
        {
            if (dto.IsWeekly && dto.Weekday == null)
            {
                throw new BadDtoException("Weekly services must have a weekday defined.");
            }

            return base.Create(dto);
        }

        public override ServiceDto Update(int id, ServiceDto dto)
        {
            if (dto.IsWeekly && dto.Weekday == null)
            {
                throw new BadDtoException("Weekly services must have a weekday defined.");
            }

            return base.Update(id, dto);
        }

        public List<ServiceDto> GetUpcomingServices()
        {
            var nonWeeklyServices = base.GetAll().Where(s => !s.IsWeekly && s.To <= DateTime.Now).ToList();
            var weeklyServices = base.GetAll().Where(s => s.IsWeekly).ToList();
            ModifyWeeklyServiceDates(weeklyServices);
            var services = new List<ServiceDto>();
            services.AddRange(nonWeeklyServices);
            services.AddRange(weeklyServices);
            return services;
        }

        private void ModifyWeeklyServiceDates(List<ServiceDto> weeklyServices)
        {
            var thisWeekStartDate = DateTime.UtcNow.StartOfWeek();
            var thisWeekEndDate = DateTime.UtcNow.EndOfWeek();

            foreach (var service in weeklyServices)
            {
                service.From = new DateTime(thisWeekStartDate.Year, thisWeekStartDate.Month, thisWeekStartDate.Day, service.From.Hour, service.From.Minute, service.From.Second);

                service.To = new DateTime(thisWeekEndDate.Year, thisWeekEndDate.Month, thisWeekEndDate.Day, service.To.Hour, service.To.Minute, service.To.Second);
            }
        }
    }
}