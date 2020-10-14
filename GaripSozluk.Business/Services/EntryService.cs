using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GaripSozluk.Business.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public EntryViewModel AddEntry(EntryViewModel model)
        {
            var entry = new Entry()
            {
                Content = model.Content
            };
            entry.CreateDate = DateTime.Now;
            entry.UpdateDate = DateTime.Now;
            entry.UserId = model.UserId;
            entry.PostId = model.Id;
            //entry.CategoryId = model.Id;
            //entry.ClickCount = 0;


            var entity = _entryRepository.Add(entry);

            try
            {
                _entryRepository.SaveChanges();
                return new EntryViewModel() { Id = entity.Id, Content = entity.Content };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public EntryViewModel UpdateEntry(EntryViewModel entryViewModel)
        {
            var model = _entryRepository.Get(x => x.Id == entryViewModel.Id);
            //model.Title = entryViewModel.Title;
            model.UpdateDate = DateTime.Now;
            //model.ClickCount = entryViewModel.ClickCount;

            try
            {
                var entity = _entryRepository.Update(model);

                _entryRepository.SaveChanges();
                return new EntryViewModel() { Id = entity.Id, Content = entity.Content };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public Entry Get(Expression<Func<Entry, bool>> expression)
        {
            return _entryRepository.Get(expression);
        }

        public IQueryable<Entry> GetAll()
        {

            return _entryRepository.GetAll();
        }

        public IQueryable<Entry> GetAll(int id)
        {

            return _entryRepository.GetAll(x => x.PostId == id);
        }




        //public EntryViewModel UpdateEntry(EntryViewModel model)
        //{
        //    throw new NotImplementedException();
        //}



    }
}
