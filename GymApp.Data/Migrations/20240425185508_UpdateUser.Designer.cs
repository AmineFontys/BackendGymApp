﻿// <auto-generated />
using System;
using GymApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymApp.Data.Migrations
{
    [DbContext(typeof(TrainingContext))]
    [Migration("20240425185508_UpdateUser")]
    partial class UpdateUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExerciseTrainingSchedule", b =>
                {
                    b.Property<Guid>("ExercisesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingSchedulesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExercisesID", "TrainingSchedulesID");

                    b.HasIndex("TrainingSchedulesID");

                    b.ToTable("ExerciseTrainingSchedule");
                });

            modelBuilder.Entity("GymApp.Data.DTO.Enrollment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("EnrollmentCanceled")
                        .HasColumnType("bit");

                    b.Property<Guid>("MemberID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("TrainingID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("GymApp.Data.DTO.Exercise", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("DurationInSeconds")
                        .HasColumnType("bigint");

                    b.Property<string>("MuscleGroup")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Reps")
                        .HasColumnType("bigint");

                    b.Property<long>("RestTime")
                        .HasColumnType("bigint");

                    b.Property<long>("Sets")
                        .HasColumnType("bigint");

                    b.Property<long>("Weight")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("GymApp.Data.DTO.Training", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CurrentParticipants")
                        .HasColumnType("bigint");

                    b.Property<long>("MaxParticipants")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TrainerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TrainingScheduleID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TrainerID");

                    b.HasIndex("TrainingScheduleID");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("GymApp.Data.DTO.TrainingSchedule", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DurationInMinutes")
                        .HasColumnType("bigint");

                    b.Property<Guid>("TrainerID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("TrainerID");

                    b.ToTable("TrainingSchedule");
                });

            modelBuilder.Entity("GymApp.Data.DTO.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ExerciseTrainingSchedule", b =>
                {
                    b.HasOne("GymApp.Data.DTO.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymApp.Data.DTO.TrainingSchedule", null)
                        .WithMany()
                        .HasForeignKey("TrainingSchedulesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymApp.Data.DTO.Enrollment", b =>
                {
                    b.HasOne("GymApp.Data.DTO.User", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymApp.Data.DTO.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("GymApp.Data.DTO.Training", b =>
                {
                    b.HasOne("GymApp.Data.DTO.User", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymApp.Data.DTO.TrainingSchedule", "TrainingSchedule")
                        .WithMany()
                        .HasForeignKey("TrainingScheduleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trainer");

                    b.Navigation("TrainingSchedule");
                });

            modelBuilder.Entity("GymApp.Data.DTO.TrainingSchedule", b =>
                {
                    b.HasOne("GymApp.Data.DTO.User", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
