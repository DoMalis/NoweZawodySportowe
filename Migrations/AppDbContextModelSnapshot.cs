﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektZawody.Data;

#nullable disable

namespace ProjektZawody.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjektZawody.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjektZawody.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjektZawody.Models.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionStatus")
                        .HasColumnType("int");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Competitions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -2,
                            CompetitionStatus = 3,
                            MaxAge = 10,
                            MinAge = 11,
                            Name = "Siatkowka"
                        },
                        new
                        {
                            Id = -1,
                            CompetitionStatus = 1,
                            MaxAge = 10,
                            MinAge = 11,
                            Name = "Nozna"
                        });
                });

            modelBuilder.Entity("ProjektZawody.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players", (string)null);

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Age = 10,
                            FirstName = "Darek",
                            LastName = "Odkrywca "
                        },
                        new
                        {
                            Id = -2,
                            Age = 15,
                            FirstName = "Dagmar",
                            LastName = "Poszukiwacz"
                        },
                        new
                        {
                            Id = -3,
                            Age = 12,
                            FirstName = "Dorian",
                            LastName = "Nawigator"
                        });
                });

            modelBuilder.Entity("ProjektZawody.Models.Score", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("PlayerId", "CompetitionId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Scores", (string)null);

                    b.HasData(
                        new
                        {
                            PlayerId = -3,
                            CompetitionId = -1,
                            Points = 0
                        },
                        new
                        {
                            PlayerId = -1,
                            CompetitionId = -1,
                            Points = 0
                        },
                        new
                        {
                            PlayerId = -2,
                            CompetitionId = -1,
                            Points = 5
                        },
                        new
                        {
                            PlayerId = -1,
                            CompetitionId = -2,
                            Points = 0
                        },
                        new
                        {
                            PlayerId = -2,
                            CompetitionId = -2,
                            Points = 0
                        });
                });

            modelBuilder.Entity("ProjektZawody.Data.User", b =>
                {
                    b.HasOne("ProjektZawody.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProjektZawody.Models.Score", b =>
                {
                    b.HasOne("ProjektZawody.Models.Competition", "Competition")
                        .WithMany("Scores")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektZawody.Models.Player", "Player")
                        .WithMany("Scores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("ProjektZawody.Models.Competition", b =>
                {
                    b.Navigation("Scores");
                });

            modelBuilder.Entity("ProjektZawody.Models.Player", b =>
                {
                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
