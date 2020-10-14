using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IBlockedUserService
    {
        void AddBlock(UserBlockVM model);
        BlockedUser Get(Expression<Func<BlockedUser, bool>> expression);
        IQueryable<BlockedUser> GetAll(int id);
        void RemoveBlock(UserBlockVM model);
    }
}
