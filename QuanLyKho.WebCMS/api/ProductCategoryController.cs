using System;
using System.Collections.Generic;
using System.IO;
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

        [Route("getallparents")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productCategoryService.GetAll();
            int totalRow = model.Count();
           
            var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);

            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
            try
            {
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

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll( int page, string keyword,int pageSize = 3 )
        {
            var model = _productCategoryService.GetAll(keyword);
            int totalRow = model.Count();

            var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
            var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

            var response = new ListModelResponse<ProductCategoryViewModel>() as IListModelResponse<ProductCategoryViewModel>;
            try
            {
                response.PageSize = totalRow;
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

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody]ProductCategoryViewModel productCategoryVm)
        {
            var response = new SingleModelResponse<ProductCategoryViewModel>() as ISingleModelResponse<ProductCategoryViewModel>;
            try
            {
                var newProductCategory = new ProductCategory();
                newProductCategory.UpdateProductCategory(productCategoryVm);
                newProductCategory.CreatedDate = DateTime.Now;
                _productCategoryService.Add(newProductCategory);
                _productCategoryService.Save();

                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                response.Model = responseData;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.ToString();
            }

            return response.ToHttpResponse();
        }
    }
}