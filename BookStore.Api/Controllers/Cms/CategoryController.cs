using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /Category
        [HttpGet]
        public List<DtoCategory> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        // GET: /Category/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoCategory GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
        }

        [Route("/LastCategories")]
        [HttpGet]
        public object GetRecentlyCategory()
        {
            return _categoryService.GetRecentlyCategory();
        }

        // POST: /Category/
        [HttpPost]
        public object PostCategory(DtoCategory model)
        {
            return _categoryService.PostCategory(model);
        }

        // PUT: /Category/
        [HttpPut]
        public object UpdateCategory(DtoCategory model)
        {
            return _categoryService.UpdateCategory(model);
        }

        // DELETE: /Category/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteCategory(Guid id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}