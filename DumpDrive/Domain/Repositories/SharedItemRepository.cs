using Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class SharedItemRepository : BaseRepository
    {
        public SharedItemRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }
        public void Add(SharedItem sharedFile)
        {
            DbContext.SharedItems.Add(sharedFile);
            SaveChanges();
        }

        public void Delete(int sharedItemId, int ownerUserId)
        {
            Console.WriteLine($"Attempting to delete SharedItem with ID: {sharedItemId} and OwnerUserId: {ownerUserId}");

            var sharedItem = DbContext.SharedItems
                                       .FirstOrDefault(si => si.Id == sharedItemId && si.OwnerUserId == ownerUserId);

            if (sharedItem != null)
            {
                Console.WriteLine($"Found shared item with ID: {sharedItem.Id}");
                DbContext.SharedItems.Remove(sharedItem);
                SaveChanges();
                Console.WriteLine($"Uspješno obrisano dijeljenje za ID: {sharedItem.Id}");
            }
            else
            {
                Console.WriteLine("Dijeljenje nije pronađeno.");
            }
        }


        public List<SharedItem> GetSharedItemsByUserId(int userId)
        {
            return DbContext.SharedItems
                          .Where(item => item.SharedUserId == userId)
                          .ToList();

        }

        public SharedItem GetSharedItemByFileId(int fileId, int ownerUserId, int userId)
        {
            return DbContext.SharedItems
                             .FirstOrDefault(si => si.FileId == fileId
                                                  && si.OwnerUserId == ownerUserId
                                                  && si.SharedUserId == userId)
                             ?? new SharedItem(); // Return a new SharedItem if null
        }



        public SharedItem GetSharedItemByFolderId(int folderId, int ownerUserId, int userId)
        {
            return DbContext.SharedItems
                             .FirstOrDefault(si => si.FolderId == folderId
                                                && si.OwnerUserId == ownerUserId
                                                && si.SharedUserId == userId);
        }
        public void UpdateFileContent(int fileId, string newContent)
        {
            var file = DbContext.Files.FirstOrDefault(f => f.Id == fileId);
            if (file != null)
            {
                file.Content = newContent;
                DbContext.SaveChanges();
            }
        }






    }
}
