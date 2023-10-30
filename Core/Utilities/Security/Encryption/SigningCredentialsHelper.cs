using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper           //Asp.net e burada diyoruz ki token işleminde sen anahtar olarak bu key i kullan ,algoritma olarak da hmac kullan.
    {

        public static SigningCredentials CreateSigningCredentials(SecurityKey securitykey)
        {
            return new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha512Signature);
        }
            

    }
}
