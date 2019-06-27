using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("PUBLISHER")]
    public class Publisher
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column("LOCATION")]
        public string Location { get; set; }

        [Column("SUPPLIER_ID_FK")]
        [Required]
        [ForeignKey("Supplier")]
        public Guid SupplierIdIFk { get; set; }
        
        public Supplier Supplier { get; set; }
    }
}
