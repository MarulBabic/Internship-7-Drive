﻿using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Comment comment)
        {
            DbContext.Comments.Add(comment);
            SaveChanges();
        }

        public void Update(Comment comment)
        {
            DbContext.Comments.Update(comment);
            SaveChanges();
        }

        public void Delete(Comment comment)
        {
            DbContext.Comments.Remove(comment);
            SaveChanges();
        }
    }
}
