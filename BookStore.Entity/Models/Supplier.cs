using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class Supplier
    {
        [Key]
        public Guid SUPPLIER_ID { get; set; }

        [Required(ErrorMessage = "Supplier Name is required!")]
        [MaxLength(250)]
        public String SUPPLIER_NAME { get; set; }

        [Required(ErrorMessage = "Supplier Region is required!")]
        [MaxLength(100)]
        public String SUPPLIER_REGION { get; set; }

        public ICollection<Publisher> Publishers { get; set; }
    }
}