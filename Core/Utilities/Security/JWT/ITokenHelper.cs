using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper           //Kullanıcı ve o kullanıcının Calim lerini yani erişeceği yerleri veriyoruz.
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        //Kullanıcı sisteme başarılı giriş yapınca o kullanıcıyı bulucak veritabanına gidicek claimlerini bulucak ve token oluşturup vericek.
    }
}
