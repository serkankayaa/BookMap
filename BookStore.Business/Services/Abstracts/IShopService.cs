using System;
using System.Collections.Generic;
using BookStore.Dto;

namespace BookStore.Business.Services
{

    public interface IShopService
    {

        DtoShop GetShop(Guid id);

        List<DtoShop> GetShops();

        object PostShop(DtoShop model);
        object UpdateShop(DtoShop model);
        bool DeleteShop(Guid id);
    }

}