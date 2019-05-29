using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface IBookService
    {
        DtoBook GetBook(Guid id);
        List<DtoBook> GetBooks();
        void BookAdd(DtoBook model);
        DtoBook UpdateBook(DtoBook model);
        bool DeleteBook(Guid id);
        object GetBooksByAuthor(Guid id);
        object UploadBook(string contentType, string dbFile, string childPath);
    }
}