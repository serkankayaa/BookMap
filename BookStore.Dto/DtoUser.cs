using System;

namespace BookStore.Dto
{
    public class DtoUser
    {
        public Guid USER_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string SECOND_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public bool EMAIL_CONFIRMED { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public Guid USER_PASS_ID { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string PASSWORD_HASH { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public string LOCATION { get; set; }
        public Guid ACCOUNT_ID_FK { get; set; }
    }
}
