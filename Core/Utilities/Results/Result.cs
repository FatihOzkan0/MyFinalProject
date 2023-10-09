using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

  /* this(success): Eğer 2 parametre girilirse Result newlendiğinde aşağıdaki tek parametreleli constuda çalıştır.Bunu yapmamızın nedeni istersek message
   girmeyiz sadece success verebiliriz.*/
        public Result(bool success, string message):this(success)      
        {
           Message = message;       
          // Success = success;  Kod tekrarına düşmemek için succesi aşağıdan çalıştırıyoruz.
           
        }

        public Result(bool success)
        {
            Success = success;
        }



        public bool Success { get; }

        public string Message { get; }
    }
}
