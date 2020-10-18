using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class LogViewModel
    {
        public List<LogViewModelFilter> LogFilterList { get; set; }
        public List<LogRowVM> LogList { get; set; }
        public DateTime? DateOne { get; set; }
        public DateTime? DateTwo { get; set; }

    }
}
