using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("CATEGORY")]
    public class Category
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column("SUMMARY")]
        [Required]
        [MaxLength(500)]
        public string Summary { get; set; }

        [Column("IS_MAIN_CATEGORY")]
        public bool IsMainCategory { get; set; }

        public ICollection<Book> books {get;set;}
    }
}