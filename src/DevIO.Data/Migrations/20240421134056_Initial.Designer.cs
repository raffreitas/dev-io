﻿// <auto-generated />
using System;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevIO.Data.Migrations
{
    [DbContext(typeof(DevIODbContext))]
    [Migration("20240421134056_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevIO.Business.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(8)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId")
                        .IsUnique();

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("DevIO.Business.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("DevIO.Business.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<int>("SupplierType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("DevIO.Business.Models.Address", b =>
                {
                    b.HasOne("DevIO.Business.Models.Supplier", "Supplier")
                        .WithOne("Address")
                        .HasForeignKey("DevIO.Business.Models.Address", "SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DevIO.Business.Models.Product", b =>
                {
                    b.HasOne("DevIO.Business.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DevIO.Business.Models.Supplier", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
