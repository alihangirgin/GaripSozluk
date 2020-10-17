using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
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



    }
}
