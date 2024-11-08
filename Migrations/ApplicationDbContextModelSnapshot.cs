﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserRegistration.Data;

#nullable disable

namespace UserRegistration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserRegistration.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<string>("Governate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("UserRegistration.Data.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GovernorateId = 1,
                            Name = "Maadi"
                        },
                        new
                        {
                            Id = 2,
                            GovernorateId = 1,
                            Name = "Heliopolis"
                        },
                        new
                        {
                            Id = 3,
                            GovernorateId = 1,
                            Name = "Nasr City"
                        },
                        new
                        {
                            Id = 4,
                            GovernorateId = 1,
                            Name = "Shubra"
                        },
                        new
                        {
                            Id = 5,
                            GovernorateId = 2,
                            Name = "Sidi Gaber"
                        },
                        new
                        {
                            Id = 6,
                            GovernorateId = 2,
                            Name = "Montaza"
                        },
                        new
                        {
                            Id = 7,
                            GovernorateId = 2,
                            Name = "Mansheya"
                        },
                        new
                        {
                            Id = 8,
                            GovernorateId = 3,
                            Name = "6th of October"
                        },
                        new
                        {
                            Id = 9,
                            GovernorateId = 3,
                            Name = "Haram"
                        },
                        new
                        {
                            Id = 10,
                            GovernorateId = 3,
                            Name = "Dokki"
                        },
                        new
                        {
                            Id = 11,
                            GovernorateId = 3,
                            Name = "Agouza"
                        },
                        new
                        {
                            Id = 12,
                            GovernorateId = 4,
                            Name = "Al Arab"
                        },
                        new
                        {
                            Id = 13,
                            GovernorateId = 4,
                            Name = "Al Manakh"
                        },
                        new
                        {
                            Id = 14,
                            GovernorateId = 4,
                            Name = "Al Zohour"
                        },
                        new
                        {
                            Id = 15,
                            GovernorateId = 5,
                            Name = "Arbaeen"
                        },
                        new
                        {
                            Id = 16,
                            GovernorateId = 5,
                            Name = "Ganayen"
                        },
                        new
                        {
                            Id = 17,
                            GovernorateId = 5,
                            Name = "Suez City Center"
                        },
                        new
                        {
                            Id = 18,
                            GovernorateId = 6,
                            Name = "Luxor City"
                        },
                        new
                        {
                            Id = 19,
                            GovernorateId = 6,
                            Name = "Armant"
                        },
                        new
                        {
                            Id = 20,
                            GovernorateId = 6,
                            Name = "Esna"
                        },
                        new
                        {
                            Id = 21,
                            GovernorateId = 7,
                            Name = "Aswan City"
                        },
                        new
                        {
                            Id = 22,
                            GovernorateId = 7,
                            Name = "Edfu"
                        },
                        new
                        {
                            Id = 23,
                            GovernorateId = 7,
                            Name = "Kom Ombo"
                        });
                });

            modelBuilder.Entity("UserRegistration.Data.Governorate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governorates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cairo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Alexandria"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Giza"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Port Said"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Suez"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Luxor"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Aswan"
                        });
                });

            modelBuilder.Entity("UserRegistration.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserRegistration.Data.Address", b =>
                {
                    b.HasOne("UserRegistration.Data.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRegistration.Data.City", b =>
                {
                    b.HasOne("UserRegistration.Data.Governorate", "Governorate")
                        .WithMany("Cities")
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("UserRegistration.Data.Governorate", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("UserRegistration.Data.User", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
