using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    /*Business katmanında Manager class larımız iş kodları yazarken bir method sadece bir iş gerçekleştirir kuralımız vardır.Bizde bir methodumuzda işlem
    yapılırken hem o işlem gerçekleşti mi gibi operasyonları methodumuza eklemek için bu profosyonel yapıyı oluşturuyoruz.*/
    //Temel void methotlar için kullanıcağımız operasyonlar bunlar.
    public interface IResult
    {
        bool Success { get; }  //Başarılı mı işlem.True veya False ver.Sadece get kullanmamızın sebebi sadece bize getiricek.
        string Message { get; } //Bool dönüşüne göre message ver kullanıcıya.

    }
}
