using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{
    public interface IResultService
    {
        List<DtoCount> GetFieldCount();
    }
}