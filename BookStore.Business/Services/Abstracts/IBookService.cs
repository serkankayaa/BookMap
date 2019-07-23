using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface IBookService
    {
        DtoBook GetBook(Guid id);
        List<DtoBook> GetBooks();
        object PostBook(DtoBook model);
        DtoBook UpdateBook(DtoBook model);
        bool DeleteBook(Guid id);
        object GetBooksByAuthor(Guid id);
        object GetRecentlyBook();
    }
}