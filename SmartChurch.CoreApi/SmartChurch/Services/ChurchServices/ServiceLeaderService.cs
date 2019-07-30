using System.Collections.Generic;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services.ChurchServices
{
    public class ServiceLeaderService : SiriusRepository<ServiceLeader, ServiceLeaderDto>
    {
        private readonly PersonService _personService;
        private readonly ChurchServicesService _churchServicesService;

        public ServiceLeaderService(SiriusDbContext context, IMapper mapper,
               PersonService personService, ChurchServicesService churchServicesService)
            : base(context, mapper)
        {
            _personService = personService;
            _churchServicesService = churchServicesService;
        }

        public override ServiceLeaderDto Create(ServiceLeaderDto dto)
        {
            var person = _personService.GetById(dto.PersonId);
            var service = _churchServicesService.GetById(dto.ServiceId);

            if (person == null)
            {
                throw new KeyNotFoundException($"Person with Id {dto.PersonId} does not exist.");
            }

            if (service == null)
            {
                throw new KeyNotFoundException($"Service with Id {dto.ServiceId} does not exist.");
            }

            return base.Create(dto);
        }
    }
}