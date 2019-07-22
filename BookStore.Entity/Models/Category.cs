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

        [Column("CREATED_BY")]
        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Column("CREATED_DATE")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_BY")]
        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        [Column("UPDATED_DATE")]
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Book> books {get;set;}
    }
}