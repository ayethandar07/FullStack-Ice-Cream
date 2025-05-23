﻿// <auto-generated />
using System;
using IceCream.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IceCream.Api.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IceCream.Api.Entities.IceCreamOption", b =>
                {
                    b.Property<int>("IceCreamId")
                        .HasColumnType("int");

                    b.Property<string>("Flavor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Topping")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IceCreamId", "Flavor", "Topping");

                    b.ToTable("IceCreamOptions");

                    b.HasData(
                        new
                        {
                            IceCreamId = 1,
                            Flavor = "Classic Vanilla",
                            Topping = "Sprinkles"
                        },
                        new
                        {
                            IceCreamId = 1,
                            Flavor = "French Vanilla",
                            Topping = "Caramel Drizzle"
                        },
                        new
                        {
                            IceCreamId = 2,
                            Flavor = "Dark Chocolate",
                            Topping = "Choco Chips"
                        },
                        new
                        {
                            IceCreamId = 2,
                            Flavor = "Milk Chocolate",
                            Topping = "Brownie Bites"
                        },
                        new
                        {
                            IceCreamId = 3,
                            Flavor = "Fresh Strawberry",
                            Topping = "Whipped Cream"
                        },
                        new
                        {
                            IceCreamId = 4,
                            Flavor = "Mint Chocolate",
                            Topping = "Choco Syrup"
                        },
                        new
                        {
                            IceCreamId = 5,
                            Flavor = "Cookies & Cream",
                            Topping = "Crushed Oreos"
                        });
                });

            modelBuilder.Entity("IceCream.Api.Entities.IceCreams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(130)
                        .HasColumnType("nvarchar(130)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("IceCreams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "vanilla.png",
                            Name = "Vanilla Delight",
                            Price = 2.9900000000000002
                        },
                        new
                        {
                            Id = 2,
                            Image = "chocolate.png",
                            Name = "Chocolate Heaven",
                            Price = 3.4900000000000002
                        },
                        new
                        {
                            Id = 3,
                            Image = "strawberry.png",
                            Name = "Strawberry Bliss",
                            Price = 3.29
                        },
                        new
                        {
                            Id = 4,
                            Image = "mint.png",
                            Name = "Minty Fresh",
                            Price = 3.1899999999999999
                        },
                        new
                        {
                            Id = 5,
                            Image = "cookie.png",
                            Name = "Cookie Crunch",
                            Price = 3.5899999999999999
                        });
                });

            modelBuilder.Entity("IceCream.Api.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("OrderdAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IceCream.Api.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IceCreamId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Topping")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("IceCream.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IceCream.Api.Entities.IceCreamOption", b =>
                {
                    b.HasOne("IceCream.Api.Entities.IceCreams", "IceCream")
                        .WithMany("Options")
                        .HasForeignKey("IceCreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IceCream");
                });

            modelBuilder.Entity("IceCream.Api.Entities.OrderItem", b =>
                {
                    b.HasOne("IceCream.Api.Entities.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("IceCream.Api.Entities.IceCreams", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("IceCream.Api.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
