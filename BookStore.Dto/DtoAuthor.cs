using System;

namespace BookStore.Dto
{
    public class DtoAuthor
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
    }
}
