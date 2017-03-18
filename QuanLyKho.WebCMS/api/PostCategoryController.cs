using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Model.Entities;
using QuanLyKho.Service;
using QuanLyKho.WebCMS.Infrastructure.Extenssions;
using QuanLyKho.WebCMS.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyKho.WebCMS.Api
{
    [Route("api/PostCategory")]
    public class PostCategoryController : Controller
    {
        private IPostCategoryService _postCategoryService;

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