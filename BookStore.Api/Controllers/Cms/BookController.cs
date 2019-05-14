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

        [Route("api/Book/{id:Guid}")]
        [HttpGet]
        public DtoBook GetBook(Guid id)
        {
            return _bookService.GetBook(id);
        }

        [Route("api/GetAllBook")]
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

        [Route("api/GetBookAuthor/{id:Guid}")]
        [HttpGet]
        public object GetBookAuthor(Guid id)
        {
            return _bookService.GetBookAuthor(id);
        }

        #endregion
    }
}