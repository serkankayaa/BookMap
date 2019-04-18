using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class Author
    {
        [Key]
        public Guid AUTHOR_ID { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [MaxLength(250)]
        public string AUTHOR_NAME { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BIRTH_DATE { get; set; }

        public string BIOGRAPHY { get; set; }
    }
}
