using System;

namespace BookStore.Dto
{
    public class DtoCategory
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySummary { get; set; }
        public bool IsMainCategory { get; set; }
    }
}