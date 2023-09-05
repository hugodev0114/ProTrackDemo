﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProTrackDemo.DbContexts;

#nullable disable

namespace ProTrackDemo.Migrations
{
    [DbContext(typeof(ProTrackDbContextFactory))]
    [Migration("20230904171457_ExerciseDTOUpdate")]
    partial class ExerciseDTOUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ProTrackDemo.DTOs.ExerciseDTO", b =>
                {
                    b.Property<Guid>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("ProTrackDemo.DTOs.TrainingDTO", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("ProTrackDemo.MVVM.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TrainingDTOId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TrainingDTOId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("ProTrackDemo.MVVM.Models.Training", b =>
                {
                    b.Property<Guid>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TrainingId");

                    b.ToTable("Training");
                });

            modelBuilder.Entity("ProTrackDemo.MVVM.Models.Exercise", b =>
                {
                    b.HasOne("ProTrackDemo.DTOs.TrainingDTO", null)
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingDTOId");

                    b.HasOne("ProTrackDemo.MVVM.Models.Training", "Training")
                        .WithMany("Exercises")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("ProTrackDemo.DTOs.TrainingDTO", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("ProTrackDemo.MVVM.Models.Training", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
