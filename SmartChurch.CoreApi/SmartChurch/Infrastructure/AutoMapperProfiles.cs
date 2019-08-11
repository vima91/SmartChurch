using AutoMapper;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace SmartChurch.Infrastructure
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<IdentityUser, AppUserDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<MarriageType, MarriageTypeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<MaritalStatus, MaritalStatusDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<ReligiousBackground, ReligiousBackgroundDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<BaptismType, BaptismTypeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<ServiceType, ServiceTypeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<Grade, GradeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<AppSettings, AppSettingsDto>().ReverseMap().IgnoreAuditingFields();

            CreateMap<Person, VisitReminderDto>().ReverseMap().IgnoreAuditingFields();
            CreateMap<Person, BirthdayReminderDto>().ReverseMap().IgnoreAuditingFields();
            CreateMap<Person, MarriageAnniversaryReminderDto>().ReverseMap().IgnoreAuditingFields();
            CreateMap<Person, PersonDto>().ReverseMap().IgnoreDeletableAuditingFields();

            CreateMap<Income, IncomeDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<Expense, ExpenseDto>().ReverseMap().IgnoreDeletableAuditingFields();

            CreateMap<Service, ServiceDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<ServiceLeader, ServiceLeaderDto>().ReverseMap().IgnoreDeletableAuditingFields();
            CreateMap<ServiceSubscription, ServiceSubscriptionDto>().ReverseMap().IgnoreDeletableAuditingFields();

            CreateMap<Attendance, AttendanceDto>().ReverseMap().IgnoreAuditingFields();
        }
    }
}