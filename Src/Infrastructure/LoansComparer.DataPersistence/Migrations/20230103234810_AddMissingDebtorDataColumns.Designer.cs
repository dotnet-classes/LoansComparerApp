﻿// <auto-generated />
using System;
using LoansComparer.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoansComparer.DataPersistence.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20230103234810_AddMissingDebtorDataColumns")]
    partial class AddMissingDebtorDataColumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoansComparer.Domain.Entities.Bank", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GetInquiryRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GetOfferDocumentRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GetOfferRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostInquiryRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostOfferDocumentRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostOfferRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.Inquiry", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChosenBankInquiryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InquireDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("LoanValue")
                        .HasColumnType("int");

                    b.Property<short>("NumberOfInstallments")
                        .HasColumnType("smallint");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BankID");

                    b.HasIndex("UserID");

                    b.ToTable("Inquiries");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BankID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.Inquiry", b =>
                {
                    b.HasOne("LoansComparer.Domain.Entities.Bank", "Bank")
                        .WithMany("Inquiries")
                        .HasForeignKey("BankID");

                    b.HasOne("LoansComparer.Domain.Entities.User", "User")
                        .WithMany("Inquiries")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.User", b =>
                {
                    b.HasOne("LoansComparer.Domain.Entities.Bank", "Bank")
                        .WithMany("Employees")
                        .HasForeignKey("BankID");

                    b.OwnsOne("LoansComparer.Domain.Entities.PersonalData", "PersonalData", b1 =>
                        {
                            b1.Property<Guid>("UserID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("BirthDate");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("GovernmentId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("GovernmentId");

                            b1.Property<int>("GovernmentIdType")
                                .HasColumnType("int")
                                .HasColumnName("GovernmentIdType");

                            b1.Property<DateTime>("JobEndDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("JobEndDate");

                            b1.Property<DateTime>("JobStartDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("JobStartDate");

                            b1.Property<int>("JobType")
                                .HasColumnType("int")
                                .HasColumnName("JobType");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserID");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserID");
                        });

                    b.Navigation("Bank");

                    b.Navigation("PersonalData");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.Bank", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Inquiries");
                });

            modelBuilder.Entity("LoansComparer.Domain.Entities.User", b =>
                {
                    b.Navigation("Inquiries");
                });
#pragma warning restore 612, 618
        }
    }
}
