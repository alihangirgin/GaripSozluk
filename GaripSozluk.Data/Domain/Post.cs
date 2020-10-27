using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string NormalizedTitle { get; set; }

        public int UserId { get; set; }

        public int ClickCount { get; set; }
        public int CategoryId { get; set; }


        public virtual PostCategory Category { get; set; }
        public User User { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
