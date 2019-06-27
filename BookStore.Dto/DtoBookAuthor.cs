using System;

namespace BookStore.Dto
{
    public class DtoBookAuthor
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookSummary { get; set; }
        public Guid AuthorIdFk { get; set; }
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
    }
}
