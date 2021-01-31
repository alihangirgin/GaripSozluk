using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class PostWithEntriesViewModel
    {
        public PostWithEntriesViewModel()
        {
            Post = new PostViewModel();
            EntryList = new List<EntryViewModel>();
        }
        public PostViewModel Post { get; set; }
        public List<EntryViewModel> EntryList { get; set; }

    }
}
