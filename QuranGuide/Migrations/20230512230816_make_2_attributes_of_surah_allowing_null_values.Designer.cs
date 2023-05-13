﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuranGuide.Data;

#nullable disable

namespace QuranGuide.Migrations
{
    [DbContext(typeof(QuranContext))]
    [Migration("20230512230816_make_2_attributes_of_surah_allowing_null_values")]
    partial class make_2_attributes_of_surah_allowing_null_values
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuranGuide.Models.Surah", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("chapter_number")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("revelation_type")
                        .HasColumnType("int");

                    b.Property<int>("verses_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("surahs");
                });

            modelBuilder.Entity("QuranGuide.Models.Verse", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("surahId")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id", "surahId");

                    b.HasIndex("surahId");

                    b.ToTable("verses");
                });

            modelBuilder.Entity("QuranGuide.Models.Verse", b =>
                {
                    b.HasOne("QuranGuide.Models.Surah", "surah")
                        .WithMany("verses")
                        .HasForeignKey("surahId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("surah");
                });

            modelBuilder.Entity("QuranGuide.Models.Surah", b =>
                {
                    b.Navigation("verses");
                });
#pragma warning restore 612, 618
        }
    }
}
