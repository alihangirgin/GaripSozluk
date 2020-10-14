using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Domain
{
    public class PostCategory : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
