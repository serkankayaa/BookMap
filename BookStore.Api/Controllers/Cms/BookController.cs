using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region BookController

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        #endregion

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #region Book_GetAll
        // GET: /Book
        [HttpGet]
        public List<DtoBook> GetBooks()
        {
            return _bookService.GetBooks();
        }

        #region Book_GetById
        // GET: /Book/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoBook GetBook(Guid id)
        {
            return _bookService.GetBook(id);
        }

        #region AuthorBooks_GetById

        // GET: /Book/5/author
        [Route("{id:Guid}/author")]
        [HttpGet]
        public object GetBooksByAuthor(Guid id)
        {
            return _bookService.GetBooksByAuthor(id);
        }
        #endregion
        #endregion
        #endregion

        #region Book_Create
        // POST: /Book
        [HttpPost]
        public void PostBook(DtoBook model)
        {
            _bookService.PostBook(model);
        }
        #endregion

        #region Book_Update
        // PUT: /Book
        [HttpPut]
        public object UpdateBook(DtoBook model)
        {
            return _bookService.UpdateBook(model);
        }
        #endregion

        #region Book_DeleteById
        // DELETE: /Book/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public object DeleteBook(Guid id)
        {
            return _bookService.DeleteBook(id);
        }

        #endregion
    }
}