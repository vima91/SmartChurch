using SmartChurch.DataModel.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmartChurch.DataAccess
{
    public partial class SiriusDbContext
    {
        public DbSet<AppSettings> AppSettings { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<BaptismType> BaptismTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MarriageType> MarriageTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ReligiousBackground> ReligiousBackgrounds { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceLeader> ServiceLeaders { get; set; }
        public DbSet<ServiceSubscription> ServiceSubscriptions { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionSourceType> TransactionSourceTypes { get; set; }
    }
}