using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Service;
using QuanLyKho.Web.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyKho.WebCMS.Api
{
    [Route("[controller]")]
    public class PostCategoryController : Controller
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public void Get(HttpRequestMessage request)
        {
            var listCategory = _postCategoryService.GetAll();

            var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

        }
    }
}
