using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class DetailedSearchViewModel
    {
        public string Keyword { get; set; }
        public DateTime? DateOne { get; set; }
        public DateTime? DateTwo { get; set; }
        public int SortType { get; set; }

        public List<PostViewModel> DetailedSearchPostResults {get; set;}
    }
}
