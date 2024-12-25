using Data.Entities.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DumpDriveDbContext DbContext;

        protected BaseRepository(DumpDriveDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected ResponseType SaveChanges()
        {
            var hasChanges = DbContext.SaveChanges() > 0;
            if (hasChanges)
                return ResponseType.Success;

            return ResponseType.Unmodified;
        }
    }
}
