using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        #region ApiMethods

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

        [Route("api/UpdateAuthor")]
        [HttpPut]
        public object UpdateAuthor(DtoAuthor model)
        {
            return _authorService.UpdateAuthor(model);
        }

        [Route("api/DeleteAuthor/{id:Guid}")]
        [HttpDelete]
        public bool DeleteAuthor(Guid id)
        {
            return _authorService.DeleteAuthor(id);
        }

        #endregion
    }
}