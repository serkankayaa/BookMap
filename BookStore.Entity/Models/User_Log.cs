using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("USER_LOG")]
    public class UserLog
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("USER_ID_FK")]
        [Required]
        [ForeignKey("User")]
        public Guid UserIdFk { get; set; }

        [Column("LOGIN_DATE")]
        [Required]
        public DateTime LoginDate { get; set; }

        [Column("LOGOUT_DATE")]
        public DateTime LogoutDate { get; set; }

        [Column("TOKEN")]        
        public string Token { get; set; }

        [Column("CREATED_BY")]                
        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Column("CREATED_DATE")]                
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("UPDATED_BY")]
        [MaxLength]                
        public string UpdatedBy { get; set; }

        [Column("UPDATED_DATE")]                
        public DateTime UpdatedDate { get; set; }

        public User User { get; set; }
    }
}