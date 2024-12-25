using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public int? ParentFolderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public User Owner { get; set; } = null!;
        public ICollection<Folder> SubFolders { get; set; } = new List<Folder>();
        public Folder ParentFolder { get; set; } = null!;
        public ICollection<File> Files { get; set; } = new List<File>();

    }
}
