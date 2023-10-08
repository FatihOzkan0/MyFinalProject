using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    //Manager görürsek iş katmannın somut sınıfı olduğunu anlarız. Bir iş Sınıfı başka sınıfları new lemez bu bir kuraldır.
    public class ProductManager : IProductService
    {

        IProductDal _productDal;    //Bir iş sınıfı başka sınıfı newlemez kuralından dolayı bu şekilde tanımladık.Nedeni bağımlılığı kaldırıyoruz adoNet kullanıyorken Ef ye geçebilirim.
                                   //O yüzden soyut sınıfı çağırarak çalışıyorum yani Interface çağırdım.


        public ProductManager(IProductDal productDal)   //Constroctor  enjectıon işlemini yapıyoruz.ProductManager new lendiği an benden productDal isticek.Bende orada istediğim veri yönetme sistemini vericem.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
          //iş kodlarıı .....
          
            return _productDal.GetAll();

        }

        public List<Product> GetAllCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
