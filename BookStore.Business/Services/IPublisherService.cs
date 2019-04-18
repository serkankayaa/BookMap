using BookStore.Dto;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Services
{
    public interface IPublisherService
    {
        DtoPublisher GetPublisher(Guid id);
        List<DtoPublisher> GetPublishers();
        object PublisherAdd(DtoPublisher model);
    }
}
