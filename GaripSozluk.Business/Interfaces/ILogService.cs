using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface ILogService
    {
        void AddLog(Log log);
        //IQueryable<Log> GetAll();
        LogViewModel GetAll();

        LogViewModel GetAll(LogViewModel detailedSearch);


        LogViewModel GetAllByDate(DateTime date);
        LogViewModel GetAllByDateCountBest(DateTime date);


    }
}
