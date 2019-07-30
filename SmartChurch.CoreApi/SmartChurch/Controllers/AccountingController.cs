using System;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmartChurch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountingController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly IncomeService _incomeService;
        private readonly ExpenseService _expenseService;

        public AccountingController(SiriusDbContext context, IMapper mapper)
        {
            _transactionService = new TransactionService(context, mapper);
            _incomeService = new IncomeService(context, mapper);
            _expenseService = new ExpenseService(context, mapper);
        }

        [HttpGet]
        public ActionResult<AccountingBalancesDto> GetBalances()
        {
            return Ok(_transactionService.GetCurrentBalances());
        }

        [HttpGet]
        public ActionResult<AccountingBalancesDto> GetBalancesThisMonthOnly()
        {
            return Ok(_transactionService.GetCurrentBalancesThisMonthOnly());
        }

        [HttpPut]
        public ActionResult<IncomeDto> DepositToBank([FromBody] IncomeDto dto)
        {
            var incomeCreationResult = _incomeService.Create(dto);
            _transactionService.CreateIncomeTransaction(incomeCreationResult);
            return Ok(incomeCreationResult);
        }

        [HttpPut]
        public ActionResult<IncomeDto> WithdrawFromBankToChurch([FromBody] WithdrawDto dto)
        {
            try
            {
                _transactionService.CreateWithdrawalTransaction(dto);
            }
            catch (InsufficientFundsInBankBalanceException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult<IncomeDto> CreateExpense([FromBody] ExpenseDto dto)
        {
            try
            {
                _transactionService.CreateExpenseTransaction(dto);
            }
            catch (InsufficientFundsInChurchBalanceException e)
            {
                return BadRequest(e.Message);
            }
            var expenseCreationResult = _expenseService.Create(dto);
            return Ok(expenseCreationResult);
        }
    }
}