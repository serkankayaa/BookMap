using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region AuthorController
namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        #endregion

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        #region Author_GetAll
        // GET: /Author
        [HttpGet]
        public List<DtoAuthor> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        #region Author_GetById
        // GET: /Author/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoAuthor GetAuthor(Guid id)
        {
            return _authorService.GetAuthor(id);
        }
        #endregion
        #endregion

        #region Author_Create
        // POST: /Author
        [HttpPost]
        public object PostAuthor(DtoAuthor model)
        {
            return _authorService.PostAuthor(model);
        }
        #endregion

        #region Author_Update
        // PUT: /Author/
        [HttpPut]
        public object UpdateAuthor(DtoAuthor model)
        {
            return _authorService.UpdateAuthor(model);
        }
        #endregion

        #region Author_Delete
        // DELETE: /Author/
        [HttpDelete]
        public bool DeleteAllAuthors()
        {
            return _authorService.DeleteAllAuthors();
        }

        #region Author_DeleteById
        // DELETE: /Author/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteAuthor(Guid id)
        {
            return _authorService.DeleteAuthor(id);
        }
        #endregion
        #endregion
    }
}