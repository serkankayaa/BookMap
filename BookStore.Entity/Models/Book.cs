using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("BOOK")]
    public class Book
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("NAME")]
        [Required(ErrorMessage = "Book name is required")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column("SUMMARY")]
        [Required(ErrorMessage = "Summary of book is required")]
        public string Summary { get; set; }

        [Column("AUTHOR_ID_FK")]
        [Required]
        [ForeignKey("Author")]
        public Guid AuthorIdFk { get; set; }

        [Column("PUBLISHER_ID_FK")]
        [Required]
        [ForeignKey("Publisher")]
        public Guid PublisherIdFk { get; set; }

        [Column("CATEGORY_ID_FK")]        
        [Required]
        [ForeignKey("Category")]
        public Guid CategoryIdFk { get; set; }

        [Column("SHOP_ID_FK")]                
        [Required]
        [ForeignKey("Shop")]
        public Guid ShopIdFk { get; set; }

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

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public Shop Shop { get; set; }
        public Document Document { get; set; }

        // public ICollection<User_Book> User_Books { get; set; }
    }
}
