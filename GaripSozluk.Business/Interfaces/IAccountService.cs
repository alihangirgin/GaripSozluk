using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Business.Interfaces
{
    public interface IAccountService
    {
        UserClaimViewModel GetUserInfos();
    }
}
