﻿// <auto-generated />
using System;
using SmartChurch.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartChurch.Migrations
{
    [DbContext(typeof(SiriusDbContext))]
    [Migration("20190707123630_Add-all-required-fields")]
    partial class Addallrequiredfields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.AppSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppLogo");

                    b.Property<string>("AppName");

                    b.Property<string>("City");

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("AppSettings");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<DateTime>("DateOfEvent");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<int>("PersonId");

                    b.Property<int>("ServiceId");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.BaptismType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("BaptismTypes");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<int>("ExpenseTypeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ExpenseTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<DateTime>("ReceiptDate");

                    b.Property<string>("ReceiptNumber")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("MaritalStatuses");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.MarriageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("MarriageTypes");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BaptismCertificationPic");

                    b.Property<int>("BaptismTypeId");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Comments");

                    b.Property<string>("ConfessionFatherName");

                    b.Property<int>("CountryOfResidenceId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<string>("Email");

                    b.Property<string>("FacebookLink");

                    b.Property<int?>("GradeId");

                    b.Property<int>("HomeCountryId");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsServant");

                    b.Property<string>("Job");

                    b.Property<DateTime?>("LastVisitDate");

                    b.Property<int?>("LastVisitYearOfBirthday");

                    b.Property<int?>("LastVisitYearOfMarriageAnniversary");

                    b.Property<int>("MaritalStatusId");

                    b.Property<DateTime?>("MarriageAnniversary");

                    b.Property<string>("MarriageCertificatePic");

                    b.Property<int>("MarriageTypeId");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("Picture");

                    b.Property<string>("Qualifications");

                    b.Property<int>("ReligiousBackgroundId");

                    b.Property<string>("SingleStatusCertificatePic");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Weekends");

                    b.Property<string>("WhatsappNumber");

                    b.HasKey("Id");

                    b.HasIndex("BaptismTypeId");

                    b.HasIndex("CountryOfResidenceId");

                    b.HasIndex("GradeId");

                    b.HasIndex("HomeCountryId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("MarriageTypeId");

                    b.HasIndex("ReligiousBackgroundId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ReligiousBackground", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("ReligiousBackgrounds");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<DateTime>("From");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsWeekly");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ServiceTypeId");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("To");

                    b.Property<int?>("Weekday");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ServiceLeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<int>("PersonId");

                    b.Property<int>("ServiceId");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceLeaders");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ServiceSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<int>("PersonId");

                    b.Property<int>("ServiceId");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceSubscriptions");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsNotLinkableToPersons");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<decimal>("Credit");

                    b.Property<decimal>("Debit");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TransactionSourceTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionSourceTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.TransactionSourceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("CreationUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModificationDate");

                    b.Property<string>("ModificationUser");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Stamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("TransactionSourceTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.AppSettings", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Attendance", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Expense", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.ExpenseType", "ExpenseType")
                        .WithMany()
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Person", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.BaptismType", "BaptismType")
                        .WithMany()
                        .HasForeignKey("BaptismTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Country", "CountryOfResidence")
                        .WithMany()
                        .HasForeignKey("CountryOfResidenceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Country", "HomeCountry")
                        .WithMany()
                        .HasForeignKey("HomeCountryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.MarriageType", "MarriageType")
                        .WithMany()
                        .HasForeignKey("MarriageTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.ReligiousBackground", "ReligiousBackground")
                        .WithMany()
                        .HasForeignKey("ReligiousBackgroundId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Service", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.ServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ServiceLeader", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.ServiceSubscription", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmartChurch.DataModel.Models.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SmartChurch.DataModel.Models.Entities.Transaction", b =>
                {
                    b.HasOne("SmartChurch.DataModel.Models.Entities.TransactionSourceType", "TransactionSourceType")
                        .WithMany()
                        .HasForeignKey("TransactionSourceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
