using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OwnerId { get; set; }
        public int FolderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User Owner { get; set; } = null!;
        public Folder Folder { get; set; }

    }
}
