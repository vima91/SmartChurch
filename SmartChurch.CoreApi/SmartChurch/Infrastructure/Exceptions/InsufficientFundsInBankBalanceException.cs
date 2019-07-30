using System;

namespace SmartChurch.Infrastructure.Exceptions
{
    public class InsufficientFundsInBankBalanceException : Exception
    {
        public override string Message =>
            "Insufficient funds in bank account, please withdraw at most the amount available in bank balance.";
    }
}