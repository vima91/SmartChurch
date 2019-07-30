namespace SmartChurch.Infrastructure
{
    public static class SiriusEnums
    {
        public enum Roles
        {
            Dev,
            Admin,
            DataEntry,
        }

        public enum TransactionSourceTypes
        {
            BankAccount = 1,
            ChurchAccount = 2,
            ExpensesAccount = 3,
        }
    }
}