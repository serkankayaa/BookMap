using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entity.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        
        [Required]
        public string EMAIL_ADDRESS { get; set; }

        [DefaultValue(true)]
        public bool EMAIL_CONFIRMED { get; set; }

        public string VERIFICATION_CODE { get; set; }

        [Required]
        public string USER_NAME { get; set; }

        [Required]
        public byte ROLE { get; set; }

        [Required]
        public string CREATED_BY { get; set; }

        [Required]
        public DateTime CREATED_DATE { get; set; }

        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_DATE { get; set; }

        public ICollection<User_Password> User_Passwords { get; set; }
        public ICollection<User_Log> User_Logs { get; set; }
        public ICollection<User_Book> User_Books { get; set; }
    }
}