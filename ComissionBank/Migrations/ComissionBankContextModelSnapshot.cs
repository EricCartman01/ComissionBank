﻿// <auto-generated />
using System;
using ComissionBank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComissionBank.Migrations
{
    [DbContext(typeof(ComissionBankContext))]
    partial class ComissionBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ComissionBank.Models.Advisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Bank");

                    b.Property<string>("BankAccount");

                    b.Property<string>("BankAgency");

                    b.Property<DateTime>("Birthday");

                    b.Property<double>("CMBC");

                    b.Property<string>("Cfp");

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<bool>("Employee");

                    b.Property<double>("ITAZ");

                    b.Property<DateTime>("Initial");

                    b.Property<string>("Initials");

                    b.Property<double>("JURC");

                    b.Property<string>("Matrix");

                    b.Property<string>("Name");

                    b.Property<double>("Net");

                    b.Property<double>("NetBirthday");

                    b.Property<double>("NetCertification");

                    b.Property<double>("NetTotal");

                    b.Property<double>("PAN");

                    b.Property<double>("PROTC");

                    b.Property<string>("Password");

                    b.Property<string>("Telephone");

                    b.Property<double>("XPC");

                    b.HasKey("Id");

                    b.ToTable("Advisor");
                });

            modelBuilder.Entity("ComissionBank.Models.Broker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Broker");
                });

            modelBuilder.Entity("ComissionBank.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ComissionBank.Models.Comission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvisorId");

                    b.Property<double>("AdvisorValue");

                    b.Property<int?>("BrokerId");

                    b.Property<string>("ClientCode");

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HouseId");

                    b.Property<double>("LiquidValue");

                    b.Property<int>("Month");

                    b.Property<int>("Order");

                    b.Property<double>("PercentualAdvisor");

                    b.Property<int>("ProductId");

                    b.Property<double>("Value");

                    b.Property<int>("Year");

                    b.Property<int>("Yield");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.HasIndex("BrokerId");

                    b.HasIndex("ClientId");

                    b.HasIndex("HouseId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comission");
                });

            modelBuilder.Entity("ComissionBank.Models.Exchange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdvisorId");

                    b.Property<double>("Comission");

                    b.Property<int>("ComissionType");

                    b.Property<double>("Cotation");

                    b.Property<int>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<string>("FirstName");

                    b.Property<double>("GrossValue");

                    b.Property<double>("NetValue");

                    b.Property<int>("Order");

                    b.Property<double>("Spread");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AdvisorId");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("ComissionBank.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviaton");

                    b.Property<string>("Details");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("House");
                });

            modelBuilder.Entity("ComissionBank.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<int>("Market");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ComissionBank.Models.Comission", b =>
                {
                    b.HasOne("ComissionBank.Models.Advisor", "Advisor")
                        .WithMany("Comissions")
                        .HasForeignKey("AdvisorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ComissionBank.Models.Broker", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId");

                    b.HasOne("ComissionBank.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("ComissionBank.Models.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ComissionBank.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ComissionBank.Models.Exchange", b =>
                {
                    b.HasOne("ComissionBank.Models.Advisor", "Advisor")
                        .WithMany()
                        .HasForeignKey("AdvisorId");
                });
#pragma warning restore 612, 618
        }
    }
}
