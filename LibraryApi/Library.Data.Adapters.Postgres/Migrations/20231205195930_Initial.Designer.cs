﻿// <auto-generated />
using System;
using Library.Data.Adapters.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Data.Adapters.Postgres.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20231205195930_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Data.Adapters.Sql.Models.BookEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}