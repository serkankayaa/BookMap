using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services 
{
    public interface IAuthorService 
    {
        DtoAuthor GetAuthor(Guid id);
        List<DtoAuthor> GetAuthors();
        object PostAuthor(DtoAuthor model);
        object UpdateAuthor(DtoAuthor model);
        bool DeleteAuthor(Guid id);
        bool DeleteAllAuthors();
        object GetRecentlyAuthor();
    }
}