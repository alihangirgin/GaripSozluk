using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class MainPageViewModel
    {
        public PostListVM SelectedPostWithEntries { get; set; }
        public PostCategoryViewModel SelectedCategory { get; set; }
        public List<PostCategoryViewModel> CategoryList { get; set; }
        public List<PostViewModel> PostList { get; set; }
        public UserClaimViewModel UserInfo { get; set; }
    }
}
