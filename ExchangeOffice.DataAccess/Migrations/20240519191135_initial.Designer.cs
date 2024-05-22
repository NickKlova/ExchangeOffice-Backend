﻿// <auto-generated />
using System;
using ExchangeOffice.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExchangeOffice.DataAccess.Migrations
{
    [DbContext(typeof(DataAccessContext))]
    [Migration("20240519191135_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlacklist")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Fund", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Funds");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BaseCurrencyId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("BuyRate")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("SellRate")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TargetCurrencyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("TargetCurrencyId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSell")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("RateId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSale")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RateId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("RateId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2e6fa3f-4d4c-4e5f-9f15-90c8fea98721"),
                            CreatedOn = new DateTime(2024, 5, 19, 19, 11, 34, 555, DateTimeKind.Utc).AddTicks(544),
                            Name = "Owner"
                        },
                        new
                        {
                            Id = new Guid("a9b8c7d6-5e4f-3a2b-1c0d-f9e8d7c6b5a4"),
                            CreatedOn = new DateTime(2024, 5, 19, 19, 11, 34, 555, DateTimeKind.Utc).AddTicks(548),
                            Name = "Manager"
                        },
                        new
                        {
                            Id = new Guid("f1e2d3c4-b5a6-6c7d-8e9f-0a1b2c3d4e5f"),
                            CreatedOn = new DateTime(2024, 5, 19, 19, 11, 34, 555, DateTimeKind.Utc).AddTicks(550),
                            Name = "Cashier"
                        },
                        new
                        {
                            Id = new Guid("7f6e5d4c-3b2a-1f0e-9d8c-2b1a0f9e8d7c"),
                            CreatedOn = new DateTime(2024, 5, 19, 19, 11, 34, 555, DateTimeKind.Utc).AddTicks(551),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Fund", b =>
                {
                    b.HasOne("ExchangeOffice.DataAccess.DAO.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Rate", b =>
                {
                    b.HasOne("ExchangeOffice.DataAccess.DAO.Currency", "BaseCurrency")
                        .WithMany()
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExchangeOffice.DataAccess.DAO.Currency", "TargetCurrency")
                        .WithMany()
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseCurrency");

                    b.Navigation("TargetCurrency");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Reservation", b =>
                {
                    b.HasOne("ExchangeOffice.DataAccess.DAO.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExchangeOffice.DataAccess.DAO.Rate", "Rate")
                        .WithMany()
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Rate");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.Transaction", b =>
                {
                    b.HasOne("ExchangeOffice.DataAccess.DAO.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExchangeOffice.DataAccess.DAO.Rate", "Rate")
                        .WithMany()
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ExchangeOffice.DataAccess.DAO.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Rate");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ExchangeOffice.DataAccess.DAO.User", b =>
                {
                    b.HasOne("ExchangeOffice.DataAccess.DAO.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExchangeOffice.DataAccess.DAO.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Contact");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}