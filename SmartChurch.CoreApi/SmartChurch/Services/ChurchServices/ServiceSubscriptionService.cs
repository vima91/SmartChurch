using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services.ChurchServices
{
    public class ServiceSubscriptionService : SiriusRepository<ServiceSubscription, ServiceSubscriptionDto>
    {
        private readonly PersonService _personService;
        private readonly ChurchServicesService _churchServicesService;
        
        public ServiceSubscriptionService(SiriusDbContext context, IMapper mapper,
            PersonService personService, ChurchServicesService churchServicesService)
            : base(context, mapper)
        {
            _personService = personService;
            _churchServicesService = churchServicesService;
        }

        public override ServiceSubscriptionDto Create(ServiceSubscriptionDto dto)
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

        public List<ServiceSubscriptionDto> GetAllByServiceId(int serviceId)
        {
            var subscriptions = Context.ServiceSubscriptions.Where(s => s.ServiceId == serviceId);
            var mappedSubscriptions = Mapper.Map<List<ServiceSubscriptionDto>>(subscriptions);
            return mappedSubscriptions;
        }
    }
}