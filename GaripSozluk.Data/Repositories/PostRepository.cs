using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly GaripSozlukDbContext _context;
        public PostRepository(GaripSozlukDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Post> GetAllWithEntries(int id)
        {
          return _context.Posts.Where(x => x.CategoryId == id).Include("Entries");       
        }

        public IQueryable<Post> GetAllByCategoryId(int id)
        {
            return GetAll().Where(x => x.CategoryId == id);
        }

        public async Task AddLogPosts(LogViewModel model)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            //using(var dbTransaction= _context.Database.BeginTransaction())
            //{

            //}

            try
            {

                var logPosts = model;
                var post = new Post();


                post.Title = DateTime.Now.AddDays(-1).ToShortDateString() + " günü log listesi(log)";
                post.CreateDate = DateTime.Now;
                post.UserId = 1;
                post.CategoryId = 8;
                post.ClickCount = 0;


                var entity = Add(post);


                int resultCount= SaveChanges();
                if(resultCount==-1)
                {
                    transaction.Rollback();
                }


                entity.Entries = new List<Entry>();
                foreach (var item in logPosts.LogList)
                {
                    var entry = new Entry();
                    entry.PostId = entity.Id;
                    entry.UserId = 1;
                    entry.CreateDate = DateTime.Now;
                    entry.Content = item.CreateDate + " Tarihinde " + item.TraceIdentifier + " Trace Identiferlı " + item.ResponseStatusCode + " Cevap Statü Kodlu " + item.RequestMethod + " İstek Methodlu " + item.RequestPath + "İstek Yollu " + item.UserAgent + " Tarayıcıların Desteklediği " + item.RoutePath + " Rota Yollu " + item.IPAddress + " IP Adresli bir Logum ben ";

                    entity.Entries.Add(entry);
                }


                resultCount = SaveChanges();
                if (resultCount == -1)
                {
                    transaction.Rollback();
                }



                await transaction.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }





        }


    }
}
