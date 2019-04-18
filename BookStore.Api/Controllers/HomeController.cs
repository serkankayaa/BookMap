using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookStoreMap.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public HomeController(IBookService bookService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        #region Book Method

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

        #region Author Method

        [Route("api/Author/{id:Guid}")]
        [HttpGet]
        public DtoAuthor GetAuthor(Guid id)
        {
            return _authorService.GetAuthor(id);
        }

        [Route("api/GetAllAuthor")]
        [HttpGet]
        public List<DtoAuthor> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        [Route("api/PostAuthor")]
        [HttpPost]
        public object PostAuthor(DtoAuthor model)
        {
            return _authorService.AuthorAdd(model);
        }

        #endregion

        [Route("api/Publisher/id:Guid")]
        [HttpGet]
        public DtoPublisher GetPublisher(Guid id)
        {
            return _publisherService.GetPublisher(id);
        }

        [Route("api/GetAllPublisher")]
        [HttpGet]
        public List<DtoPublisher> GetPublisher()
        {
            return _publisherService.GetPublishers();
        }

        [Route("api/PostPublisher")]
        [HttpPost]
        public object PostPublisher(DtoPublisher model)
        {
           return _publisherService.PublisherAdd(model);
        }
    }
}
