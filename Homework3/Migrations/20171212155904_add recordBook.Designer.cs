﻿// <auto-generated />
using Homework3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Homework3.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20171212155904_add recordBook")]
    partial class addrecordBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Homework3.Models.RecordBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<DateTime?>("StartYear");

                    b.HasKey("Id");

                    b.ToTable("RecordBooks");
                });

            modelBuilder.Entity("Homework3.Models.Student", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age")
                        .IsRequired();

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("RecordBookId");

                    b.HasKey("Id");

                    b.HasIndex("RecordBookId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Homework3.Models.Student", b =>
                {
                    b.HasOne("Homework3.Models.RecordBook", "StudentRecordBook")
                        .WithMany()
                        .HasForeignKey("RecordBookId");
                });
#pragma warning restore 612, 618
        }
    }
}
