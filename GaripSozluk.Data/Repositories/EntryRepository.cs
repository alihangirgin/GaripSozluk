using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        private readonly GaripSozlukDbContext _context;
        public EntryRepository(GaripSozlukDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Entry> GetAllByCategoryId(int id)
        {
            return GetAll().Where(x => x.PostId == id);
        }
    }
}
