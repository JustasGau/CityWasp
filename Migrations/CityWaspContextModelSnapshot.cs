﻿// <auto-generated />
using System;
using CityWasp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityWasp.Migrations
{
    [DbContext(typeof(CityWaspContext))]
    partial class CityWaspContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityWasp.Models.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("coordinates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("currentValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mileage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.Property<DateTime>("techincal")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
