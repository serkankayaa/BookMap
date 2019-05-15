using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Entity.Models
{
    public class User_Password
    {
        [Key]
        public Guid USER_PASS_ID { get; set; }

        [Required]
        public string PASSWORD_HASH { get; set; }

        [DefaultValue(true)]
        public bool IS_ACTIVE { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid USER_ID_FK { get; set; }

        [Required]
        public string CREATED_BY { get; set; }

        [Required]
        public DateTime CREATED_DATE { get; set; }

        public User User {get; set;}
    }
}
