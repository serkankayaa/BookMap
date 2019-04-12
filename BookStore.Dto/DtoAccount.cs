using BookStore.Dto.Definition;
using System;

namespace BookStore.Dto
{
    public class DtoAccount
    {
        public Guid ACCOUNT_ID { get; set; }
        public string NAME { get; set; }
        public byte TYPE { get; set; }

        public string TYPE_NAME
        {
            get
            {
                return Enum.GetName(typeof(UserTypes), this.TYPE);
            }
        }
    }
}
