using System;

namespace BookStore.Dto
{
    public class DtoAuthor
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Biography { get; set; }
        public Guid ImageIdFk { get; set; }
        public string ImageName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
