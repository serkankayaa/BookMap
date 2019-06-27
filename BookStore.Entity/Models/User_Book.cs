using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("USER_BOOK")]
    public class UserBook
    {
        [Key]
        [Column("USER_ID_FK", Order = 1)]
        [ForeignKey("User")]
        public Guid UserIdFk { get; set; }

        [Key]
        [Column("BOOK_ID_FK", Order = 2)]
        [ForeignKey("Book")]
        public Guid BookIdFk { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
    }
}