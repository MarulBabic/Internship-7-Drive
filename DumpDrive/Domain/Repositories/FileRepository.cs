using Data.Entities.Models;
using File = Data.Entities.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public File? GetFile(List<File> files, string name)
        {
            return files.Where(f => f.Name == name).FirstOrDefault();
        }
        public void Add(File file)
        {
            DbContext.Files.Add(file);
            SaveChanges();
        }
        public void Update(File file)
        {
            DbContext.Files.Update(file);
            SaveChanges();
        }
        public void Delete(File file)
        {
            DbContext.Files.Remove(file);
            SaveChanges();
        }
        public File GetFileByNameInFolder(string fileName, int folderId)
        {
            return DbContext.Files
                .FirstOrDefault(f => f.Name == fileName && f.FolderId == folderId);
        }

        public List<File> GetFilesByUser(int userId)
        {
            return DbContext.Files.Where(f => f.OwnerId == userId).OrderByDescending(f => f.UpdatedAt).ToList();
        }
        public File? GetFileById(int fileId, int ownerUserId)
        {
            return DbContext.Files
                             .Where(f => f.Id == fileId && f.OwnerId == ownerUserId)
                             .FirstOrDefault();
        }
        public File? GetById(int fileId)
        {
            return DbContext.Files
                             .Where(f => f.Id == fileId)
                             .FirstOrDefault();
        }
        public File? GetFileByName(string name)
        {
            return DbContext.Files
                             .Where(f => f.Name == name)
                             .FirstOrDefault();
        }
        public void UpdateFileContent(int fileId, string newContent)
        {
            Console.WriteLine($"Ažuriranje sadržaja datoteke ID: {fileId}");
            var file = DbContext.Files.FirstOrDefault(f => f.Id == fileId);
            if (file != null)
            {
                file.Content = newContent;
                Console.WriteLine("Sadržaj datoteke je ažuriran u memoriji.");
                DbContext.SaveChanges(); // Spremi promjene
                Console.WriteLine("Promjene su spremljene u bazu.");
            }
            else
            {
                Console.WriteLine("Datoteka nije pronađena.");
            }
        }

    }
}
