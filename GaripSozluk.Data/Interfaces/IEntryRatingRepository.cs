using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Interfaces
{
    public interface IEntryRatingRepository : IBaseRepository<EntryRating>
    {
        IQueryable<EntryRating> GetAllByCategoryId(int id);
    }
}
