using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class EntryRatingViewModel
    {

        public int EntryId { get; set; }
        public int UserId { get; set; }
        public bool IsLiked { get; set; }
    }
}
