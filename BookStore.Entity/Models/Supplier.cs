using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class Supplier
    {
        [Key]
        public Guid SUPPLIER_ID { get; set; }

        [Required]
        [MaxLength(250)]
        public String SUPPLIER_NAME { get; set; }

        [Required]
        [MaxLength(100)]
        public String SUPPLIER_REGION { get; set; }

        public ICollection<Publisher> Publishers { get; set; }
    }
}