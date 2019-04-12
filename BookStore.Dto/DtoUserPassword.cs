using System;

namespace BookStore.Dto
{
    public class DtoUserPassword
    {
        public Guid USER_PASS_ID { get; set; }
        public Guid USER_ID { get; set; }
        public string PASSWORD_HASH { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }
    }
}
