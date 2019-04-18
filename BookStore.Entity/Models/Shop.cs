using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class Shop {

        [Key]
        public Guid SHOP_ID { get; set; }

        [Required(ErrorMessage = "Shop Name is required")]
        [MaxLength(250)]        
        public string SHOP_NAME { get; set; }

        public string LOCATION { get; set; }

        public int STAFF_COUNT { get; set; }
    }
}