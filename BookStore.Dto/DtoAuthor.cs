using System;

namespace BookStore.Dto
{
    public class DtoAuthor
    {
        public Guid AUTHOR_ID { get; set; }
        public string AUTHOR_NAME { get; set; }
        public DateTime BIRTH_DATE { get; set; }
        public string BIOGRAPHY { get; set; }
    }
}
