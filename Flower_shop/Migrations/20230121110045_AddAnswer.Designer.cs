﻿// <auto-generated />
using System;
using Flower_shop.EfStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Flower_shop.Migrations
{
    [DbContext(typeof(WebDbContext))]
    [Migration("20230121110045_AddAnswer")]
    partial class AddAnswer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("codepro")
                        .HasColumnType("bit");

                    b.Property<string>("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("datetime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notification_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("operation_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sha1_hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("withdraw_amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AssignmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColorHex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.MyPayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyPayments");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.TypeProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesProduct");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Product", b =>
                {
                    b.HasOne("Flower_shop.EfStuff.DbModels.TypeProduct", "TypeProduct")
                        .WithMany("Products")
                        .HasForeignKey("TypeProductId");

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.TypeProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
