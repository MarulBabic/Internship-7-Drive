using Data.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Data.Entities.Models.File;

namespace Data.Seed
{
    public class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            var passwordHasher = new PasswordHasher<User>();


            modelBuilder.Entity<User>()
            .HasData(new List<User>
            {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Password = passwordHasher.HashPassword(null, "Password123"),
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "janesmith@example.com",
                Password = passwordHasher.HashPassword(null, "SecurePassword456"),
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Johnson",
                Email = "michaeljohnson@example.com",
                Password = passwordHasher.HashPassword(null, "12345678Password"),
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 4,
                FirstName = "Emily",
                LastName = "Davis",
                Email = "emilydavis@example.com",
                Password = passwordHasher.HashPassword(null, "qwerty1234"),
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 5,
                FirstName = "David",
                LastName = "Lee",
                Email = "davidlee@example.com",
                Password = passwordHasher.HashPassword(null, "Password9876"),
                CreatedAt = DateTime.UtcNow
            }
            });


            modelBuilder.Entity<Folder>()
            .HasData(new List<Folder>
            {
            new Folder
            {
                Id = 1,
                Name = "Documents",
                OwnerId = 1,
                ParentFolderId = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Folder
            {
                Id = 2,
                Name = "Photos",
                OwnerId = 2,
                ParentFolderId = 1,  
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Folder
            {
                Id = 3,
                Name = "Music",
                OwnerId = 3,
                ParentFolderId = 1,  
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Folder
            {
                Id = 4,
                Name = "Projects",
                OwnerId = 4,
                ParentFolderId = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Folder
            {
                Id = 5,
                Name = "Videos",
                OwnerId = 5,
                ParentFolderId = 4,  
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
            });


            modelBuilder.Entity<File>()
            .HasData(new List<File>
            {
            new File
            {
                Id = 1,
                Name = "Resume.pdf",
                OwnerId = 1,
                FolderId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "This is the content of my resume."
            },
            new File
            {
                Id = 2,
                Name = "Presentation.pptx",
                OwnerId = 2,
                FolderId = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "This is the content of my presentation."
            },
            new File
            {
                Id = 3,
                Name = "Vacation.jpeg",
                OwnerId = 3,
                FolderId = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "A beautiful vacation photo content."
            },
            new File
            {
                Id = 4,
                Name = "Holiday.mp3",
                OwnerId = 4,
                FolderId = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "Audio content of a holiday song."
            },
            new File
            {
                Id = 5,
                Name = "Report.xlsx",
                OwnerId = 5,
                FolderId = 4,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "Content for my project report."
            },
            new File
            {
                Id = 6,
                Name = "Song.mp3",
                OwnerId = 1,
                FolderId = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "Content of a holiday song in MP3 format."
            },
            new File
            {
                Id = 7,
                Name = "Document.docx",
                OwnerId = 2,
                FolderId = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "This is a document content."
            },
            new File
            {
                Id = 8,
                Name = "Movie.mp4",
                OwnerId = 3,
                FolderId = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Content = "Video file content for a movie."
            }
            });


            modelBuilder.Entity<Comment>()
            .HasData(new List<Comment>
            {
            new Comment
            {
                Id = 1,
                UserId = 1,
                Content = "This is my resume file.",
                FileId = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Comment
            {
                Id = 2,
                UserId = 2,
                Content = "Great vacation photo!",
                FileId = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Comment
            {
                Id = 3,
                UserId = 3,
                Content = "I love this holiday song.",
                FileId = 4,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Comment
            {
                Id = 4,
                UserId = 4,
                Content = "This is a great report!",
                FileId = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Comment
            {   
                Id = 5,
                UserId = 5,
                Content = "This is an awesome movie!",
                FileId = 8,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
            });


            modelBuilder.Entity<SharedItem>()
            .HasData(new List<SharedItem>
            {
            new SharedItem
            {
                Id = 1,
                OwnerUserId = 1,
                SharedUserId = 2,
                SharedAt = DateTime.UtcNow,
                SharedItemType = Data.Enums.ItemType.File
            },
            new SharedItem
            {   
                Id = 2,
                OwnerUserId = 3,
                SharedUserId = 4,
                SharedAt = DateTime.UtcNow,
                SharedItemType = Data.Enums.ItemType.Folder
            },
            new SharedItem
            {
                Id = 3,
                OwnerUserId = 4,
                SharedUserId = 5,
                SharedAt = DateTime.UtcNow,
                SharedItemType = Data.Enums.ItemType.File
            }
            });

        }

    }
}
