using System;

namespace BookStore.Dto
{
    public class DtoSupplier
    {
        public Guid SupplierId { get; set; }
        public String SupplierName { get; set; }
        public String SupplierRegion { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}