using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)   //Params verdiğimizde bu methodu kullandığımız yerde içine istediğimiz kadar Iresult verebiliriz. logics:iş kuralı.
        {
            foreach(var logic in logics)
            {
                if(!logic.Success)   //logic(iş kuralları) ler başarılı değilse hata döndür aşağıda.
                {
                    return logic;    //hangi iş kuralı hatalıysa onu döndür business'a .
                }
            }
            return null;     //Başarılı ise bişey döndürmeye gerek yok.
        }
    }
}
