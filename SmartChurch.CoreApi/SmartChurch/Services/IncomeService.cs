using System;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services
{
    public class IncomeService : SiriusRepository<Income, IncomeDto>
    {
        public IncomeService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IncomeDto Create(IncomeDto dto)
        {
            dto.ReceiptDate = DateTime.Now;

            return base.Create(dto);
        }
    }
}