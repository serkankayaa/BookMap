using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region ApiMethods

        [Route("api/GetCategory/{id:Guid}")]
        [HttpGet]
        public DtoCategory GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
        }

        [Route("api/GetCategories")]
        [HttpGet]
        public List<DtoCategory> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [Route("api/PostCategory")]
        [HttpPost]
        public object CategoryAdd(DtoCategory model)
        {
            return _categoryService.CategoryAdd(model);
        }

        [Route("api/UpdateCategory")]
        [HttpPut]
        public object UpdateCategory(DtoCategory model)
        {
            return _categoryService.UpdateCategory(model);
        }

        [Route("api/DeleteCategory/{id}")]
        [HttpDelete]
        public bool DeleteCategory(Guid id)
        {
            return _categoryService.DeleteCategory(id);
        }

        #endregion

    }
}