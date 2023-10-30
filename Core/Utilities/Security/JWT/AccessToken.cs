using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken               //Kullanıcıya erişim için verdiğimiz tokendır(jeton),Expiration da bu tokenın bitiş zamanı.
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
