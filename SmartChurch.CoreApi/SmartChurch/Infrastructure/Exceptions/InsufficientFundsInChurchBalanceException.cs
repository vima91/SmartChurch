using System;

namespace SmartChurch.Infrastructure.Exceptions
{
    public class InsufficientFundsInChurchBalanceException : Exception
    {
        public override string Message =>
            "Insufficient funds in church account, please withdraw at most the amount available in church balance.";
    }
}