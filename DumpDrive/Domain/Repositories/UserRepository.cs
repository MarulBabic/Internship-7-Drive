using Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Data.Entities.Models.File;

namespace Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DumpDriveDbContext dbContext) : base(dbContext)
        {
        }

        public User? GetByEmail(string email)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email);
        }
        public User? GetById(int userId)
        {
            return DbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void Add(User user)
        {
            DbContext.Add(user);
            SaveChanges();
        }

        public void Update(User user)
        {
            DbContext.Users.Update(user);
            SaveChanges();
        }

        public void Delete(User user)
        {
            DbContext.Users.Remove(user);
            SaveChanges();
        }

        public bool Exists(string email)
        {
            return DbContext.Users.Any(u => u.Email == email);
        }

        public List<Folder> GetFolders(User user)
        {
            return DbContext.Folders.Where(f => f.OwnerId == user.Id).ToList();
        }

        public List<File> GetFiles(User user)
        {

            return DbContext.Files.Where(f => f.OwnerId == user.Id).ToList();
        }
        public List<User> GetAllUsers()
        {
            return DbContext.Users.ToList();
        }
    }
}