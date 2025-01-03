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

        public void Update(Folder folder)
        {
            DbContext.Folders.Update(folder);
            SaveChanges();
        }
        public Folder? GetFolderById(int folderId)
        {
            return DbContext.Folders.FirstOrDefault(f => f.Id == folderId);
        }

        public static Folder? GetFolder(List<Folder> userFolders, string name)
        {
            return userFolders.FirstOrDefault(f => f.Name == name);
        }
        public Folder? GetFolderById(int folderId, int ownerUserId)
        {
            return DbContext.Folders
                             .Where(f => f.Id == folderId && f.OwnerId == ownerUserId)
                             .FirstOrDefault();
        }
        public Folder? GetFolderByName(string name, int ownerUserId)
        {
            return DbContext.Folders
                             .Where(f => f.Name == name && f.OwnerId == ownerUserId)
                             .FirstOrDefault();
        }
    }
}
