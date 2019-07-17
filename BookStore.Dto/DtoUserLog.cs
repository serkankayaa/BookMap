using System;

namespace BookStore.Dto
{
    public class DtoUserLog
    {
        public Guid UserLogId { get; set; }
        public Guid UserIdFk { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public string Token { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}