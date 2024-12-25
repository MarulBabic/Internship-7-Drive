using Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class DumpDriveDbContext : DbContext
    {
        public DumpDriveDbContext(DbContextOptions<DumpDriveDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SharedItem> SharedItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5433;Database=DumpDrive;User Id=postgres;Password=admin;");

                optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasKey(u => u.Id);

            modelBuilder.Entity<Folder>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<File>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<SharedItem>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Folders)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentFolder)
                .WithMany(f => f.SubFolders)
                .HasForeignKey(f => f.ParentFolderId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<File>()
                .HasOne(f => f.Folder)
                .WithMany(f => f.Files)
                .HasForeignKey(f => f.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<File>()
                .HasOne(f => f.Owner)
                .WithMany(u => u.Files)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.File)
                .WithMany()
                .HasForeignKey(c => c.FileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SharedItem>()
                .HasOne(s => s.OwnerUser)
                .WithMany()
                .HasForeignKey(s => s.OwnerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SharedItem>()
                 .Property(s => s.SharedItemType)
                 .HasConversion<string>();

            modelBuilder.Entity<SharedItem>()
                .HasOne(s => s.SharedUser)
                .WithMany()
                .HasForeignKey(s => s.SharedUserId)
                .OnDelete(DeleteBehavior.Restrict);


            DatabaseSeeder.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DumpDriveDbContextFactory : IDesignTimeDbContextFactory<DumpDriveDbContext>
    {
        public DumpDriveDbContext CreateDbContext(string[] args)
        {

            var connectionString = "Host=127.0.0.1;Port=5433;Database=DumpDrive;User Id=postgres;Password=admin;";

            var options = new DbContextOptionsBuilder<DumpDriveDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            return new DumpDriveDbContext(options);
        }

    }
}
