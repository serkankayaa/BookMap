using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("SHOP")]
    public class Shop {

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required(ErrorMessage = "Shop Name is required")]
        [MaxLength(250)]        
        public string Name { get; set; }

        [Column("LOCATION")]
        public string Location { get; set; }

        [Column("STAFF_COUNT")]
        public int StaffCount { get; set; }
        
        public ICollection<Book> books {get; set;}
    }
}