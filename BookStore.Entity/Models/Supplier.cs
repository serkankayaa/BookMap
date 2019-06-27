using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("SUPPLIER")]
    public class Supplier
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required]
        [MaxLength(250)]
        public String Name { get; set; }

        [Column("REGION")]
        [Required]
        [MaxLength(100)]
        public String SupplierRegion { get; set; }

        public ICollection<Publisher> Publishers { get; set; }
    }
}