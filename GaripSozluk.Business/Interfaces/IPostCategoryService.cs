using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IPostCategoryService
    {
        IQueryable<PostCategory> GetAll();
        List<PostCategoryViewModel> GetAllCategories();
        PostCategory Get(Expression<Func<PostCategory, bool>> expression);
        PostCategoryViewModel GetSelectedCategory(Expression<Func<PostCategory, bool>> expression);
        PostCategoryViewModel AddPostCategory(PostCategoryViewModel model);
        PostCategoryViewModel UpdatePostCategory(PostCategoryViewModel model);
        //PostViewModel UpdatePost(int id);

        List<SelectListItem> selectListItem(int id);

    }
}
