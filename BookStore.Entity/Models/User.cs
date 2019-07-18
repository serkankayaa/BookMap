using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("EMAIL_ADDRESS")]        
        [Required]
        [MaxLength(250)]
        public string EmailAddress { get; set; }

        [Column("EMAIL_CONFIRMED")]
        [DefaultValue(true)]
        public bool EmailConfirmed { get; set; }

        [Column("VERIFICATION_CODE")]
        public string VerificationCode { get; set; }

        [Column("USER_NAME")]
        [Required]
        [MaxLength(150)]
        public string UserName { get; set; }

        [Column("ROLE")]
        [Required]
        public byte Role { get; set; }

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

        public ICollection<UserPassword> UserPasswords { get; set; }
        public ICollection<UserLog> UserLogs { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
    }
}