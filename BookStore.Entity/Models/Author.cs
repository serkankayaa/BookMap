using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("AUTHOR")]
    public class Author
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required(ErrorMessage = "Author Name is required")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column("BIRTH_DATE")]
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Column("BIOGRAPHY")]
        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
