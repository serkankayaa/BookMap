using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class Category
    {
        [Key]
        public Guid CATEGORY_ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string NAME { get; set; }

        [Required]
        [MaxLength(500)]
        public string SUMMARY { get; set; }

        public bool IS_MAIN_CATEGORY { get; set; }

        public ICollection<Book> books {get;set;}
    }
}