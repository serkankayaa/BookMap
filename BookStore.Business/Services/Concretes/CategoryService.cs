using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class CategoryService : EFRepository<Category>, ICategoryService
    {
        #region Field

        private BookDbContext _context;
        public IAuthorService _authorService;

        #endregion

        #region Ctor

        public CategoryService(BookDbContext context, IAuthorService authorService) : base(context)
        {
            _context = context;
            _authorService = authorService;
        }
        #endregion

        #region Method

        /// <summary>
        /// Get Category with specific
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DtoCategory GetCategory(Guid id)
        {

            var categoryItem = this.GetById(id);

            DtoCategory category = new DtoCategory();

            category.CATEGORY_ID = categoryItem.CATEGORY_ID;
            category.CATEGORY_NAME = categoryItem.NAME;
            category.CATEGORY_SUMMARY = categoryItem.SUMMARY;
            category.IS_MAIN_CATEGORY = categoryItem.IS_MAIN_CATEGORY;

            return category;
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public List<DtoCategory> GetCategories()
        {

            var categories = base.GetAll();

            var totalCategories = categories.Select(c => new DtoCategory()
            {
                CATEGORY_ID = c.CATEGORY_ID,
                CATEGORY_NAME = c.NAME,
                CATEGORY_SUMMARY = c.SUMMARY,
                IS_MAIN_CATEGORY = c.IS_MAIN_CATEGORY,
            }).ToList();

            return totalCategories;
        }

        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="model"></param>
        public object PostCategory(DtoCategory model)
        {
            var isCategoryExists = _context.Category.Where(c => c.NAME == model.CATEGORY_NAME).Any();

            if (isCategoryExists)
            {
                return false;
            }

            Category category = new Category();
            category.NAME = model.CATEGORY_NAME;
            category.SUMMARY = model.CATEGORY_SUMMARY;
            category.IS_MAIN_CATEGORY = true;

            this.Add(category);
            this.Save();

            model.CATEGORY_ID = category.CATEGORY_ID;

            return model;
        }

        public object UpdateCategory(DtoCategory model)
        {
            var isCategoryExists = _context.Category.Where(c => c.NAME == model.CATEGORY_NAME).Any();

            if (isCategoryExists)
            {
                return false;
            }

            Category category = this.GetById(model.CATEGORY_ID);
            category.CATEGORY_ID = model.CATEGORY_ID;
            category.NAME = model.CATEGORY_NAME;
            category.SUMMARY = model.CATEGORY_SUMMARY;
            category.IS_MAIN_CATEGORY = model.IS_MAIN_CATEGORY;

            this.Update(category);
            this.Save();

            return model;
        }
        public bool DeleteCategory(Guid id)
        {
            try
            {
                Category category = this.GetById(id);
                this.Delete(category);
                this.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public object GetCategoryBooks(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}