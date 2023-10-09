using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);  //String kodları direk projede yazmak yanlıştır o yüzden başka classda yazıp çektik.
            }

            _productDal.Add(product);
            
            return new SuccessResult(Messages.ProducAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult <List<Product>>(_productDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productid)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p=>p.ProductId == productid));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
