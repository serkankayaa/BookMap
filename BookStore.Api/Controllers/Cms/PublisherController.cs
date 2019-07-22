using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: /Publisher
        [HttpGet]
        public List<DtoPublisher> GetPublisher()
        {
            return _publisherService.GetPublishers();
        }

        // GET: /Publisher/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoPublisher GetPublisher(Guid id)
        {
            return _publisherService.GetPublisher(id);
        }

        [Route("/RecentPublishers")]
        [HttpGet]
        public object GetRecentPublishers()
        {
            return _publisherService.GetRecentPublishers();
        }

        // POST: /Publisher/
        [HttpPost]
        public object PostPublisher(DtoPublisher model)
        {
            return _publisherService.PostPublisher(model);
        }

        // PUT: /Publisher/
        [HttpPut]
        public object UpdatePublisher(DtoPublisher model)
        {
            return _publisherService.UpdatePublisher(model);
        }

        // DELETE: /Publisher/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeletePublisher(Guid id)
        {
            return _publisherService.DeletePublisher(id);
        }
    }
}