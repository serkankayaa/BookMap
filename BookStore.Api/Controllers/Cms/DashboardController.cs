using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IResultService resultService;

        public DashboardController(IResultService _resultService)
        {
            this.resultService = _resultService;
        }

        [Route("Dashboard/DataCount")]
        [HttpGet]
        public List<DtoCount> GetFieldCount()
        {
            return resultService.GetFieldCount();
        }
    }
}