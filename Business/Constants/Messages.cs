using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages     //Basit bir message olduğu için static verdim newlemeden kullanıcam.
    {

        public static string ProducAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string ProductsListed = "Sistem Bakımda";
        public static string MaintenanceTime = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir Kategoride en fazla 10 ürün olabilir";
        public static string ProductNameRepeatError="Bu isimde başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori Limiti aşıldığı için ürün eklenemiyor";
    }
}
