using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.TokenModels
{
    public class UserLogin //entity değil view modelimiz,gelen dataları burada toparlayıp tek sefrede db ye atacagız,email kontrolu sms kontrolu ilerde ekleyeceğiz
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
