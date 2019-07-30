using System;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.Services
{
    public class ExpenseService : SiriusRepository<Expense, ExpenseDto>
    {
        public ExpenseService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override ExpenseDto Create(ExpenseDto dto)
        {
            dto.ExpenseDate = DateTime.Now;
            return base.Create(dto);
        }
    }
}