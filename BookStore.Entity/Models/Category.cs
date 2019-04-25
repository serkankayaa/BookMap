using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class Category
    {
        [Key]
        public Guid CATEGORY_ID { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        [MaxLength(250)]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Summary of  category is required!")]
        [MaxLength(500)]
        public string SUMMARY { get; set; }

        public bool IS_MAIN_CATEGORY { get; set; }

        public ICollection<Book> books {get;set;}
    }
}