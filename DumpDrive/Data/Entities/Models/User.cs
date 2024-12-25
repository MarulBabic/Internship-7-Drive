using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }

        public User(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }

        public User() { }


        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
        public ICollection<File> Files { get; set; } = new List<File>();
        public ICollection<SharedItem> SharedItems { get; set; } = new List<SharedItem>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
