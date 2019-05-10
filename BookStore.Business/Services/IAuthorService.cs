using BookStore.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Business.Services
{
    public interface IAuthorService
    {
        DtoAuthor GetAuthor(Guid id);
        List<DtoAuthor> GetAuthors();
        object AuthorAdd(DtoAuthor model);
        object UpdateAuthor(DtoAuthor model);
    }
}
