using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("ERROR_LOG")]
    public class ErrorLog
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime ErrorTime { get; set; }

        [Required]
        public string ErrorMessage { get; set; }

        public string ErrorType { get; set; }

    }
}