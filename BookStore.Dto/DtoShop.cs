using System;

namespace BookStore.Dto
{
    public class DtoShop
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public string Location { get; set; }
        public int StaffCount { get; set; }
    }
}
