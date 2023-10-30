
using Microsoft.IdentityModel.Tokens;     //Microsoft.Identity.Token paketini ekliyoruz.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)      //Burada appsettingsde ki securityKey imizi tokenımız anlasın diye byte çeviriyoruz.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
