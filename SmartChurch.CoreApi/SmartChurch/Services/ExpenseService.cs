using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ExpenseDto> GetExpenses(DateTime? from, DateTime? to)
        {
            if (from == null && to == null)
            {
                return GetAll().ToList();
            }

            if (from == null)
            {
                return GetAll().Where(s => s.ExpenseDate < to).ToList();
            }

            if (to == null)
            {
                return GetAll().Where(s => s.ExpenseDate > @from).ToList();
            }

            return null;
        }
    }
}