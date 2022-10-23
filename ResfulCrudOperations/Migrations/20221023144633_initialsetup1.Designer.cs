﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResfulCrudOperations.Models;

namespace ResfulCrudOperations.Migrations
{
    [DbContext(typeof(CityContext))]
    [Migration("20221023144633_initialsetup1")]
    partial class initialsetup1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResfulCrudOperations.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEstablished")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimatedPopulation")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TouristRating")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.ToTable("City");
                });
#pragma warning restore 612, 618
        }
    }
}
