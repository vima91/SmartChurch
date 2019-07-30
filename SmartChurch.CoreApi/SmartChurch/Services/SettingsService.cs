using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services
{
    public class SettingsService
    {
        public readonly ISiriusRepository<Country, CountryDto> CountryRepo;
        public readonly ISiriusRepository<MarriageType, MarriageTypeDto> MarriageTypeRepo;
        public readonly ISiriusRepository<MaritalStatus, MaritalStatusDto> MaritalStatusRepo;
        public readonly ISiriusRepository<ReligiousBackground, ReligiousBackgroundDto> ReligiousBackgroundRepo;
        public readonly ISiriusRepository<BaptismType, BaptismTypeDto> BaptismTypeRepo;
        public readonly ISiriusRepository<ServiceType, ServiceTypeDto> ServiceTypeRepo;
        public readonly ISiriusRepository<ExpenseType, ExpenseTypeDto> ExpenseTypeRepo;
        public readonly ISiriusRepository<Grade, GradeDto> GradeRepo;
        public readonly ISiriusRepository<AppSettings, AppSettingsDto> AppSettingsRepo;

        public SettingsService(SiriusDbContext context, IMapper mapper)
        {
            CountryRepo = new SiriusRepository<Country, CountryDto>(context, mapper);
            MarriageTypeRepo = new SiriusRepository<MarriageType, MarriageTypeDto>(context, mapper);
            MaritalStatusRepo = new SiriusRepository<MaritalStatus, MaritalStatusDto>(context, mapper);
            ReligiousBackgroundRepo = new SiriusRepository<ReligiousBackground, ReligiousBackgroundDto>(context, mapper);
            BaptismTypeRepo = new SiriusRepository<BaptismType, BaptismTypeDto>(context, mapper);
            ServiceTypeRepo = new SiriusRepository<ServiceType, ServiceTypeDto>(context, mapper);
            ExpenseTypeRepo = new SiriusRepository<ExpenseType, ExpenseTypeDto>(context, mapper);
            GradeRepo = new SiriusRepository<Grade, GradeDto>(context, mapper);
            AppSettingsRepo = new SiriusRepository<AppSettings, AppSettingsDto>(context, mapper);
        }
    }
}