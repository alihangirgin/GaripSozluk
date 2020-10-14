using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GaripSozluk.Business.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        public PostCategoryService(IPostCategoryRepository postCategoryRepository)
        {
            _postCategoryRepository = postCategoryRepository;
        }

        public PostCategoryViewModel AddPostCategory(PostCategoryViewModel model)
        {
            var postCategory = new PostCategory()
            {
                Title = model.Title
            };
            postCategory.CreateDate = DateTime.Now;
            postCategory.UpdateDate = DateTime.Now;
            //postCategory.UserId = 1;
            //postCategory.CategoryId = 1;
            //postCategory.ClickCount = 1;


            var entity = _postCategoryRepository.Add(postCategory);

            try
            {
                _postCategoryRepository.SaveChanges();
                return new PostCategoryViewModel() { Id = entity.Id, Title = entity.Title };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        //public PostViewModel UpdatePost(PostViewModel postViewModel)
        //{
        //    var model = _postRepository.Get(x => x.Id == postViewModel.Id);
        //    model.Title = postViewModel.Title;
        //    model.UpdateDate = DateTime.Now;


        //    try
        //    {
        //        var entity = _postRepository.Update(model);

        //        _postRepository.SaveChanges();
        //        return new PostViewModel() { Id = entity.Id, Title = entity.Title };
        //    }
        //    catch (Exception ex)
        //    {
        //        var errorMessage = ex.Message;
        //        throw;
        //    }
        //}

        public PostCategory Get(Expression<Func<PostCategory, bool>> expression)
        {

            return _postCategoryRepository.Get(expression);
        }

        public IQueryable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public PostCategoryViewModel UpdatePostCategory(PostCategoryViewModel model)
        {
            throw new NotImplementedException();
        }


        public List<SelectListItem> selectListItem(int id)
        {
            var newListRow = new List<SelectListItem>();
            var categories = _postCategoryRepository.GetAll();
            foreach (var item in categories)
            {
                var newList = new SelectListItem();
                if(item.Id==id)
                {
                    newList.Selected = true;
                }
                newList.Text = item.Title;
                newList.Value = item.Id.ToString();
                newListRow.Add(newList);
            }
            return newListRow;
        }
    }
}
