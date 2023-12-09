﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ok.Models;

#nullable disable

namespace ok.Migrations
{
    [DbContext(typeof(Model))]
    partial class ModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ok.Models.Appunti", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("UtentiidUtente")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idUtente")
                        .HasColumnType("int");

                    b.Property<string>("titolo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UtentiidUtente");

                    b.ToTable("Appunti");
                });

            modelBuilder.Entity("ok.Models.Login", b =>
                {
                    b.Property<int>("idUtente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUtente"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUtente");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ok.Models.Appunti", b =>
                {
                    b.HasOne("ok.Models.Login", "Utenti")
                        .WithMany("Appunti")
                        .HasForeignKey("UtentiidUtente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utenti");
                });

            modelBuilder.Entity("ok.Models.Login", b =>
                {
                    b.Navigation("Appunti");
                });
#pragma warning restore 612, 618
        }
    }
}
