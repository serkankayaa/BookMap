using System;

namespace BookStore.Dto
{
    public class DtoPublisher
    {
        public Guid PUBLISHER_ID { get; set; }
        public string NAME { get; set; }
        public string LOCATION { get; set; }
        public Guid SUPPLIER_ID_FK { get; set; }
        public string SUPPLIER_NAME { get; set; }
    }
}
