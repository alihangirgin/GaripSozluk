using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
    public class EntryRatingRepository : BaseRepository<EntryRating>, IEntryRatingRepository
    {
        private readonly GaripSozlukDbContext _context;
        public EntryRatingRepository(GaripSozlukDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<EntryRating> GetAllByCategoryId(int id)
        {
            return GetAll().Where(x => x.EntryId == id);
        }

    }
}
