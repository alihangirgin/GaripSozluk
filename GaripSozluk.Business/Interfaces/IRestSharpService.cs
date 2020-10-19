using GaripSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GaripSozluk.Business.Interfaces
{
    public interface IRestSharpService
    {
        RestApiSearchAuthorRowVM AuthorSearch(string authorName);
        
        RestApiSearchTitleRowVM TitleSearch(string title);

        RestApiSearchVM SearchApi(RestApiSearchVM model);
        RestApiSearchVM SearchPostApi(string itemText);

        List<ApiPost> ApiGetPost();
    }
}
