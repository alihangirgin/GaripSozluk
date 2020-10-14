using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IEntryService
    {
        IQueryable<Entry> GetAll();
        IQueryable<Entry> GetAll(int id);
        Entry Get(Expression<Func<Entry,bool>> expression);
        EntryViewModel AddEntry(EntryViewModel model);
        EntryViewModel UpdateEntry(EntryViewModel model);
        //EntryViewModel UpdateEntry(int id);


    }
}
