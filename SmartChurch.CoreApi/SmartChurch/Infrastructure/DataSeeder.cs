using System;
using System.Collections.Generic;
using System.Linq;
using SmartChurch.DataAccess;
using SmartChurch.DataModel.Models.Entities;
using SmartChurch.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartChurch.Properties;

namespace SmartChurch.Infrastructure
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider, SiriusDbContext context)
        {
            #region Identity

            if (!context.Users.Any())
            {
                //Initializing custom roles   
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleNames = SiriusHelper.GetStringListFromEnum<SiriusEnums.Roles>();

                foreach (var roleName in roleNames)
                {
                    var roleExist = roleManager.RoleExistsAsync(roleName).Result;
                    if (!roleExist)
                    {
                        //Create the roles and seed them to the database
                        roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
                    }
                }

                context.SaveChanges();

                SeedIdentity(userManager, context);

                SeedSettings(context);
            }

            #endregion

            #region AppSettings

            if (!context.AppSettings.Any())
            {
                var appSettings = new AppSettings
                {
                    AppLogo = InitialAppSettings.ImageData,
                    AppName = InitialAppSettings.AppName,
                    City = "Hong Kong",
                    Country = new Country { Name = "China", CreationUser = "Seeded", CreationDate = DateTime.Now, }
                };

                context.AppSettings.Add(appSettings);

                context.SaveChanges();
            }

            #endregion
        }

        public static void SeedSettings(SiriusDbContext context)
        {
            #region Countries

            var countryChina = new Country
            {
                Name = "China",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };

            if (!context.Countries.Any())
            {
                var countryThailand = new Country
                {
                    Name = "Thailand",
                    CreationDate = DateTime.Now,
                    CreationUser = Constants.SystemSeed,
                };
                context.Countries.Add(countryChina);
                context.Countries.Add(countryThailand);
            }

            #endregion

            #region TransactionSourceTypes

            if (!context.TransactionSourceTypes.Any())
            {
                var tstBank = new TransactionSourceType
                {
                    Name = "Bank Account",
                    CreationDate = DateTime.Now,
                    CreationUser = Constants.SystemSeed,
                };
                var tstChurch = new TransactionSourceType
                {
                    Name = "Church Account",
                    CreationDate = DateTime.Now,
                    CreationUser = Constants.SystemSeed,
                };
                var tstExpense = new TransactionSourceType
                {
                    Name = "Expenses Account",
                    CreationDate = DateTime.Now,
                    CreationUser = Constants.SystemSeed,
                };
                context.TransactionSourceTypes.Add(tstBank);
                context.TransactionSourceTypes.Add(tstChurch);
                context.TransactionSourceTypes.Add(tstExpense);
            }
            
            #endregion

            #region AppSettings

            var appSettings = new AppSettings
            {
                AppName = Constants.AppName,
                AppLogo = Constants.AppLogo,
                Country = countryChina,
                City = "Hong Kong",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            context.AppSettings.Add(appSettings);

            #endregion

            #region ExpenseTypes

            var expenseType1 = new ExpenseType
            {
                Name = "Presents",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType2 = new ExpenseType
            {
                Name = "Food",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType3 = new ExpenseType
            {
                Name = "Rent",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType4 = new ExpenseType
            {
                Name = "Transportation",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType5 = new ExpenseType
            {
                Name = "Charity",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType6 = new ExpenseType
            {
                Name = "Maintenance",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType7 = new ExpenseType
            {
                Name = "Labour",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            var expenseType8 = new ExpenseType
            {
                Name = "Other",
                CreationDate = DateTime.Now,
                CreationUser = Constants.SystemSeed,
            };
            context.ExpenseTypes.Add(expenseType1);
            context.ExpenseTypes.Add(expenseType2);
            context.ExpenseTypes.Add(expenseType3);
            context.ExpenseTypes.Add(expenseType4);
            context.ExpenseTypes.Add(expenseType5);
            context.ExpenseTypes.Add(expenseType6);
            context.ExpenseTypes.Add(expenseType7);
            context.ExpenseTypes.Add(expenseType8);

            #endregion

            context.SaveChanges();
        }

        private static List<IdentityUser> SeedUsers(UserManager<IdentityUser> userManager)
        {
            var users = new List<IdentityUser>();

            var devUser = userManager.FindByEmailAsync("evram.ehab@gmail.com").Result;

            if (devUser == null)
            {
                devUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "evram.ehab@gmail.com",
                    Email = "evram.ehab@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                userManager.CreateAsync(devUser, "Pa$$w0rd" + SiriusConfiguration.Salt).Wait();
            }

            var adminUser = userManager.FindByEmailAsync("admin@sirius.com").Result;

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin@sirius.com",
                    Email = "admin@sirius.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                userManager.CreateAsync(adminUser, "123456" + SiriusConfiguration.Salt).Wait();
            }

            users.Add(devUser);
            users.Add(adminUser);

            return users;
        }

        private static void SeedIdentity(UserManager<IdentityUser> userManager, SiriusDbContext context)
        {
            var users = SeedUsers(userManager);

            context.SaveChanges();

            var devUser = users[0]; //Dev
            var adminUser = users[1]; //Admin

            var adminUserRoles = userManager.GetRolesAsync(devUser).Result;
            if (adminUserRoles.Count == 0)
            {
                userManager.AddToRoleAsync(devUser, SiriusEnums.Roles.Dev.ToString()).Wait();
            }

            context.SaveChanges();

            var powerUserRoles = userManager.GetRolesAsync(adminUser).Result;
            if (powerUserRoles.Count == 0)
            {
                userManager.AddToRoleAsync(adminUser, SiriusEnums.Roles.Admin.ToString()).Wait();
            }

            context.SaveChanges();
        }
    }
}