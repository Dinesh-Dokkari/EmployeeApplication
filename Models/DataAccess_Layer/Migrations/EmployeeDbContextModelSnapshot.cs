﻿// <auto-generated />
using System;
using DataAccess_Layer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess_Layer.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess_Layer.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("Annual_CTC")
                        .HasColumnType("float");

                    b.Property<double>("Basic_Amount")
                        .HasColumnType("float");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<double>("Gratuity")
                        .HasColumnType("float");

                    b.Property<double>("HRA_Amount")
                        .HasColumnType("float");

                    b.Property<double>("Income_Tax")
                        .HasColumnType("float");

                    b.Property<double>("LTA_Amount")
                        .HasColumnType("float");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.Property<double>("Monthly_CTC")
                        .HasColumnType("float");

                    b.Property<double>("NetPay")
                        .HasColumnType("float");

                    b.Property<double>("PF_Money")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Professional_Tax")
                        .HasColumnType("float");

                    b.Property<double>("Total_Deduction")
                        .HasColumnType("float");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataAccess_Layer.Models.EmployeeSalary", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("New_CTC")
                        .HasColumnType("float");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("EmployeeSalary");
                });
#pragma warning restore 612, 618
        }
    }
}
