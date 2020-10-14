using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class EntryRating : BaseEntity
    {
        public int EntryId { get; set; }
        public int UserId { get; set; }
        public bool IsLiked { get; set; }


        public virtual Entry Entry { get; set; }
        public User User { get; set; }
    }
}
