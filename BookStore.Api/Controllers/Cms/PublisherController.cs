using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        #region ApiMethods

        [Route("api/GetPublisher/{id:Guid}")]
        [HttpGet]
        public DtoPublisher GetPublisher(Guid id)
        {
            return _publisherService.GetPublisher(id);
        }

        [Route("api/GetPublishers")]
        [HttpGet]
        public List<DtoPublisher> GetPublisher()
        {
            return _publisherService.GetPublishers();
        }

        [Route("api/PostPublisher")]
        [HttpPost]
        public object PostPublisher(DtoPublisher model)
        {
            return _publisherService.PublisherAdd(model);
        }

        [Route("api/UpdatePublisher")]
        [HttpPut]
        public object UpdatePublisher(DtoPublisher model)
        {
            return _publisherService.UpdatePublisher(model);
        }

        [Route("api/DeletePublisher/{id:Guid}")]
        [HttpDelete]
        public bool DeletePublisher(Guid id)
        {
            return _publisherService.DeletePublisher(id);
        }

        #endregion
    }
}