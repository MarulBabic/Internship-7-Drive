using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Folder folder)
        {
            DbContext.Folders.Add(folder);
            SaveChanges();
        }

        public void Delete(Folder folder)
        {
            DbContext.Folders.Remove(folder);
            SaveChanges();
        }

        public List<Folder> GetFoldersByUser(int userId)
        {
            return DbContext.Folders.Where(f => f.OwnerId == userId).OrderBy(f => f.Name).ToList();
        }

        public void Update(Folder folder, string name)
        {
            folder.Name = name;
            DbContext.Folders.Update(folder);
            SaveChanges();
        }

        public static Folder? GetFolder(List<Folder> userFolders,string name)
        {
            return userFolders.FirstOrDefault(f => f.Name == name);
        }
    }
}
