using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //Burada yaptığımız DTO (Data Transfer Object) işleminin mantığı ben ürünümün kategorisini ıd si ile değil ismi ile göstermek istiyorum o yüzden bir join işlemi yapıyorum.
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
