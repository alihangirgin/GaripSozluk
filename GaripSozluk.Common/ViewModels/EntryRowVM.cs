using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class EntryRowVM
    {
        public string Content { get; set; }

        public int EntryId { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }
        public int PostId { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }

        public DateTime CreateDate { get; set; }




    }
}
