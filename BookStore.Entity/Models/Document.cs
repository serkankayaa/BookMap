using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity
{
    [Table("DOCUMENT")]
    public class Document
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("CONTENT_TYPE")]
        [Required]
        public string ContentType { get; set; }

        [Column("FULL_PATH")]
        [Required]
        public string FullPath { get; set; }

        [Column("FILE_NAME")]
        [Required]
        public string FileName { get; set; }

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
    }
}