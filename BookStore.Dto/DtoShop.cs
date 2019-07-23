using System;

namespace BookStore.Dto
{
    public class DtoShop
    {
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
