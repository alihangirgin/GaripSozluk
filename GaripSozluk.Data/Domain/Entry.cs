using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class Entry : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }


        public virtual Post Post { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<EntryRating> Ratings { get; set; }
    }
}
