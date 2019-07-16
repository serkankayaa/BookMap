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

        [Column("DOCUMENT_ID_FK")]
        [ForeignKey("Document")]
        public Guid DocumetIdFk { get; set; }

        [Column("CREATED_BY")]
        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Column("CREATED_DATE")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_BY")]
        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        [Column("UPDATED_DATE")]
        public DateTime? UpdatedDate { get; set; }
        public Document Document { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
