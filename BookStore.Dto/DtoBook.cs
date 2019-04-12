using System;

namespace BookStore.Dto
{
    public class DtoBook
    {
        public Guid BOOK_ID { get; set; }
        public string NAME { get; set; }
        public string SUMMARY { get; set; }
        public Guid AUTHOR_ID_FK { get; set; }
        public Guid PUBLISHER_ID_FK { get; set; }
    }
}
