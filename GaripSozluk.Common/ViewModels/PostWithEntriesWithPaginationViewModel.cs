using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class PostWithEntriesWithPaginationViewModel
    {
        public PostWithEntriesWithPaginationViewModel()
        {
            Post = new PostViewModel();
            EntryList = new List<EntryWithRatingViewModel>();
        }
        public PostViewModel Post { get; set; }
        public List<EntryWithRatingViewModel> EntryList { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
    }
}
