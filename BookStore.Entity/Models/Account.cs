using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class Account
    {
        [Key]
        public Guid ACCOUNT_ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string NAME { get; set; }

        [Required]
        public byte TYPE { get; set; }
    }
}
