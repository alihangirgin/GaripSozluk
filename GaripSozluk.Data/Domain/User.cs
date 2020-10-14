using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string FullName { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<EntryRating> Ratings { get; set; }
        public List<BlockedUser> BlockedUsers { get; set; }
    }
}
