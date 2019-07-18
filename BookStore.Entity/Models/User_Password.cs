using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("USER_PASSWORD")]
    public class UserPassword
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("USER_ID_FK")]        
        [Required]
        [ForeignKey("User")]
        public Guid UserIdFk { get; set; }

        [Column("PASSWORD_HASH")]                
        [Required]
        public string PasswordHash { get; set; }

        [Column("IS_ACTIVE")]                
        public bool IsActive { get; set; }

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
        public DateTime UpdatedDate { get; set; }

        public User User { get; set; }
    }
}