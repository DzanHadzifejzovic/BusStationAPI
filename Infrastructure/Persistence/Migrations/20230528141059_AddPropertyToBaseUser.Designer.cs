﻿// <auto-generated />
using BusStation_API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStation_API.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230528141059_AddPropertyToBaseUser")]
    partial class AddPropertyToBaseUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.BaseUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("Email");

                    b.HasAlternateKey("UserName")
                        .HasName("Username");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUser");
                });

            modelBuilder.Entity("Data.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("DrivingCondition")
                        .HasColumnType("bit");

                    b.Property<bool>("HasAirConditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTV")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfBus")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Data.Models.BusLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<double>("CardPrice")
                        .HasColumnType("float");

                    b.Property<string>("ConductorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Delay")
                        .HasColumnType("float");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfPlatform")
                        .HasColumnType("int");

                    b.Property<string>("RoadRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("ConductorId");

                    b.HasIndex("DriverId");

                    b.ToTable("BusLines");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "080b2956-cb3e-44eb-929e-8bde03b12afc",
                            ConcurrencyStamp = "5b2e9095-67b2-4fcc-af9f-2b150eafa220",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "b45be30d-a063-4751-a235-b73ef3223674",
                            ConcurrencyStamp = "7a69b234-10eb-45d5-a2b5-bcbb82fa107a",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "b1073563-d273-4709-9cb0-8736c0d0b1b8",
                            ConcurrencyStamp = "e5795d54-edb9-4145-b689-6ee8857177ca",
                            Name = "Conductor",
                            NormalizedName = "CONDUCTOR"
                        },
                        new
                        {
                            Id = "5ef8534a-715a-4ddf-a7a1-19ca46b22451",
                            ConcurrencyStamp = "9520c1c7-f9d1-4f68-b514-522e3e360dba",
                            Name = "CounterWorker",
                            NormalizedName = "COUNTERWORKER"
                        },
                        new
                        {
                            Id = "b1bea13e-0adf-4236-8f5b-083377331f45",
                            ConcurrencyStamp = "83f0e0a3-e2ed-4cdb-9d33-245933f202f7",
                            Name = "Buyer",
                            NormalizedName = "BUYER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Models.Conductor", b =>
                {
                    b.HasBaseType("Data.Models.BaseUser");

                    b.HasDiscriminator().HasValue("Conductor");
                });

            modelBuilder.Entity("Data.Models.Driver", b =>
                {
                    b.HasBaseType("Data.Models.BaseUser");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("Data.Models.BusLine", b =>
                {
                    b.HasOne("Data.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Conductor", "Conductor")
                        .WithMany("BusLines")
                        .HasForeignKey("ConductorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Driver", "Driver")
                        .WithMany("BusLines")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Conductor");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Models.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Models.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Models.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.Conductor", b =>
                {
                    b.Navigation("BusLines");
                });

            modelBuilder.Entity("Data.Models.Driver", b =>
                {
                    b.Navigation("BusLines");
                });
#pragma warning restore 612, 618
        }
    }
}
