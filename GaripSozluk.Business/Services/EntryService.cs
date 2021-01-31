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
            var entry = new Entry();

            entry.Content = model.Content;
            entry.CreateDate = DateTime.Now;
            entry.UserId = model.UserId;
            entry.PostId = model.PostId;
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
            model.Content = entryViewModel.Content;
            model.UpdateDate = DateTime.Now;

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

    }
}
