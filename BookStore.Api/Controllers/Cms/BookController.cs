using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #region ApiMethods

        [Route("api/GetBook/{id:Guid}")]
        [HttpGet]
        public DtoBook GetBook(Guid id)
        {
            return _bookService.GetBook(id);
        }

        [Route("api/GetAllBooks")]
        [HttpGet]
        public List<DtoBook> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [Route("api/PostBook")]
        [HttpPost]
        public void BookAdd(DtoBook model)
        {
            _bookService.BookAdd(model);
        }

        [Route("api/GetBooksByAuthor/{id:Guid}")]
        [HttpGet]
        public object GetBooksByAuthor(Guid id)
        {
            return _bookService.GetBooksByAuthor(id);
        }

        [Route("api/DeleteBook/{id:Guid}")]
        [HttpDelete]
        public object DeleteBook(Guid id)
        {
            return _bookService.DeleteBook(id);
        }

        [Route("api/UpdateBook")]
        [HttpPut]
        public object UpdateBook(DtoBook model)
        {
            return _bookService.UpdateBook(model);
        }

        #endregion
    }
}