using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace GaripSozluk.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IEntryRepository _entryRepository;
        private readonly IEntryRatingService _entryRatingService;
        private readonly IBlockedUserService _blockedUserService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogService _logService;
        public PostService(IPostRepository postRepository, IEntryRepository entryRepository, IEntryRatingService entryRatingService, IHttpContextAccessor httpContext, IBlockedUserService blockedUserService, ILogService logService)
        {
            _postRepository = postRepository;
            _entryRepository = entryRepository;
            _entryRatingService = entryRatingService;
            _httpContext = httpContext;
            _blockedUserService = blockedUserService;
            _logService = logService;
        }

        //add post to database, currently non-used because of post must be added with first entry
        public PostViewModel AddPost(PostViewModel model)
        {
            var post = new Post();
            post.Title = model.Title;
            post.CreateDate = DateTime.Now;
            post.UpdateDate = DateTime.Now;
            post.UserId = model.UserId;
            post.CategoryId = model.Id;
            post.ClickCount = 0;

            var entity = _postRepository.Add(post);
            try
            {
                _postRepository.SaveChanges();
                return new PostViewModel() { Id = entity.Id, Title = entity.Title };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        //add post to database with first entry
        public int AddPostsWithEntry(PostViewModel model)
        {

            var isAddedBefore = _postRepository.Get(x => x.Title == model.Title);
            if (isAddedBefore == null)
            {
                return _postRepository.AddPostWithEntryRepo(model).Result;

            }
            return isAddedBefore.Id;
        }

        //add post to database from incoming api array 
        public void AddPostFromArray(string[] stringArray)
        {

            var user = _httpContext.HttpContext.User;
            var UserId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            foreach (var item in stringArray)
            {
                var post = new Post();
                if (item.EndsWith("(Kitap)"))
                {
                    post.CategoryId = 6;
                }
                else
                {
                    post.CategoryId = 7;
                }

                post.ClickCount = 0;
                post.Title = item;
                post.UserId = UserId;
                post.CreateDate = DateTime.Now;

                _postRepository.Add(post);
                _postRepository.SaveChanges();
            }
        }

        //gets random postId from posts
        public int GetRandomPostId()
        {
            var idList = _postRepository.GetAll().Select(x => x.Id).ToList();
            var randomIndex = new Random().Next(idList.Count - 1);
            var id = idList[randomIndex];
            return id;
        }
        public Post Get(Expression<Func<Post, bool>> expression)
        {
            return _postRepository.Get(expression);
        }
        public IQueryable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }
        public IQueryable<Post> GetAll(int id)
        {

            return _postRepository.GetAllWithEntries(id);
        }

        //Gets posts list with entries by selected category except for banned user's post(used in layout)
        public List<PostWithEntriesViewModel> GetPostListByCategoryWithEntries(int categoryId)
        {
            var user = _httpContext.HttpContext.User;
            int? UserId = null;
            List<int> blockedUserIdList = new List<int>();

            //gets blocked user list
            if (user.Claims.Count() > 0)
            {
                UserId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                foreach (var item in _blockedUserService.GetAll(UserId.Value))
                {
                    blockedUserIdList.Add(item.BlockedUserId);
                }
            }

            var List = new List<PostWithEntriesViewModel>();
            var postsWithEntries = _postRepository.GetAllWithEntries(categoryId).ToList();
            if (postsWithEntries != null)
            {
                foreach (var item in postsWithEntries)
                {
                    var postModel = new PostWithEntriesViewModel();
                    postModel.Post.Id = item.Id;
                    postModel.Post.CategoryId = item.CategoryId;
                    postModel.Post.UserId = item.UserId;
                    postModel.Post.Title = item.Title;
                    postModel.Post.ClickCount = item.ClickCount;
                    postModel.Post.UpdateDate = item.UpdateDate;
                    postModel.Post.CreateDate = item.CreateDate;
                    var entries = item.Entries.Where(x => !blockedUserIdList.Contains(x.UserId)).ToList();
                    if (entries != null)
                    {
                        foreach (var entry in entries)
                        {
                            var entryModel = new EntryViewModel();
                            entryModel.Content = entry.Content;
                            entryModel.CreateDate = entry.CreateDate;
                            entryModel.UpdateDate = entry.UpdateDate;
                            entryModel.Id = entry.Id;
                            entryModel.PostId = entry.PostId;
                            entryModel.UserId = entry.UserId;
                            postModel.EntryList.Add(entryModel);
                        }
                    }
                    List.Add(postModel);
                }
            }
            return List;
        }

        //gets selected post with pagination except for banned user's post(used in the index)
        public PostWithEntriesWithPaginationViewModel GetSelectedPostWithEntries(int id, int currentPage = 1)
        {
            var user = _httpContext.HttpContext.User;
            int? UserId = null;
            List<int> blockedUserIdList = new List<int>();

            //gets blocked user list
            if (user.Claims.Count() > 0)
            {
                UserId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                foreach (var item in _blockedUserService.GetAll(UserId.Value))
                {
                    blockedUserIdList.Add(item.BlockedUserId);
                }

            }
            var itemSize = 5;
            var postListVM = new PostWithEntriesWithPaginationViewModel();
            var getPost = _postRepository.Get(x => x.Id == id);
            if (getPost != null)
            {
                postListVM.Post.Title = getPost.Title;
                getPost.ClickCount++;
                postListVM.Post.ClickCount = getPost.ClickCount;
                postListVM.Post.Id = id;
                postListVM.CurrentPage = currentPage;
                var itemCount = _entryRepository.GetAll(x => x.PostId == getPost.Id).Where(x => !blockedUserIdList.Contains(x.UserId)).Count();
                var pageCount = itemCount / itemSize + (itemCount % itemSize > 0 ? 1 : 0);
                postListVM.PreviousPage = currentPage - 1 > 0 ? currentPage - 1 : pageCount;
                postListVM.NextPage = currentPage + 1 <= pageCount ? currentPage + 1 : 1;
                postListVM.PageCount = pageCount;
                _postRepository.SaveChanges();

                var postEntries = _entryRepository.GetAll(x => x.PostId == getPost.Id).Include("User")
                    .Where(x => !blockedUserIdList.Contains(x.UserId))
                    .Skip((currentPage - 1) * itemSize)
                    .Take(itemSize)
                    .ToList();
                if (postEntries != null)
                {
                    foreach (var item in postEntries)
                    {
                        var entryModel = new EntryWithRatingViewModel();
                        entryModel.Content = item.Content;
                        entryModel.UserId = item.UserId;
                        entryModel.CreateDate = item.CreateDate;
                        entryModel.UpdateDate = item.UpdateDate;
                        entryModel.Id = item.Id;
                        entryModel.UserName = item.User.UserName;
                        entryModel.LikeCount = _entryRatingService.GetLikeCount(item.Id);
                        entryModel.DislikeCount = _entryRatingService.GetDislikeCount(item.Id);
                        postListVM.EntryList.Add(entryModel);
                        _entryRepository.SaveChanges();
                    }
                }

            }
            return postListVM;
        }

        //gets all posts according to given string text. Used in non-detailed search
        public List<PostViewModel> GetAllByString(string text)
        {
            var posts= _postRepository.GetAll(x => x.Title.Contains(text));
            var postListVM = new List<PostViewModel>();
            if(posts!=null)
            {
                foreach (var item in posts)
                {
                    var postModel = new PostViewModel();
                    postModel.CategoryId = item.CategoryId;
                    postModel.ClickCount = item.ClickCount;
                    postModel.CreateDate = item.CreateDate;
                    postModel.Id = item.Id;
                    postModel.Title = item.Title;
                    postModel.UpdateDate = item.UpdateDate;
                    postModel.UserId = item.UserId;
                    postListVM.Add(postModel);
                }
            }
            return postListVM;

        }

        //gets all post according to given detailed information. Used in detailed search
        public DetailedSearchViewModel GetAllDetailed(DetailedSearchViewModel detailedSearch)
        {
            DateTime? minDate;
            DateTime? maxDate;

            if (detailedSearch.DateOne.HasValue && detailedSearch.DateTwo.HasValue && detailedSearch.DateOne > detailedSearch.DateTwo)
            {
                minDate = detailedSearch.DateTwo;
                maxDate = detailedSearch.DateOne;
            }
            else
            {
                minDate = detailedSearch.DateOne;
                maxDate = detailedSearch.DateTwo;
            }

            var query = _postRepository.GetAll().Where(x => true);
            if (detailedSearch.Keyword != null)
            {
                query = query.Where(x => x.Title.Contains(detailedSearch.Keyword));
            }
            if (minDate.HasValue || maxDate.HasValue)
            {
                if (minDate.HasValue && maxDate == null)
                {
                    query = query.Where(x => x.CreateDate > minDate.Value);
                }
                else if (minDate == null && maxDate.HasValue)
                {
                    query = query.Where(x => x.CreateDate < maxDate.Value);
                }
                else
                {
                    query = query.Where(x => (x.CreateDate >= minDate.Value && x.CreateDate <= maxDate.Value));
                }
            }

            //todo: this can be enum
            if (detailedSearch.SortType == 1) //new to old
            {
                query = query.OrderByDescending(x => x.CreateDate);
                detailedSearch.DetailedSearchPostResults = new List<PostViewModel>();
                foreach (var item in query.ToList())
                {
                    var postResult = new PostViewModel();
                    postResult.Title = item.Title;
                    postResult.UserId = item.UserId;
                    postResult.ClickCount = item.ClickCount;
                    postResult.CategoryId = item.CategoryId;
                    postResult.Id = item.Id;
                    detailedSearch.DetailedSearchPostResults.Add(postResult);
                }

            }
            if (detailedSearch.SortType == 2) //old to new
            {
                query = query.OrderBy(x => x.CreateDate);
                detailedSearch.DetailedSearchPostResults = new List<PostViewModel>();
                foreach (var item in query.ToList())
                {
                    var postResult = new PostViewModel();
                    postResult.Title = item.Title;
                    postResult.UserId = item.UserId;
                    postResult.ClickCount = item.ClickCount;
                    postResult.CategoryId = item.CategoryId;
                    postResult.Id = item.Id;
                    detailedSearch.DetailedSearchPostResults.Add(postResult);
                }
            }

            return detailedSearch;
        }



        ////update post from database
        //public Post UpdatePost(Post postViewModel)
        //{
        //    var model = _postRepository.Get(x => x.Id == postViewModel.Id);
        //    //model.Title = postViewModel.Title;
        //    model.UpdateDate = DateTime.Now;
        //    model.ClickCount = postViewModel.ClickCount;

        //    try
        //    {
        //        var entity = _postRepository.Update(model);

        //        _postRepository.SaveChanges();
        //        return postViewModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        var errorMessage = ex.Message;
        //        throw;
        //    }
        //}

















 


        public void AddLogPosts()
        {

             _postRepository.AddLogPosts(_logService.GetAllByDate(DateTime.Now.AddDays(-1))).ConfigureAwait(true);


            //await using var transaction = await _context.Database.BeginTransactionAsync();
            //try
            //{
            //    var logPosts = _logService.GetAllByDate(DateTime.Now.AddDays(-1));
            //    var post = new Post();


            //    post.Title = DateTime.Now.AddDays(-1).ToShortDateString() + " günü log listesi(log)";
            //    post.CreateDate = DateTime.Now;
            //    post.UserId = 1;
            //    post.CategoryId = 8;
            //    post.ClickCount = 0;


            //    var entity = _postRepository.Add(post);


            //    _postRepository.SaveChanges();



            //    entity.Entries = new List<Entry>();
            //    foreach (var item in logPosts.LogList)
            //    {
            //        var entry = new Entry();
            //        entry.PostId = entity.Id;
            //        entry.UserId = 1;
            //        entry.CreateDate = DateTime.Now;
            //        entry.Content = item.CreateDate + " Tarihinde " + item.TraceIdentifier + " Trace Identiferlı " + item.ResponseStatusCode + " Cevap Statü Kodlu " + item.RequestMethod + " İstek Methodlu " + item.RequestPath + "İstek Yollu " + item.UserAgent + " Tarayıcıların Desteklediği " + item.RoutePath + " Rota Yollu " + item.IPAddress + " IP Adresli bir Logum ben ";

            //        entity.Entries.Add(entry);
            //    }


            //    _postRepository.SaveChanges();

            //    await transaction.CommitAsync();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}    

        }


            public void AddLogPostsFilter()
        {
            var logPosts = _logService.GetAllByDateCountBest(DateTime.Now.AddDays(-1));
            var post = new Post();


            post.Title = DateTime.Now.AddDays(-1).ToShortDateString() + " gününde en fazla istek yapılan adresle(log-request)";
            post.CreateDate = DateTime.Now;
            post.UserId = 1;
            post.CategoryId = 8;
            post.ClickCount = 0;


            var entity = _postRepository.Add(post);

            try
            {
                _postRepository.SaveChanges();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
            entity.Entries = new List<Entry>();
            foreach (var item in logPosts.LogFilterList)
            {
                var entry = new Entry();
                entry.PostId = entity.Id;
                entry.UserId = 1;
                entry.CreateDate = DateTime.Now;
                entry.Content = item.RequestPath + " adresine yapılan istek gün içerisinde " +item.Count + " defa çağrılmıştır.";

                entity.Entries.Add(entry);
            }


            try
            {
                _postRepository.SaveChanges();

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }

        }


        //public PostViewModel UpdatePost(PostViewModel model)
        //{
        //    throw new NotImplementedException();
        //}



    }
}
