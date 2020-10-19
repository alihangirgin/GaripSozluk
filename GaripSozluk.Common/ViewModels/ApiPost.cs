using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaripSozluk.Common.ViewModels
{
    public class ApiPost
    {
        public string Title { get; set; }
        public int UserId { get; set; }

        public int ClickCount { get; set; }
        public int CategoryId { get; set; }
    }
}
