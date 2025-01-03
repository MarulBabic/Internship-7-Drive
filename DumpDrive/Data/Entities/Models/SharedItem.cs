using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class SharedItem
    {
        public int Id { get; set; }
        public int OwnerUserId { get; set; }
        public int SharedUserId { get; set; }
        public DateTime SharedAt { get; set; }
        public Data.Enums.ItemType SharedItemType { get; set; }
        public int? FileId {  get; set; }
        public int? FolderId { get; set; }

        public User OwnerUser { get; set; }
        public User SharedUser { get; set; }

    }
}
