﻿// <auto-generated />
using System;
using MedicalLabratoryManagment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalLabratoryManagment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240623113245_OrderDetailsTableAdded")]
    partial class OrderDetailsTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalLabratoryManagment.Models.Bill", b =>
                {
                    b.Property<int>("BillNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillNo"));

                    b.Property<string>("BillDate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("BillNo");

                    b.HasIndex("PatientID");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.OrderDetials", b =>
                {
                    b.Property<int>("DetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailID"));

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("BillNo")
                        .HasColumnType("int");

                    b.Property<decimal>("Maxvalue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Minivalue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("TestID")
                        .HasColumnType("int");

                    b.HasKey("DetailID");

                    b.HasIndex("BillId");

                    b.HasIndex("PatientID");

                    b.HasIndex("TestID");

                    b.ToTable("OrderDetials");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.Test", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestID"));

                    b.Property<decimal?>("MaximumValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("MinimumValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("SampleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SampleUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.Bill", b =>
                {
                    b.HasOne("MedicalLabratoryManagment.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalLabratoryManagment.Models.OrderDetials", b =>
                {
                    b.HasOne("MedicalLabratoryManagment.Models.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId");

                    b.HasOne("MedicalLabratoryManagment.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.HasOne("MedicalLabratoryManagment.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestID");

                    b.Navigation("Bill");

                    b.Navigation("Patient");

                    b.Navigation("Test");
                });
#pragma warning restore 612, 618
        }
    }
}
