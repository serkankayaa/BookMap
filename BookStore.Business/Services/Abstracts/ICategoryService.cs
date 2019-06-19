using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface ICategoryService
    {
        DtoCategory GetCategory(Guid id);
        List<DtoCategory> GetCategories();
        object PostCategory(DtoCategory model);
        object UpdateCategory(DtoCategory model);
        bool DeleteCategory(Guid id);
        object GetCategoryBooks(Guid id);
    }
}