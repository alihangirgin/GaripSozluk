using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IPostService
    {
        PostViewModel AddPost(PostViewModel model);
        int AddPostsWithEntry(PostViewModel model);
        void AddPostFromArray(string[] stringArray);
        int GetRandomPostId();
        List<PostWithEntriesViewModel> GetPostListByCategoryWithEntries(int categoryId);



        IQueryable<Post> GetAll();
        IQueryable<Post> GetAll(int id);

        PostWithEntriesWithPaginationViewModel GetSelectedPostWithEntries(int id, int currentPage = 1);
        //List<PostViewModel> GetPostListByCategory(int categoryId);
        Post Get(Expression<Func<Post,bool>> expression);
        List<PostViewModel> GetAllByString(string text);

        //Post UpdatePost(Post postViewModel);
        //PostViewModel UpdatePost(int id);

        DetailedSearchViewModel GetAllDetailed(DetailedSearchViewModel detailedSearch);



        void AddLogPosts();
        void AddLogPostsFilter();



    }
}
