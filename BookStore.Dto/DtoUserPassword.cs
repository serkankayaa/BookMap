using System;

namespace BookStore.Dto
{
    public class DtoUserPassword
    {
        public Guid UserPasswordId { get; set ;}
        public Guid UserIdFk { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}