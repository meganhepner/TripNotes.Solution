﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripNotes.Models;

namespace TripNotes.Migrations
{
    [DbContext(typeof(TripNotesContext))]
    [Migration("20200918033049_RaceClass")]
    partial class RaceClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TripNotes.Models.Horse", b =>
                {
                    b.Property<int>("HorseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HorseName");

                    b.HasKey("HorseId");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("TripNotes.Models.HorseRace", b =>
                {
                    b.Property<int>("HorseRaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HorseId");

                    b.Property<string>("HorseNotes");

                    b.Property<int>("RaceId");

                    b.HasKey("HorseRaceId");

                    b.HasIndex("HorseId");

                    b.HasIndex("RaceId");

                    b.ToTable("HorseRace");
                });

            modelBuilder.Entity("TripNotes.Models.Pace", b =>
                {
                    b.Property<int>("PaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("RaceDate");

                    b.Property<int>("RaceId");

                    b.Property<string>("RaceLength");

                    b.HasKey("PaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("Paces");
                });

            modelBuilder.Entity("TripNotes.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RaceClass");

                    b.Property<DateTime>("RaceDate");

                    b.Property<string>("RaceLength");

                    b.Property<string>("RaceNotes");

                    b.HasKey("RaceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("TripNotes.Models.HorseRace", b =>
                {
                    b.HasOne("TripNotes.Models.Horse", "Horse")
                        .WithMany("Races")
                        .HasForeignKey("HorseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TripNotes.Models.Race", "Race")
                        .WithMany("Horses")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TripNotes.Models.Pace", b =>
                {
                    b.HasOne("TripNotes.Models.Race", "Race")
                        .WithMany("Paces")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
