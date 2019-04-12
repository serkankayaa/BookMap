using BookStore.Dto;
using System;
using System.Collections.Generic;

namespace BookStore.Business.Services
{
    public interface IBookService
    {
        DtoBook GetBook(Guid id);
        List<DtoBook> GetBooks();
        void BookAdd(DtoBook model);
        DtoBook UpdateBook(DtoBook model);
        bool DeleteBook(Guid id);
        object GetBookAuthor(Guid id);
    }
}
