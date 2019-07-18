using System;

namespace BookStore.Dto
{
    public class DtoCategory
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySummary { get; set; }
        public bool IsMainCategory { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}