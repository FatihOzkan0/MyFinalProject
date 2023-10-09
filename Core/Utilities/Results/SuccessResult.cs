using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)  //Hem true dönüp hem message gönderebiliyoruz.
        { 
        
        }

        public SuccessResult() : base(true)       //Sadece Gerçekleştiğini gönderiyoruz.
        {

        }
    }
}
