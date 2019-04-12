using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class Book
    {
        [Key]
        public Guid BOOK_ID { get; set; }

        [Required(ErrorMessage = "Book name is required")]
        [MaxLength(250)]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Summary of book is required")]
        public string SUMMARY { get; set; }

        [Required]
        [ForeignKey("Author")]
        public Guid AUTHOR_ID_FK { get; set; }

        [Required]
        [ForeignKey("Publisher")]
        public Guid PUBLISHER_ID_FK { get; set; }

        [Required]
        [ForeignKey("Account")]
        public Guid ACCOUNT_ID_FK { get; set; }

        public Author Author = new Author();
        public Publisher Publisher = new Publisher();
        public Account Account = new Account();
    }
}
