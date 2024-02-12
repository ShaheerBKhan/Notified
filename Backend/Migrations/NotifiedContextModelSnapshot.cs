﻿// <auto-generated />
using System;
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(NotifiedContext))]
    partial class NotifiedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Database.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Backend.Database.Models.CompanyJob", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("CompanyJob");
                });

            modelBuilder.Entity("Backend.Database.Models.CompanyUser", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "UserId");

                    b.HasIndex("CompanyId");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("CompanyId"), "btree");

                    b.HasIndex("UserId");

                    b.ToTable("CompanyUser");
                });

            modelBuilder.Entity("Backend.Database.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApplicationUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsRemote")
                        .HasColumnType("boolean");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MinimumEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MinimumYearsOfExperience")
                        .HasColumnType("integer");

                    b.Property<string>("PreferredEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PreferredYearsOfExperience")
                        .HasColumnType("integer");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("CompanyId"), "btree");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Backend.Database.Models.JobUser", b =>
                {
                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("JobId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("JobUser");
                });

            modelBuilder.Entity("Backend.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRemotePreference")
                        .HasColumnType("boolean");

                    b.Property<string>("LocationPreference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("SalaryPreference")
                        .HasColumnType("numeric");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Id"), "hash");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Backend.Database.Models.CompanyJob", b =>
                {
                    b.HasOne("Backend.Database.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Database.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Backend.Database.Models.CompanyUser", b =>
                {
                    b.HasOne("Backend.Database.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Database.Models.Job", b =>
                {
                    b.HasOne("Backend.Database.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Backend.Database.Models.JobUser", b =>
                {
                    b.HasOne("Backend.Database.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
