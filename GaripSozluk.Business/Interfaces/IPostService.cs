﻿using GaripSozluk.Common.ViewModels;
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
        IQueryable<Post> GetAll();
        IQueryable<Post> GetAll(int id);
        Post Get(Expression<Func<Post,bool>> expression);
        IQueryable<Post> GetAllByString(string text);
        PostViewModel AddPost(PostViewModel model);
        Post UpdatePost(Post postViewModel);
        //PostViewModel UpdatePost(int id);
        PostListVM GetPostById(int id,int currentPage,SearchViewModel searchModel=null);
        DetailedSearchViewModel GetAllDetailed(DetailedSearchViewModel detailedSearch);

        int GetRandomId();

    }
}