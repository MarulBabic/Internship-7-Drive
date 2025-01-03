﻿// <auto-generated />
using System;
using Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DumpDriveDbContext))]
    [Migration("20250103143957_UpdateDatabase")]
    partial class UpdateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is my resume file.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1393),
                            FileId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1624),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Great vacation photo!",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1850),
                            FileId = 3,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1851),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "I love this holiday song.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1853),
                            FileId = 4,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1854),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Content = "This is a great report!",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1856),
                            FileId = 5,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1856),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Content = "This is an awesome movie!",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1858),
                            FileId = 8,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(1858),
                            UserId = 5
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is the content of my resume.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(8574),
                            FolderId = 1,
                            Name = "Resume.pdf",
                            OwnerId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(8877)
                        },
                        new
                        {
                            Id = 2,
                            Content = "This is the content of my presentation.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9356),
                            FolderId = 2,
                            Name = "Presentation.pptx",
                            OwnerId = 2,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9357)
                        },
                        new
                        {
                            Id = 3,
                            Content = "A beautiful vacation photo content.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9361),
                            FolderId = 2,
                            Name = "Vacation.jpeg",
                            OwnerId = 3,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9362)
                        },
                        new
                        {
                            Id = 4,
                            Content = "Audio content of a holiday song.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9364),
                            FolderId = 3,
                            Name = "Holiday.mp3",
                            OwnerId = 4,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9364)
                        },
                        new
                        {
                            Id = 5,
                            Content = "Content for my project report.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9366),
                            FolderId = 4,
                            Name = "Report.xlsx",
                            OwnerId = 5,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9367)
                        },
                        new
                        {
                            Id = 6,
                            Content = "Content of a holiday song in MP3 format.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9372),
                            FolderId = 3,
                            Name = "Song.mp3",
                            OwnerId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9373)
                        },
                        new
                        {
                            Id = 7,
                            Content = "This is a document content.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9374),
                            FolderId = 5,
                            Name = "Document.docx",
                            OwnerId = 2,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9375)
                        },
                        new
                        {
                            Id = 8,
                            Content = "Video file content for a movie.",
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9377),
                            FolderId = 5,
                            Name = "Movie.mp4",
                            OwnerId = 3,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(9378)
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(5536),
                            Name = "Documents",
                            OwnerId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(5767)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6015),
                            Name = "Photos",
                            OwnerId = 2,
                            ParentFolderId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6016)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6020),
                            Name = "Music",
                            OwnerId = 3,
                            ParentFolderId = 1,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6020)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6023),
                            Name = "Projects",
                            OwnerId = 4,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6023)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6025),
                            Name = "Videos",
                            OwnerId = 5,
                            ParentFolderId = 4,
                            UpdatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 660, DateTimeKind.Utc).AddTicks(6026)
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.SharedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("FileId")
                        .HasColumnType("integer");

                    b.Property<int?>("FolderId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SharedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SharedItemType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SharedUserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("SharedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("SharedItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OwnerUserId = 1,
                            SharedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3315),
                            SharedItemType = "File",
                            SharedUserId = 2
                        },
                        new
                        {
                            Id = 2,
                            OwnerUserId = 3,
                            SharedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3761),
                            SharedItemType = "Folder",
                            SharedUserId = 4
                        },
                        new
                        {
                            Id = 3,
                            OwnerUserId = 4,
                            SharedAt = new DateTime(2025, 1, 3, 14, 39, 56, 661, DateTimeKind.Utc).AddTicks(3763),
                            SharedItemType = "File",
                            SharedUserId = 5
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 651, DateTimeKind.Utc).AddTicks(3360),
                            Email = "johndoe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Password = "AQAAAAEAACcQAAAAEDTvSlfYdk381h3pa+yqtlJ2u6laog3vs5EUCSh0LX0FV6BsPKLsqw0Ngwrs5aC6pA=="
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 653, DateTimeKind.Utc).AddTicks(3981),
                            Email = "janesmith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Password = "AQAAAAEAACcQAAAAEC9/eUeMPCYi/FWCQVzfZ0UUXT7phRS9ZqanMLM8j0rP8aQSsiX5QZU9DL5bOZDjeg=="
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 655, DateTimeKind.Utc).AddTicks(1042),
                            Email = "michaeljohnson@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Password = "AQAAAAEAACcQAAAAECHKS4r4iTHRbwSNY37RLNxtQiuh7t/jPB+ZAWuh8BQ7SKiefxM+j4lHUmQxDgBSFw=="
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 657, DateTimeKind.Utc).AddTicks(2277),
                            Email = "emilydavis@example.com",
                            FirstName = "Emily",
                            LastName = "Davis",
                            Password = "AQAAAAEAACcQAAAAEFY7kJnwQiALGRCizZePTjyfufklsO2/H7N+Khw4lRrVNN6F6ATPVoe1iFAebh56sQ=="
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 1, 3, 14, 39, 56, 659, DateTimeKind.Utc).AddTicks(1286),
                            Email = "davidlee@example.com",
                            FirstName = "David",
                            LastName = "Lee",
                            Password = "AQAAAAEAACcQAAAAEG+6AmyOkmh2FwuEUZwaCoP8oOscANK01q4N8TpmsOvuAc/GjNdS+/hTAwmaBwVZ3g=="
                        });
                });

            modelBuilder.Entity("Data.Entities.Models.Comment", b =>
                {
                    b.HasOne("Data.Entities.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "Owner")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.Models.File", b =>
                {
                    b.HasOne("Data.Entities.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.Models.Folder", b =>
                {
                    b.HasOne("Data.Entities.Models.User", "Owner")
                        .WithMany("Folders")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.Folder", "ParentFolder")
                        .WithMany("SubFolders")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Owner");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("Data.Entities.Models.SharedItem", b =>
                {
                    b.HasOne("Data.Entities.Models.User", "OwnerUser")
                        .WithMany()
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", "SharedUser")
                        .WithMany()
                        .HasForeignKey("SharedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.Models.User", null)
                        .WithMany("SharedItems")
                        .HasForeignKey("UserId");

                    b.Navigation("OwnerUser");

                    b.Navigation("SharedUser");
                });

            modelBuilder.Entity("Data.Entities.Models.Folder", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("SubFolders");
                });

            modelBuilder.Entity("Data.Entities.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Files");

                    b.Navigation("Folders");

                    b.Navigation("SharedItems");
                });
#pragma warning restore 612, 618
        }
    }
}