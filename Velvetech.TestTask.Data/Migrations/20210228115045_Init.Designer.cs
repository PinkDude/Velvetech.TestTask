﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Velvetech.TestTask.Data.Context;

namespace Velvetech.TestTask.Data.Migrations
{
    [DbContext(typeof(TestTaskContext))]
    [Migration("20210228115045_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Callsign")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Callsign")
                        .IsUnique()
                        .HasFilter("[Callsign] IS NOT NULL");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.HasIndex("MiddleName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.StudentGroupRelation", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("StudentGroupRelations");
                });

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.StudentGroupRelation", b =>
                {
                    b.HasOne("Velvetech.TestTask.Domain.Entities.Group", "Group")
                        .WithMany("StudentGroupRelations")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Velvetech.TestTask.Domain.Entities.Student", "Student")
                        .WithMany("StudentGroupRelations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.Group", b =>
                {
                    b.Navigation("StudentGroupRelations");
                });

            modelBuilder.Entity("Velvetech.TestTask.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentGroupRelations");
                });
#pragma warning restore 612, 618
        }
    }
}
