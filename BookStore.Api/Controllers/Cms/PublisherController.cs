using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region PublisherController
namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        #endregion

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        #region Category_GetAll
        // GET: /Publisher
        [HttpGet]
        public List<DtoPublisher> GetPublisher()
        {
            return _publisherService.GetPublishers();
        }

        #region Publisher_GetById
        // GET: /Publisher/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoPublisher GetPublisher(Guid id)
        {
            return _publisherService.GetPublisher(id);
        }
        #endregion
        #endregion

        #region Publisher_Create
        // POST: /Publisher/
        [HttpPost]
        public object PostPublisher(DtoPublisher model)
        {
            return _publisherService.PostPublisher(model);
        }
        #endregion

        #region Publisher_Update
        // PUT: /Publisher/
        [HttpPut]
        public object UpdatePublisher(DtoPublisher model)
        {
            return _publisherService.UpdatePublisher(model);
        }
        #endregion

        #region Publisher_Delete
        // DELETE: /Publisher/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeletePublisher(Guid id)
        {
            return _publisherService.DeletePublisher(id);
        }
        #endregion
    }
}