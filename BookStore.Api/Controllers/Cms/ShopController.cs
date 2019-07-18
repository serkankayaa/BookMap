using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: /Shop
        [HttpGet]
        public List<DtoShop> GetAllShops()
        {

            return _shopService.GetShops();
        }

        // GET: /Shop/5
        [Route("{id:Guid}")]
        [HttpGet]
        public object GetShop(Guid id)
        {
            return _shopService.GetShop(id);
        }

        // POST: /Shop/
        [HttpPost]
        public object PostShop(DtoShop model)
        {
            return _shopService.PostShop(model);
        }

        // PUT: /Shop/
        [HttpPut]
        public object UpdateShop(DtoShop model)
        {
            return _shopService.UpdateShop(model);
        }

        // DELETE: /Shop/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteShop(Guid id)
        {
            return _shopService.DeleteShop(id);
        }
    }
}