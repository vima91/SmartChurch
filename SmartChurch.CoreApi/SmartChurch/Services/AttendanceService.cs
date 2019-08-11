using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Services.ChurchServices;

namespace SmartChurch.Services
{
    public class AttendanceService : SiriusRepository<Attendance, AttendanceDto>
    {
        private readonly PersonService _personService;
        private readonly ChurchServicesService _churchServicesService;
        private readonly ServiceSubscriptionService _serviceSubscriptionService;

        public AttendanceService(SiriusDbContext context, IMapper mapper,
            PersonService personService, ChurchServicesService churchServicesService, ServiceSubscriptionService serviceSubscriptionService) : base(context, mapper)
        {
            _personService = personService;
            _churchServicesService = churchServicesService;
            _serviceSubscriptionService = serviceSubscriptionService;
        }

        public override AttendanceDto Update(int id, AttendanceDto dto)
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

            if (id == 0)
            {
                dto = Create(dto);
                id = dto.Id;
                dto.IsAttended = true;
                Context.SaveChanges();
                return dto;
            }
            else if (!dto.IsAttended)
            {
                var thisAttendance = Context.Attendances.Single(s => s.Id == id);
                Context.Attendances.Remove(thisAttendance);
                Context.SaveChanges();
                return new AttendanceDto();
            }

            var existingAttendance = GetById(id);

            if (existingAttendance != null)
            {
                if (dto.Comment != existingAttendance.Comment)
                {
                    return base.Update(id, dto);
                }
            }

            return base.Update(id, dto);
        }

        public List<AttendanceDto> GetAllByService(int serviceId)
        {
            var attendances = new List<AttendanceDto>();
            var services = _churchServicesService.GetUpcomingServices();
            var thisService = services.SingleOrDefault(s => s.Id == serviceId);
            if (thisService == null)
            {
                throw new ServiceException();
            }

            var subscribedPeople = _serviceSubscriptionService.GetAllByServiceId(serviceId);

            var availableAttendancesByService = Context.Attendances
                .Where(s => s.ServiceId == serviceId);

            var availableAttendances = availableAttendancesByService.Where(s =>
                s.DateOfEvent >= thisService.From &&
                s.DateOfEvent <= thisService.To);

            foreach (var dto in subscribedPeople)
            {
                var thisPersonAttendance = availableAttendances.SingleOrDefault(s => s.PersonId == dto.PersonId);

                var thisAttendance = new AttendanceDto();

                if (thisPersonAttendance != null)
                {
                    thisAttendance.Id = thisPersonAttendance.Id;
                    thisAttendance.IsAttended = true;
                    thisAttendance.Comment = thisPersonAttendance.Comment;
                }
                else
                {
                    thisAttendance.IsAttended = false;
                }

                thisAttendance.DateOfEvent = thisService.From;
                thisAttendance.PersonId = dto.PersonId;
                thisAttendance.ServiceId = dto.ServiceId;
                thisAttendance.PersonName = dto.PersonName;
                thisAttendance.ServiceName = dto.ServiceName;

                attendances.Add(thisAttendance);
            }

            return attendances;
        }
    }
}