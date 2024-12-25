using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; } = null!;
        public int FileId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public File File { get; set; }
        public User Owner { get; set; }

    }
}
