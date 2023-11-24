﻿// <auto-generated />
using System;
using ConversorFinal_BE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConversorFinalBk.Migrations
{
    [DbContext(typeof(ConversorContext))]
    partial class ConversorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("ConversorFinal_BE.Entities.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attemps")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FirstTry")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Conversion");
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("IC")
                        .HasColumnType("REAL");

                    b.Property<string>("Leyend")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currency");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IC = 1.0,
                            Leyend = "Dolar Americano",
                            Symbol = "USD"
                        },
                        new
                        {
                            Id = 2,
                            IC = 0.002,
                            Leyend = "Peso Argentino",
                            Symbol = "ARS"
                        },
                        new
                        {
                            Id = 3,
                            IC = 1.0900000000000001,
                            Leyend = "Euro",
                            Symbol = "EUR"
                        },
                        new
                        {
                            Id = 4,
                            IC = 0.042999999999999997,
                            Leyend = "Corona Checa",
                            Symbol = "KC"
                        });
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxAttemps")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Subscription");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxAttemps = 10,
                            Name = "Free",
                            Price = 0
                        },
                        new
                        {
                            Id = 2,
                            MaxAttemps = 100,
                            Name = "Trial",
                            Price = 10
                        },
                        new
                        {
                            Id = 3,
                            MaxAttemps = 10000,
                            Name = "Pro",
                            Price = 30
                        });
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdSubscription");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ConversorFinalBk.Entities.ConversionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountInput")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmountOutput")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ConversionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrencyFrom")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyTo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("ConversionHistory");
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.User", b =>
                {
                    b.HasOne("ConversorFinal_BE.Entities.Subscription", "Subscription")
                        .WithMany("users")
                        .HasForeignKey("IdSubscription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ConversorFinalBk.Entities.ConversionHistory", b =>
                {
                    b.HasOne("ConversorFinal_BE.Entities.User", "user")
                        .WithMany("ConversionHistory")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.Subscription", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("ConversorFinal_BE.Entities.User", b =>
                {
                    b.Navigation("ConversionHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
