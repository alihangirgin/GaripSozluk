using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;


        public LogService(ILogRepository logRepository)
        {

            _logRepository = logRepository;
        }

        public void AddLog(Log log)
        {
            _logRepository.Add(log);
            _logRepository.SaveChanges();

        }


        //public IQueryable<Log> GetAll()
        //{
        //    return _logRepository.GetAll();
        //}


        public LogViewModel GetAll()
        {
            var model = new LogViewModel();
            model.LogList = new List<LogRowVM>();
            var log = _logRepository.GetAll();
            foreach (var item in log)
            {
                var logRowVM = new LogRowVM();
                logRowVM.TraceIdentifier = item.TraceIdentifier;
                logRowVM.ResponseStatusCode = item.ResponseStatusCode;
                logRowVM.RequestMethod = item.RequestMethod;
                logRowVM.RequestPath = item.RequestPath;
                logRowVM.UserAgent = item.UserAgent;
                logRowVM.RoutePath = item.RoutePath;
                logRowVM.IPAddress = item.IPAddress;
                logRowVM.CreateDate = item.CreateDate;

                model.LogList.Add(logRowVM);

            }

            return model;
        }


        public LogViewModel GetAll(LogViewModel detailedSearch)
        {

            //Filtreleme yapıldığında filtrelemeden önceki liste kaybolduğu için tekrar çağırdım.
            //var model = new LogViewModel();
            //model.LogList = new List<LogRowVM>();
            //var log = _logRepository.GetAll();
            //foreach (var item in log)
            //{
            //    var logRowVM = new LogRowVM();
            //    logRowVM.TraceIdentifier = item.TraceIdentifier;
            //    logRowVM.ResponseStatusCode = item.ResponseStatusCode;
            //    logRowVM.RequestMethod = item.RequestMethod;
            //    logRowVM.RequestPath = item.RequestPath;
            //    logRowVM.UserAgent = item.UserAgent;
            //    logRowVM.RoutePath = item.RoutePath;
            //    logRowVM.IPAddress = item.IPAddress;
            //    logRowVM.CreateDate = item.CreateDate;

            //    model.LogList.Add(logRowVM);

            //}

            var model = new LogViewModel();

            model.LogFilterList = new List<LogViewModelFilter>();

            DateTime? minDate;
            DateTime? maxDate;

            if (detailedSearch.DateOne.HasValue && detailedSearch.DateTwo.HasValue && detailedSearch.DateOne > detailedSearch.DateTwo)
            {
                minDate = detailedSearch.DateTwo;
                maxDate = detailedSearch.DateOne;
            }
            else
            {
                minDate = detailedSearch.DateOne;
                maxDate = detailedSearch.DateTwo;
            }

            var query = _logRepository.GetAll().Where(x => true);

            if (minDate.HasValue || maxDate.HasValue)
            {
                if (minDate.HasValue && maxDate == null)
                {
                    query = query.Where(x => x.CreateDate > minDate.Value);
                }
                else if (minDate == null && maxDate.HasValue)
                {
                    query = query.Where(x => x.CreateDate < maxDate.Value);
                }
                else
                {
                    query = query.Where(x => (x.CreateDate >= minDate.Value && x.CreateDate <= maxDate.Value));
                }
            }

            var filterQuery = query.ToList().GroupBy(x=>x.RequestPath).OrderByDescending(x=>x.Count()).Take(10);
            foreach (var item in filterQuery)
            {
                var logRowVM = new LogViewModelFilter();
                logRowVM.RequestPath = item.Key;
                logRowVM.Count = item.Count();
                model.LogFilterList.Add(logRowVM);
            }



            return model;
        }


        public LogViewModel GetAllByDate(DateTime date)
        {
           
            var model = new LogViewModel();
            model.LogList = new List<LogRowVM>();
            var log = _logRepository.GetAll().Where(x => x.CreateDate.Date == date.Date).ToList();
            foreach (var item in log)
            {
                var logRowVM = new LogRowVM();
                logRowVM.TraceIdentifier = item.TraceIdentifier;
                logRowVM.ResponseStatusCode = item.ResponseStatusCode;
                logRowVM.RequestMethod = item.RequestMethod;
                logRowVM.RequestPath = item.RequestPath;
                logRowVM.UserAgent = item.UserAgent;
                logRowVM.RoutePath = item.RoutePath;
                logRowVM.IPAddress = item.IPAddress;
                logRowVM.CreateDate = item.CreateDate;

                model.LogList.Add(logRowVM);

            }

            return model;
        }



        public LogViewModel GetAllByDateCountBest(DateTime date)
        {
            var model = new LogViewModel();
            model.LogFilterList = new List<LogViewModelFilter>();
            var query = _logRepository.GetAll().Where(x => x.CreateDate.Date == date.Date).ToList();
            var filterQuery = query.ToList().GroupBy(x => x.RequestPath).OrderByDescending(x => x.Count());
            foreach (var item in filterQuery)
            {
                var logRowVM = new LogViewModelFilter();
                logRowVM.RequestPath = item.Key;
                logRowVM.Count = item.Count();
                model.LogFilterList.Add(logRowVM);

            }

            return model;
        }


    }
}
