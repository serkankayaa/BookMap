using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    [Table("USER_PROFILE")]
    public class UserProfile
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("USER_ID_FK")]        
        [Required]
        [ForeignKey("User")]
        public Guid UserIdFk { get; set; }

        [Column("NAME")]                
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("SURNAME")]                        
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Column("ADDRESS")]                        
        public string Address { get; set; }

        [Column("BIRTHDATE")]                        
        public DateTime BirthDate { get; set; }

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