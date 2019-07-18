using System;

namespace BookStore.Dto
{
    public class DtoUserProfile
    {
        public Guid UserProfileId { get; set; }
        public Guid UserIdFk { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public Guid ImageIdFk { get; set; }
        public string ImageName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}