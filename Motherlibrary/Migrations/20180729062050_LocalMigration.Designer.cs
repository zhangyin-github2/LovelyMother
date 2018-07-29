﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motherlibrary;

namespace Motherlibrary.Migrations
{
    [DbContext(typeof(MyDatabaseContext))]
    [Migration("20180729062050_LocalMigration")]
    partial class LocalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Motherlibrary.MyDatabaseContext+BlackListProgress", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName");

                    b.Property<string>("ResetName");

                    b.Property<int>("Type");

                    b.Property<string>("Uwp_ID");

                    b.HasKey("ID");

                    b.ToTable("BlackListProgresses");
                });

            modelBuilder.Entity("Motherlibrary.MyDatabaseContext+Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Begin");

                    b.Property<string>("Date");

                    b.Property<int>("DefaultTime");

                    b.Property<int>("FinishFlag");

                    b.Property<int>("FinishTime");

                    b.Property<string>("Introduction");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}