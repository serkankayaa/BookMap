using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /Book
        [HttpGet]
        public List<DtoBook> GetBooks()
        {
            return _bookService.GetBooks();
        }

        // GET: /Book/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoBook GetBook(Guid id)
        {
            return _bookService.GetBook(id);
        }

        // GET: /Book/5/author
        [Route("{id:Guid}/author")]
        [HttpGet]
        public object GetBooksByAuthor(Guid id)
        {
            return _bookService.GetBooksByAuthor(id);
        }

        [Route("/LastBooks")]
        [HttpGet]
        public object GetRecentlyBook()
        {
            return _bookService.GetRecentlyBook();
        }

        // POST: /Book
        [HttpPost]
        public void PostBook(DtoBook model)
        {
            _bookService.PostBook(model);
        }

        // PUT: /Book
        [HttpPut]
        public object UpdateBook(DtoBook model)
        {
            return _bookService.UpdateBook(model);
        }

        // DELETE: /Book/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public object DeleteBook(Guid id)
        {
            return _bookService.DeleteBook(id);
        }
    }
}