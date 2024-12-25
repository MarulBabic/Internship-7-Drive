using Data.Entities.Models;
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

        public void Delete(int sharedItemId, int userId)
        {

            var sharedFile = DbContext.SharedItems
                                      .FirstOrDefault(sf => sf.Id == sharedItemId && sf.OwnerUserId == userId);
            if (sharedFile != null)
            {
                DbContext.SharedItems.Remove(sharedFile);
                SaveChanges();
            }
        }
    }
}
