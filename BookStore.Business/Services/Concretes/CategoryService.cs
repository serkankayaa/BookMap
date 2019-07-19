using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services
{
    public class CategoryService : EFRepository<Category>, ICategoryService
    {
        private BookDbContext _context;
        public IAuthorService _authorService;
        private IMapper _mapper;

        public CategoryService(BookDbContext context, IAuthorService authorService, IMapper mapper) : base(context)
        {
            _context = context;
            _authorService = authorService;
            _mapper = mapper;
        }

        public DtoCategory GetCategory(Guid id)
        {
            if (id == null)
            {
                return new DtoCategory();
            }

            var categoryItem = this.GetById(id);

            DtoCategory category = new DtoCategory();

            // category.CategoryId = categoryItem.Id;
            // category.CategoryName = categoryItem.Name;
            // category.CategorySummary = categoryItem.Summary;
            // category.IsMainCategory = categoryItem.IsMainCategory;
            // category.CreatedBy = categoryItem.CreatedBy;
            // category.CreatedDate = categoryItem.CreatedDate;
            // category.UpdatedBy = categoryItem.UpdatedBy;
            // category.UpdatedDate = categoryItem.UpdatedDate;

            category = _mapper.Map<Category, DtoCategory>(categoryItem);

            return category;
        }

        public List<DtoCategory> GetCategories()
        {
            var categories = base.GetAll();

            if (categories == null || categories.Count() == 0)
            {
                return new List<DtoCategory>();
            }

            var allCategories = categories.Select(c => new DtoCategory()
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                CategorySummary = c.Summary,
                IsMainCategory = c.IsMainCategory,
                CreatedBy = c.CreatedBy,
                CreatedDate = c.CreatedDate,
                UpdatedBy = c.UpdatedBy,
                UpdatedDate = c.UpdatedDate
            }).ToList();

            return allCategories;
        }

        public object PostCategory(DtoCategory model)
        {
            if (model == null)
            {
                return new DtoCategory();
            }

            var isCategoryExists = _context.Category.Where(c => c.Name == model.CategoryName).Any();

            if (isCategoryExists)
            {
                return false;
            }

            Category category = new Category();
            category.Name = model.CategoryName;
            category.Summary = model.CategorySummary;
            category.IsMainCategory = true;
            category.CreatedBy = model.CreatedBy;
            category.CreatedDate = DateTime.Now;

            this.Add(category);
            this.Save();

            model.CategoryId = category.Id;

            return model;
        }

        public object UpdateCategory(DtoCategory model)
        {
            if (model == null)
            {
                return new DtoCategory();
            }

            var checkCategory = _context.Category.Where(c => c.Name == model.CategoryName).Any();

            if (checkCategory)
            {
                return false;
            }

            Category category = this.GetById(model.CategoryId);
            category.Id = model.CategoryId;
            category.Name = model.CategoryName;
            category.Summary = model.CategorySummary;
            category.IsMainCategory = model.IsMainCategory;
            category.UpdatedBy = model.UpdatedBy;
            category.UpdatedDate = DateTime.Now;

            this.Update(category);
            this.Save();

            return model;
        }

        public bool DeleteCategory(Guid id)
        {
            if (id == null)
            {
                return false;
            }

            Category category = this.GetById(id);
            this.Delete(category);
            this.Save();

            return true;
        }

        public object GetCategoryBooks(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}