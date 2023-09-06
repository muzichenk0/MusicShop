﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShop.Migrator;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicShop.Migrator.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20230905170635_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicShop.Domain.Models.InstrumentType.InstrumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("OfferId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("InstrumentType");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.Offer.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ClosedUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("OfferCategoryId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<int>("OfferState")
                        .HasColumnType("integer");

                    b.Property<double>("RequirePrice")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClosedUserId");

                    b.HasIndex("OfferCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Offer");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.Review.SellerReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(65)
                        .HasColumnType("character varying(65)");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.ToTable("SellerReview");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("RegistratedIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.InstrumentType.InstrumentType", b =>
                {
                    b.HasOne("MusicShop.Domain.Models.InstrumentType.InstrumentType", "Parent")
                        .WithMany("SubTypes")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicShop.Domain.Models.User.User", null)
                        .WithMany("MusicalSpecialization")
                        .HasForeignKey("UserId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.Offer.Offer", b =>
                {
                    b.HasOne("MusicShop.Domain.Models.User.User", "ClosedUser")
                        .WithMany("ClosedOffers")
                        .HasForeignKey("ClosedUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicShop.Domain.Models.InstrumentType.InstrumentType", "OfferCategory")
                        .WithMany("Offers")
                        .HasForeignKey("OfferCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Models.User.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClosedUser");

                    b.Navigation("OfferCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.Review.SellerReview", b =>
                {
                    b.HasOne("MusicShop.Domain.Models.User.User", "Sender")
                        .WithMany("SendedReviews")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicShop.Domain.Models.User.User", "User")
                        .WithMany("GainedReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.InstrumentType.InstrumentType", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("SubTypes");
                });

            modelBuilder.Entity("MusicShop.Domain.Models.User.User", b =>
                {
                    b.Navigation("ClosedOffers");

                    b.Navigation("GainedReviews");

                    b.Navigation("MusicalSpecialization");

                    b.Navigation("Offers");

                    b.Navigation("SendedReviews");
                });
#pragma warning restore 612, 618
        }
    }
}