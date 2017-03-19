using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Model.Entities;
using QuanLyKho.Service;
using QuanLyKho.WebCMS.Infrastructure.Extenssions;
using QuanLyKho.WebCMS.Infrastructure.Responses;
using QuanLyKho.WebCMS.Models;

namespace QuanLyKho.WebCMS.Api
{
    //    [Route("api/product")]
    //    [Authorize]
    public class productcontroller : Controller
    {
        #region initialize

        private IProductService _productService;

        public productcontroller(IProductService productService)

        {
            this._productService = productService;
        }

        #endregion initialize

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);

            var response = new ListModelResponse<ProductViewModel>() as IListModelResponse<ProductViewModel>;

            try
            {
                response.PageSize = 0;
                response.PageNumber = 0;
                response.TotalPages = 0;
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
    }
}