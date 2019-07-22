using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: /Author
        [HttpGet]
        public List<DtoAuthor> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        // GET: /Author/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoAuthor GetAuthor(Guid id)
        {
            return _authorService.GetAuthor(id);
        }

        [Route("/RecentAuthor")]
        [HttpGet]
        public object GetRecentAuthor()
        {
            return _authorService.GetRecentAuthor();
        }

        // POST: /Author
        [HttpPost]
        public object PostAuthor(DtoAuthor model)
        {
            return _authorService.PostAuthor(model);
        }

        // PUT: /Author/
        [HttpPut]
        public object UpdateAuthor(DtoAuthor model)
        {
            return _authorService.UpdateAuthor(model);
        }

        // DELETE: /Author/
        [HttpDelete]
        public bool DeleteAllAuthors()
        {
            return _authorService.DeleteAllAuthors();
        }

        // DELETE: /Author/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteAuthor(Guid id)
        {
            return _authorService.DeleteAuthor(id);
        }
    }
}