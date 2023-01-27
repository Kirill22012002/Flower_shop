﻿// <auto-generated />
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
    [Migration("20230127202857_FixWalletDecimal")]
    partial class FixWalletDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmountValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizationAuthCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizationDetailsRrn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CapturedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeAmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncomeAmountValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentCardExpiryMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentCardExpiryYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentCardFirst6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentCardLast4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentCardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentIssuerCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethodId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentMethodSaved")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMethodTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("PaymentRefundable")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentTest")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientAccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientGatewayId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefundedAmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefundedAmountValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ThreeDSecureApplied")
                        .HasColumnType("bit");

                    b.Property<bool>("ThreeDSecureChallengeCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("ThreeDSecureMethodCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Flower_shop.EfStuff.DbModels.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Count")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
