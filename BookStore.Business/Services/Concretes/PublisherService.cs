using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;
using AutoMapper;

namespace BookStore.Business.Services
{
    public class PublisherService : EFRepository<Publisher>, IPublisherService
    {
        private BookDbContext _context;
        private IMapper _mapper;

        public PublisherService(BookDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public DtoPublisher GetPublisher(Guid id)
        {
            var publisherItem = this.GetById(id);

            if (publisherItem == null)
            {
                return new DtoPublisher();
            }
            
            DtoPublisher publisher = _mapper.Map<Publisher, DtoPublisher>(publisherItem);

            return publisher;
        }

        public List<DtoPublisher> GetPublishers()
        {
            var publishers = this.GetAll();

            if (publishers == null || publishers.Count() == 0)
            {
                return new List<DtoPublisher>();
            }

            var allPublishers = publishers.Select(c => new DtoPublisher
            {
                PublisherId = c.Id,
                    PublisherName = c.Name,
                    Location = c.Location,
                    CreatedBy = c.CreatedBy,
                    CreatedDate = c.CreatedDate,
                    UpdatedBy = c.UpdatedBy,
                    UpdatedDate = c.UpdatedDate
            }).ToList();

            return allPublishers;
        }

        public object PostPublisher(DtoPublisher model)
        {
            if (model == null)
            {
                return new DtoPublisher();
            }

            Publisher publisher = new Publisher();
            publisher.Id = model.PublisherId;
            publisher.Name = model.PublisherName;
            publisher.Location = model.Location;
            publisher.CreatedBy = "Test:Safa";
            publisher.CreatedDate = DateTime.Now;

            this.Add(publisher);
            this.Save();

            model.PublisherId = publisher.Id;

            return model;
        }

        public object UpdatePublisher(DtoPublisher model)
        {
            if (model == null)
            {
                return new DtoPublisher();
            }

            var checkPublisher = _context.Publisher.Where(c => c.Name == model.PublisherName).Any();

            if (checkPublisher)
            {
                return false;
            }

            Publisher publisher = this.GetById(model.PublisherId);
            publisher.Id = model.PublisherId;
            publisher.Name = model.PublisherName;
            publisher.Location = model.Location;
            publisher.UpdatedBy = model.UpdatedBy;
            publisher.UpdatedDate = DateTime.Now;

            this.Update(publisher);
            this.Save();

            return model;
        }

        public object GetRecentPublishers()
        {
            return this._context.Publisher.Take(5).OrderByDescending(c => c.CreatedDate).Select(c => new { c.Name, c.Location, c.CreatedDate });
        }

        public bool DeletePublisher(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            Publisher publisher = this.GetById(id);

            this.Delete(publisher);
            this.Save();

            return true;
        }
    }
}