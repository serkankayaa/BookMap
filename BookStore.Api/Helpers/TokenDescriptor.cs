using System;
using System.Security.Claims;

namespace BookStore.Api
{
    public class TokenDescriptor    
    {
        public Claim[] Claims { get; set; }
        public string Secret { get; set; }
        public DateTime ExpiresValue { get; set; }
    }
}