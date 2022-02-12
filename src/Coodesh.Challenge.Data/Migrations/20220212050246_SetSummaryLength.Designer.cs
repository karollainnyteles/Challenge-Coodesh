﻿// <auto-generated />
using System;
using Coodesh.Challenge.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coodesh.Challenge.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220212050246_SetSummaryLength")]
    partial class SetSummaryLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Featured")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("NewsSite")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Summary")
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Launch", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Launch");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.SynchronizationControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArticlesCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<int>("SynchronizedArticles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SynchronizationControl");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Event", b =>
                {
                    b.HasOne("Coodesh.Challenge.Business.Models.Article", "Article")
                        .WithMany("Events")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Launch", b =>
                {
                    b.HasOne("Coodesh.Challenge.Business.Models.Article", "Article")
                        .WithMany("Launches")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Coodesh.Challenge.Business.Models.Article", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Launches");
                });
#pragma warning restore 612, 618
        }
    }
}
