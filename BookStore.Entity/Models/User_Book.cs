using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class User_Book
    {
        [Key]
        [Column("USER_ID_FK", Order = 1)]
        [ForeignKey("User")]
        public Guid USER_ID_FK { get; set; }

        [Key]
        [Column("BOOK_ID_FK", Order = 2)]
        [ForeignKey("Book")]
        public Guid BOOK_ID_FK { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}