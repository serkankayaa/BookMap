using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region CategoryController
namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        #endregion

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region Category_GetAll
        // GET: /Category
        [HttpGet]
        public List<DtoCategory> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        #region Category_GetById
        // GET: /Category/5
        [Route("{id:Guid}")]
        [HttpGet]
        public DtoCategory GetCategory(Guid id)
        {
            return _categoryService.GetCategory(id);
        }
        #endregion
        #endregion

        #region Category_Create
        // POST: /Category/
        [HttpPost]
        public object PostCategory(DtoCategory model)
        {
            return _categoryService.PostCategory(model);
        }
        #endregion

        #region Category_Update
        // PUT: /Category/
        [HttpPut]
        public object UpdateCategory(DtoCategory model)
        {
            return _categoryService.UpdateCategory(model);
        }
        #endregion

        #region Category_Delete
        // DELETE: /Category/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteCategory(Guid id)
        {
            return _categoryService.DeleteCategory(id);
        }
        #endregion
    }
}