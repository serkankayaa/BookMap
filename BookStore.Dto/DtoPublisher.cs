using System;

namespace BookStore.Dto
{
    public class DtoPublisher
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Location { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
