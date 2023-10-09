using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Veri işlemi başarılımı kontrolü yapıcaz.
    //Son 2 ctor kullanılmaz çok altyapı olarak yazdım.

    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data , string message) :base(data,true,message)    //True yu direk default gönderiyorum base ime.
        {
            
        }

        public SuccessDataResult(T data) : base(data,true) 
        {
            
        }

        public SuccessDataResult(string message) :base(default,true,message)   //Bunları tanımlayarak kullanıcıya imkanlar sunuyoruz hangi yapıyı kullanmak isterse.
        {
            
        }

        public SuccessDataResult() : base (default,true) 
        {
            
        }

    }
}
