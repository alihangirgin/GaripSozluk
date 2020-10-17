using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface ILogService
    {
        void AddLog(Log log);
    }
}
