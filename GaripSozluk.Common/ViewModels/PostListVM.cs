using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class PostListVM
    {
        public PostListVM()
        {
            EntryList = new List<EntryRowVM>();
        }

        public string Title { get; set; }

        public int ClickCount { get; set; }
        public  List<EntryRowVM> EntryList{ get; set; }

        public int PostId { get; set; }

        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
    }
}
