using System;

namespace BookStore.Dto
{
    public class DtoUser
    {
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool EmailConfirmed { get; set; }
        public string VerificationCode { get; set; }
        public string UserName { get; set; }
        public byte Role { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid ImageIdFk { get; set; }
        public string ImageName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}