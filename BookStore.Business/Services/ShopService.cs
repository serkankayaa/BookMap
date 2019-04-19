using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;

namespace BookStore.Business.Services {

    public class ShopService : EFRepository<Shop>, IShopService
    {
        private BookDbContext _context;
        
        public ShopService(BookDbContext context) :base(context) {
            _context = context;
        }

        public object AddShop(DtoShop model)
        {
            Shop shop = new Shop();
            shop.SHOP_NAME = model.SHOP_NAME;
            shop.LOCATION = model.LOCATION;
            shop.STAFF_COUNT = model.STAFF_COUNT;

            this.Add(shop);
            this.Save();

            model.SHOP_ID = shop.SHOP_ID;
            
            return model;
        }

        public DtoShop GetShop(Guid id)
        {
            var shop = this.GetById(id);

            DtoShop model = new DtoShop();
            model.SHOP_NAME = shop.SHOP_NAME;
            model.LOCATION = shop.LOCATION;
            model.STAFF_COUNT = shop.STAFF_COUNT;
            model.SHOP_ID = shop.SHOP_ID;

            return model;
        }

        public List<DtoShop> GetShops()
        {
           var shops = this.GetAll();

           var totalShops = shops.Select(c => new DtoShop()
           {
               SHOP_ID = c.SHOP_ID,
               SHOP_NAME = c.SHOP_NAME,
               LOCATION = c.LOCATION,
               STAFF_COUNT = c.STAFF_COUNT
           }).ToList();

           return totalShops;
           
        }
    }
}