using System;

namespace BookStore.Dto
{
    public class DtoSupplier
    {
        public Guid SupplierId { get; set; }
        public String SupplierName { get; set; }
        public String SupplierRegion { get; set; }
    }
}