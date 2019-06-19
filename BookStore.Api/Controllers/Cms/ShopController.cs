using System;
using System.Collections.Generic;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;

#region ShopController
namespace BookStore.Api.Controllers.Cms
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        #endregion

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        #region Shop_GetAll
        // GET: /Shop
        [HttpGet]
        public List<DtoShop> GetAllShops()
        {

            return _shopService.GetShops();
        }

        #region Shop_GetById
        // GET: /Shop/5
        [Route("{id:Guid}")]
        [HttpGet]
        public object GetShop(Guid id)
        {
            return _shopService.GetShop(id);
        }
        #endregion
        #endregion

        #region Shop_Create
        // POST: /Shop/
        [HttpPost]
        public object PostShop(DtoShop model)
        {
            return _shopService.PostShop(model);
        }
        #endregion

        #region Shop_Update
        // PUT: /Shop/
        [HttpPut]
        public object UpdateShop(DtoShop model)
        {
            return _shopService.UpdateShop(model);
        }
        #endregion

        #region Shop_Delete
        // DELETE: /Shop/5
        [Route("{id:Guid}")]
        [HttpDelete]
        public bool DeleteShop(Guid id)
        {
            return _shopService.DeleteShop(id);
        }
        #endregion

    }
}