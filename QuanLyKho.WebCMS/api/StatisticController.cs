using Microsoft.AspNetCore.Mvc;
using QuanLyKho.Service;
using System;
using System.Net;
using System.Net.Http;

namespace QuanLyKho.WebCMS.Api
{
    //[Route("api/statistic")]
    //public class StatisticController : Controller
    //{
    //    private IStatisticService _statisticService;

    //    public StatisticController(IStatisticService statisticService) 
    //    {
    //        _statisticService = statisticService;
    //    }

    //    [Route("getrevenue")]
    //    [HttpGet]
    //    public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate, string toDate)
    //    {
    //        var model = _statisticService.GetRevenueStatistic(fromDate, toDate);
    //        HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
    //        return response;
    //    }
    //}
}