using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ApiPostController : ControllerBase
    {


        private readonly IPostService _postService;

        public ApiPostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public List<ApiPost> Get()
        {
            var getPost = new List<ApiPost>();
            var postData = _postService.GetAll().ToList();
            if(postData !=null)
            {
                foreach (var item in postData)
                {
                    var apiPost = new ApiPost();
                    apiPost.Title = item.Title;
                    apiPost.UserId = item.UserId;
                    apiPost.CategoryId = item.CategoryId;
                    apiPost.ClickCount = item.ClickCount;
                    getPost.Add(apiPost);
                }
            }

            return getPost;
            
        }
    }
}
