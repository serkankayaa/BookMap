using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class User
    {
        [Key]
        public Guid USER_ID { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "First name is invalid")]
        public string FIRST_NAME { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Second name is invalid")]
        public string SECOND_NAME { get; set; }

        [Required]
        [MaxLength(300)]
        public string EMAIL_ADDRESS { get; set; }

        public bool EMAIL_CONFIRMED { get; set; }

        [Required]
        [ForeignKey("User_Password")]
        public Guid USER_PASS_ID_FK { get; set; }

        public DateTime? BIRTH_DATE { get; set; }

        public string LOCATION { get; set; }

        public Guid ACCOUNT_ID_FK { get; set; }

        [Required]
        public string CREATED_BY { get; set; }

        [Required]
        public DateTime CREATED_DATE { get; set; }

        public string MODIFIED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }
        public User_Password User_Password {get; set;}
    }
}
