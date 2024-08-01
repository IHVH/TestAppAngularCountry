﻿// <auto-generated />
using System;
using EntitiesDAL.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntitiesDAL.SQLite.Migrations
{
    [DbContext(typeof(AppSQLiteContext))]
    [Migration("20240801152905_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("EntitiesDAL.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "RU",
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 2,
                            Code = "DE",
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("EntitiesDAL.Models.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Saint Petersburg"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Stavropol region"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Hesse"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Bavaria"
                        });
                });

            modelBuilder.Entity("EntitiesDAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Agree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EntitiesDAL.Models.Province", b =>
                {
                    b.HasOne("EntitiesDAL.Models.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EntitiesDAL.Models.User", b =>
                {
                    b.HasOne("EntitiesDAL.Models.Country", "Country")
                        .WithMany("Users")
                        .HasForeignKey("CountryId");

                    b.HasOne("EntitiesDAL.Models.Province", "Province")
                        .WithMany("Users")
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Country");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("EntitiesDAL.Models.Country", b =>
                {
                    b.Navigation("Provinces");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EntitiesDAL.Models.Province", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
