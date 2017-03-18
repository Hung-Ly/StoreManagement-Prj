using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Model.Entities;
using QuanLyKho.Service;
using QuanLyKho.WebCMS.Infrastructure.Extenssions;
using QuanLyKho.WebCMS.Infrastructure.Responses;
using QuanLyKho.WebCMS.Models;

namespace QuanLyKho.WebCMS.Api
{
    [Route("api/productcategories")]
    //[Authorize]
    public class ProductCategoryController : Controller
    {
        #region Initialize

        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)

        {
            this._productCategoryService = productCategoryService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll(int page, int pageSize = 3)
        {
            var model = _productCategoryService.GetAll();
            int totalRow = model.Count();

            var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
            var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
            try
            {
                //totalPage
                response.PageSize = pageSize;
                response.PageNumber = page;
                response.TotalPages = (int)Math.Ceiling((double)totalRow / pageSize);
                response.Model = responseData;

                response.Message = String.Format("Total of records: {0}", response.Model.Count());
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.ToHttpResponse();
        }

        //[Route("getbyid/{id:int}")]
        //[HttpGet]
        //public ProductCategoryViewModel GetById(HttpRequestMessage request, int id)
        //{
        //    var model = _productCategoryService.GetById(id);

        //    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
        //    return responseData;
        //}
    }
}