using System;

namespace BookStore.Dto
{
    public class DtoBook
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string Summary { get; set; }
        public Guid AuthorIdFk { get; set; }
        public string AuthorName { get; set; }
        public Guid PublisherIdFk { get; set; }
        public string PublisherName { get; set; }
        public Guid CategoryIdFk { get; set; }
        public string CategoryName { get; set; }
        public Guid ShopIdFk { get; set; }
        public string ShopName { get; set; }
        public Guid ImageIdFk { get; set; }
        public string ImageName { get; set; }
    }
}
