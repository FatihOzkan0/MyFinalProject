using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)    //True yu direk default gönderiyorum base ime.
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)   //Bunları tanımlayarak kullanıcıya imkanlar sunuyoruz hangi yapıyı kullanmak isterse.
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }

    }
}
