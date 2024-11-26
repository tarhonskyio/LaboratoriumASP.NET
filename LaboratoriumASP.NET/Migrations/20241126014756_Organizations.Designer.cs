﻿// <auto-generated />
using System;
using LaboratoriumASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaboratoriumASP.NET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241126014756_Organizations")]
    partial class Organizations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("LaboratoriumASP.NET.Models.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(2001, 11, 10),
                            Category = 0,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "st@wsei.edu.pl",
                            FirstName = "Adam",
                            LastName = "Johnson",
                            OrganizationId = 1,
                            PhoneNumber = "123 432 543"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateOnly(1999, 1, 17),
                            Category = 0,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "abc@wsei.edu.pl",
                            FirstName = "John",
                            LastName = "Johnson",
                            OrganizationId = 2,
                            PhoneNumber = "464 987 543"
                        });
                });

            modelBuilder.Entity("LaboratoriumASP.NET.Models.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Regon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("organisations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "WSEI",
                            Nip = "178945623",
                            Regon = "789456123"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Famo",
                            Nip = "178945623",
                            Regon = "789456123"
                        });
                });

            modelBuilder.Entity("LaboratoriumASP.NET.Models.ContactEntity", b =>
                {
                    b.HasOne("LaboratoriumASP.NET.Models.OrganizationEntity", "Organization")
                        .WithMany("Contacts")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("LaboratoriumASP.NET.Models.OrganizationEntity", b =>
                {
                    b.OwnsOne("LaboratoriumASP.NET.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("OrganizationEntityId");

                            b1.ToTable("organisations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityId");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityId = 1,
                                    City = "Kraków",
                                    Street = "św. Filipa 17"
                                },
                                new
                                {
                                    OrganizationEntityId = 2,
                                    City = "Warszawa",
                                    Street = "Wesoła 15"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("LaboratoriumASP.NET.Models.OrganizationEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
