using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Exceptions;

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
            var services = new List<ServiceDto>();
            services.AddRange(nonWeeklyServices);
            services.AddRange(weeklyServices);
            return services;
        }
    }
}