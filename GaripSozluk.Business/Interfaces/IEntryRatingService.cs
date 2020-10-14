using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IEntryRatingService
    {

        void AddLike(EntryRatingViewModel model);
        void AddDislike(EntryRatingViewModel model);
        int GetLikeCount(int id);
        int GetDislikeCount(int id);
    }
}
