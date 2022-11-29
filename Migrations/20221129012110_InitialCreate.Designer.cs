﻿// <auto-generated />
using System;
using EFCoreBug;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreBug.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221129012110_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("EFCoreBug.SnapshotReference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PointerId")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("PointerVersionNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasAlternateKey("PointerId", "PointerVersionNumber");

                    b.ToTable("SnapshotReferences", (string)null);
                });

            modelBuilder.Entity("EFCoreBug.SnapshotReference", b =>
                {
                    b.OwnsOne("EFCoreBug.Snapshot", "Snapshot", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("TEXT");

                            b1.Property<ulong>("VersionNumber")
                                .HasColumnType("INTEGER");

                            b1.Property<Guid>("SnapshotReferenceId")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id", "VersionNumber");

                            b1.HasIndex("SnapshotReferenceId")
                                .IsUnique();

                            b1.ToTable("Snapshots", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SnapshotReferenceId");
                        });

                    b.Navigation("Snapshot")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
