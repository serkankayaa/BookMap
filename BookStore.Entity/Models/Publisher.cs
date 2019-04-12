using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
