using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.TokenModels
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expration { get; set; }
        public string RefreshToken { get; set; }
    }
}
