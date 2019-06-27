using System;

namespace BookStore.Dto
{
    public class DtoPublisher
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Location { get; set; }
        public Guid SupplierIdFk { get; set; }
        public string SupplierName { get; set; }
    }
}
