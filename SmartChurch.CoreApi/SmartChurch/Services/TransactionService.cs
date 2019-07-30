using System;
using System.Linq;
using AutoMapper;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Dtos;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure;
using SmartChurch.Infrastructure.Exceptions;
using SmartChurch.Infrastructure.Helpers;

namespace SmartChurch.Services
{
    public class TransactionService : SiriusRepository<Income, IncomeDto>
    {
        public TransactionService(SiriusDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public AccountingBalancesDto GetCurrentBalances()
        {
            var balances = new AccountingBalancesDto();

            var latestBankTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.BankAccount);

            var latestChurchTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.ChurchAccount);

            if (latestBankTransaction != null)
            {
                balances.BankBalance = latestBankTransaction.Balance;
            }

            if (latestChurchTransaction != null)
            {
                balances.ChurchBalance = latestChurchTransaction.Balance;
            }

            return balances;
        }

        public AccountingBalancesDto GetCurrentBalancesThisMonthOnly()
        {
            var balances = new AccountingBalancesDto();

            var currentMonthTransactionsForBank = Context.Transactions.Where(t =>
                t.TransactionDate >= DateTime.Now.StartOfMonth()
                && t.TransactionDate <= DateTime.Now.EndOfMonth()
                && t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.BankAccount);

            var currentMonthTransactionsForChurch = Context.Transactions.Where(t =>
                t.TransactionDate >= DateTime.Now.StartOfMonth()
                && t.TransactionDate <= DateTime.Now.EndOfMonth()
                && t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.ChurchAccount);

            if (currentMonthTransactionsForBank.Any())
            {
                var sumOfDebit = currentMonthTransactionsForBank.Sum(s => s.Debit);
                var sumOfCredit = currentMonthTransactionsForBank.Sum(s => s.Credit);
                balances.BankBalance = sumOfDebit - sumOfCredit;
            }
            else
            {
                balances.BankBalance = 0;
            }

            if (currentMonthTransactionsForChurch.Any())
            {
                var sumOfDebit = currentMonthTransactionsForChurch.Sum(s => s.Debit);
                var sumOfCredit = currentMonthTransactionsForChurch.Sum(s => s.Credit);
                balances.ChurchBalance = sumOfDebit - sumOfCredit;
            }
            else
            {
                balances.ChurchBalance = 0;
            }

            return balances;
        }

        public void CreateIncomeTransaction(IncomeDto dto)
        {
            decimal balance = 0;

            var latestBankTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.BankAccount);

            if (latestBankTransaction != null)
            {
                balance = latestBankTransaction.Balance;
            }

            var incomeTransactionDebit = new Transaction
            {
                Debit = dto.Amount,
                Balance = balance + dto.Amount,
                TransactionDate = DateTime.Now,
                TransactionSourceTypeId = (int)SiriusEnums.TransactionSourceTypes.BankAccount
            };

            Context.Transactions.Add(incomeTransactionDebit);

            Context.SaveChanges();
        }

        public void CreateWithdrawalTransaction(WithdrawDto dto)
        {
            decimal bankBalance = 0;
            decimal churchBalance = 0;

            var latestBankTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.BankAccount);

            var latestChurchTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.ChurchAccount);

            if (latestBankTransaction != null)
            {
                bankBalance = latestBankTransaction.Balance;
            }

            if (bankBalance - dto.WithdrawalAmount < 0)
            {
                throw new InsufficientFundsInBankBalanceException();
            }

            if (latestChurchTransaction != null)
            {
                churchBalance = latestChurchTransaction.Balance;
            }

            var transactionDebit = new Transaction
            {
                Debit = dto.WithdrawalAmount,
                Balance = churchBalance + dto.WithdrawalAmount,
                TransactionDate = DateTime.Now,
                TransactionSourceTypeId = (int)SiriusEnums.TransactionSourceTypes.ChurchAccount,
            };

            var transactionCredit = new Transaction
            {
                Credit = dto.WithdrawalAmount,
                Balance = bankBalance - dto.WithdrawalAmount,
                TransactionDate = DateTime.Now,
                TransactionSourceTypeId = (int)SiriusEnums.TransactionSourceTypes.BankAccount,
            };

            Context.Transactions.Add(transactionDebit);
            Context.Transactions.Add(transactionCredit);

            Context.SaveChanges();
        }

        public void CreateExpenseTransaction(ExpenseDto dto)
        {
            decimal expensesBalance = 0;
            decimal churchBalance = 0;

            var latestExpensesTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.ExpensesAccount);

            var latestChurchTransaction = Context.Transactions.LastOrDefault(t =>
                t.TransactionSourceTypeId == (int)SiriusEnums.TransactionSourceTypes.ChurchAccount);

            if (latestExpensesTransaction != null)
            {
                expensesBalance = latestExpensesTransaction.Balance;
            }

            if (latestChurchTransaction != null)
            {
                churchBalance = latestChurchTransaction.Balance;
            }

            if (churchBalance - dto.Amount < 0)
            {
                throw new InsufficientFundsInChurchBalanceException();
            }

            var transactionDebit = new Transaction
            {
                Debit = dto.Amount,
                Balance = expensesBalance + dto.Amount,
                TransactionDate = DateTime.Now,
                TransactionSourceTypeId = (int)SiriusEnums.TransactionSourceTypes.ExpensesAccount,
            };

            var transactionCredit = new Transaction
            {
                Credit = dto.Amount,
                Balance = churchBalance - dto.Amount,
                TransactionDate = DateTime.Now,
                TransactionSourceTypeId = (int)SiriusEnums.TransactionSourceTypes.ChurchAccount,
            };

            Context.Transactions.Add(transactionDebit);
            Context.Transactions.Add(transactionCredit);

            Context.SaveChanges();
        }
    }
}