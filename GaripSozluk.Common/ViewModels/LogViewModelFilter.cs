using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class LogViewModelFilter
    {
        public int Count { get; set; }
        public string TraceIdentifier { get; set; }
        public string ResponseStatusCode { get; set; }
        public string RequestMethod { get; set; }  
        public string RequestPath { get; set; }  
        public string UserAgent { get; set; }
        public string RoutePath { get; set; }
        public string IPAddress { get; set; }


    }
}
