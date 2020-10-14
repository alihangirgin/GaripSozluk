using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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



    }
}
