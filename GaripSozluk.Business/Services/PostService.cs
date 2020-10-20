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


        public int GetRandomId()
        {
            var idList = _postRepository.GetAll().Select(x => x.Id).ToList();
            var randomIndex = new Random().Next(idList.Count - 1);
            var id = idList[randomIndex];
            return id;
        }

        public PostViewModel AddPost(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title
            };
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




        public void AddPostFromArrayBook(string[] stringArray)
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



        public Post UpdatePost(Post postViewModel)
        {
            var model = _postRepository.Get(x => x.Id == postViewModel.Id);
            //model.Title = postViewModel.Title;
            model.UpdateDate = DateTime.Now;
            model.ClickCount = postViewModel.ClickCount;

            try
            {
                var entity = _postRepository.Update(model);

                _postRepository.SaveChanges();
                return postViewModel;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
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


        public List<Post> GetAllCount(int id)
        {
            var user = _httpContext.HttpContext.User;
            int? UserId = null;
            List<int> blockedUserIdList = new List<int>();

            if (user.Claims.Count() > 0)
            {
                UserId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                foreach (var item in _blockedUserService.GetAll(UserId.Value))
                {
                    blockedUserIdList.Add(item.BlockedUserId);
                }
            }

            var List = new List<Post>();
            var query = _postRepository.GetAllWithEntries(id).ToList();
            foreach (var item in query)
            {
                var row = new Post();
                row.Id = item.Id;
                row.CategoryId = item.CategoryId;
                row.UserId = item.UserId;
                row.Title = item.Title;
                row.ClickCount = item.ClickCount;
                row.UpdateDate = item.UpdateDate;
                row.CreateDate = item.CreateDate;
                row.Entries = item.Entries.Where(x => !blockedUserIdList.Contains(x.UserId)).ToList();
                List.Add(row);


            }
            return List;
        }




        public IQueryable<Post> GetAllByString(string text)
        {

            return _postRepository.GetAll(x => x.Title.Contains(text));
        }

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

            //Todo: sorttype değişkeninin karşısındaki 1,2 gibi sayısal değerler yerine buralarda enum kullanabilirsin. proje geliştikçe bu 1 veya 2 neye karşılık geliyordu diye düşünmemek lazım. anlamlı bir enum prop adı koyabilirsin. mesela SortEnum.AscendingOrder=1, SortEnum.DescendingOrder = 2 gibi... kodda mümkün oldukça dümdüz sayısal değerler kullanmaktan ve string olarak metinsel ifadeler kullanmaktan kaçınmalıyız. (hardcoded string denir buna) uzak durmalıyız.
            if (detailedSearch.SortType == 1)
            {
                query = query.OrderByDescending(x => x.CreateDate);
                detailedSearch.DetailedSearchPosts = query.ToList();
            }
            if (detailedSearch.SortType == 2)
            {
                query = query.OrderBy(x => x.CreateDate);
                detailedSearch.DetailedSearchPosts = query.ToList();
            }

            return detailedSearch;
        }



        public PostListVM GetPostById(int id, int currentPage = 1, SearchViewModel searchModel = null)
        {

            var user = _httpContext.HttpContext.User;
            int? UserId = null;
            List<int> blockedUserIdList = new List<int>();

            if (user.Claims.Count() > 0)
            {
                UserId = int.Parse(user.Claims.ToList().First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                foreach (var item in _blockedUserService.GetAll(UserId.Value))
                {
                    blockedUserIdList.Add(item.BlockedUserId);
                }

            }

            var itemSize = 5;
            var postListVM = new PostListVM();
            var getPost = _postRepository.Get(x => x.Id == id);
            if (getPost != null)
            {
                postListVM.Title = getPost.Title;
                getPost.ClickCount++;
                postListVM.ClickCount = getPost.ClickCount;
                postListVM.PostId = id;
                postListVM.CurrentPage = currentPage;
                var itemCount = _entryRepository.GetAll(x => x.PostId == getPost.Id).Where(x => !blockedUserIdList.Contains(x.UserId)).Count();
                var pageCount = itemCount / itemSize + (itemCount % itemSize > 0 ? 1 : 0);
                postListVM.PreviousPage = currentPage - 1 > 0 ? currentPage - 1 : pageCount;
                postListVM.NextPage = currentPage + 1 <= pageCount ? currentPage + 1 : 1;
                postListVM.PageCount = pageCount;
                _postRepository.SaveChanges();
                //var numberOfEntries = itemCount;
                //postListVM.numberOfEntries = numberOfEntries;

                var postEntries = _entryRepository.GetAll(x => x.PostId == getPost.Id).Include("User")
                    .Where(x => !blockedUserIdList.Contains(x.UserId))
                    .Skip((currentPage - 1) * itemSize)
                    .Take(itemSize)
                    .ToList();
                if (postEntries != null)
                {
                    foreach (var item in postEntries)
                    {
                        var getEntry = new EntryRowVM();
                        getEntry.Content = item.Content;
                        getEntry.UserId = item.UserId;
                        getEntry.CreateDate = item.CreateDate;
                        getEntry.EntryId = item.Id;
                        getEntry.UserName = item.User.UserName;
                        getEntry.LikeCount = _entryRatingService.GetLikeCount(item.Id);
                        getEntry.DislikeCount = _entryRatingService.GetDislikeCount(item.Id);
                        postListVM.EntryList.Add(getEntry);
                        //item.Ratings.Where(x => x.IsLiked == true).Count()
                        _entryRepository.SaveChanges();
                    }
                }

            }


            return postListVM;
        }





        public void AddLogPosts()
        {
            var logPosts = _logService.GetAllByDate(DateTime.Now.AddDays(-1));
            var post = new Post();


            post.Title = DateTime.Now.AddDays(-1).ToShortDateString() + " günü log listesi(log)";
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
            foreach (var item in logPosts.LogList)
            {
                var entry = new Entry();
                entry.PostId = entity.Id;
                entry.UserId = 1;
                entry.CreateDate = DateTime.Now;
                entry.Content = item.CreateDate + " Tarihinde " + item.TraceIdentifier + " Trace Identiferlı " + item.ResponseStatusCode + " Cevap Statü Kodlu " + item.RequestMethod + " İstek Methodlu " + item.RequestPath + "İstek Yollu " + item.UserAgent + " Tarayıcıların Desteklediği " + item.RoutePath + " Rota Yollu " + item.IPAddress + " IP Adresli bir Logum ben " ;

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
                entry.Content = "/Log/List adresine yapılan istek gün içerisinde " +item.Count + " defa çağrılmıştır.";

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
