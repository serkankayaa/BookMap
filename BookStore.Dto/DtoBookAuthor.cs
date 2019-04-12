using System;

namespace BookStore.Dto
{
    public class DtoBookAuthor
    {
        public Guid BOOK_ID { get; set; }
        public string BOOK_NAME { get; set; }
        public string BOOK_SUMMARY { get; set; }
        public Guid AUTHOR_ID_FK { get; set; }
        public string AUTHOR_NAME { get; set; }
        public DateTime BIRTH_DATE { get; set; }
        public string BIOGRAPHY { get; set; }
    }
}
