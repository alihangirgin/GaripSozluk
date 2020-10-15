using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Business.Interfaces
{
    public interface IRestSharpService
    {
        RestApiSearchRowVM Search(string authorName);
    }
}
