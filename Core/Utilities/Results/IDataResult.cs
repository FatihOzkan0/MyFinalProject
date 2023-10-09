using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //void dışı İşlem yapılan methodlarımız için oluşturduğumuz kontrol sistemi.
    public interface IDataResult<T>:IResult
    {
        T Data { get; }    //IResult dan aldığımız methodlar dışında birde verimiz olucak burda. (Ürün vb. gibi )
    }
}
