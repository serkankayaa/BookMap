using System.Collections.Generic;
using System.Linq;
using BookStore.Dto;
using BookStore.Entity.Context;

namespace BookStore.Business.Services
{
    public class ResultService : IResultService
    {
        private BookDbContext _context;

        public ResultService(BookDbContext context)
        {
            this._context = context;
        }

        public List<DtoCount> GetFieldCount()
        {
            DtoCount data = new DtoCount();
            
            data.ShopCount = this._context.Shop.Select(c=> c.Name).Distinct().Count();
            data.BookCount = this._context.Book.Select(c=> c.Name).Distinct().Count();
            data.PublisherCount = this._context.Publisher.Select(c=> c.Name).Distinct().Count();
            data.AuthorCount = this._context.Author.Select(c=> c.Name).Distinct().Count();
            data.CategoryCount = this._context.Category.Select(c=> c.Name).Distinct().Count();

            List<DtoCount> dataCount = new List<DtoCount>();

            dataCount.Add(data);

            return dataCount;
        }
    }
}