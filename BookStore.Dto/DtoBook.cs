using System;

namespace BookStore.Dto
{
    public class DtoBook
    {
        public Guid BOOK_ID { get; set; }
        public string NAME { get; set; }
        public string SUMMARY { get; set; }
        public Guid AUTHOR_ID_FK { get; set; }
        public string AUTHOR_NAME { get; set; }
        public Guid PUBLISHER_ID_FK { get; set; }
        public string PUBLISHER_NAME { get; set; }
        public Guid CATEGORY_ID_FK { get; set; }
        public string CATEGORY_NAME { get; set; }
        public Guid ACCOUNT_ID_FK { get; set; }
        public Guid SHOP_ID_FK { get; set; }
        public string SHOP_NAME { get; set; }
        public Guid IMAGE_ID_FK { get; set; }
        public string IMAGE_NAME { get; set; }
    }
}
