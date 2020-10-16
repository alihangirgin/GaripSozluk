using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Common.ViewModels
{
    public class RestApiSearchVM
    {
        public String Keyword { get; set; }
        public int SearchType { get; set; }

        public bool IsAvailable { get; set; }

        public List<Doc> docs { get; set; }
    }
}
