using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class Publisher
    {
        [Key]
        public Guid PUBLISHER_ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string NAME { get; set; }

        public string LOCATION { get; set; }

        public Guid SUPPLIER_ID_FK { get; set; }

        [ForeignKey("SUPPLIER_ID_FK")]
        public Supplier Supplier { get; set; }
    }
}
