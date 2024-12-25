using Data.Entities.Models;
using File = Data.Entities.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<File> GetFilesByUser(int userId)
        {
            return DbContext.Files.Where(f => f.OwnerId == userId).OrderByDescending(f => f.UpdatedAt).ToList();
        }
    }
}
