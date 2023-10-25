using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    //Manager görürsek iş katmannın somut sınıfı olduğunu anlarız. Bir iş Sınıfı başka sınıfları new lemez bu bir kuraldır.
    public class ProductManager : IProductService
    {

        IProductDal _productDal;    //Bir iş sınıfı başka sınıfı newlemez kuralından dolayı bu şekilde tanımladık.Nedeni bağımlılığı kaldırıyoruz adoNet kullanıyorken Ef ye geçebilirim.
                                   //O yüzden soyut sınıfı çağırarak çalışıyorum yani Interface çağırdım.

        ICategoryService _categoryService;  //Aşağıda category ilgilendiren bir iş kuralımız olduğu için ICategoryService enjekte ediyoruz. 
                                            


        public ProductManager(IProductDal productDal,ICategoryService categoryService)   //Constroctor  enjectıon işlemini yapıyoruz.ProductManager new lendiği an benden productDal isticek.Bende orada istediğim veri yönetme sistemini vericem.
        {
            _productDal = productDal;
            _categoryService = categoryService;  //NOT : Bir manager içine başka bir managerın DAL ı enjekte edilmez o yüzden _categoryDal yerine service çağırdık.

        }

        [ValidationAspect(typeof(ProductValidator))]     //AOP ekleyerek validation işlemini Aspecte yaptırıyoruz bu sayede iş kodları dışında kod yazmamış oluyoruz.
        public IResult Add(Product product)
        {

            IResult result= BusinessRules.Run(ProductCountOfCategory(product), ProductNameRepeat(product) ,CheckCategoryLimit());  //Bu iş motoru iş  kurallarımızı çalıştırıp kontrol eder.
            
            if(result != null)  //result null değilse demek ki iş kurallarının biri uymuyor hata var.
            {
                return result;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count();

            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

                                    //İŞ KURALLARI

        private IResult ProductCountOfCategory(Product product)
        {
            //Ürün eklerken bir kategoride en fazla 10 ürün olabilir.

            int result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count();

            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult ProductNameRepeat(Product product)
        {
            //Aynı isimde ürün eklenemez.

            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();    //ANY: Buna uyan kayıt var mı demek.Ona göre true false gönderir.

            if(result==true)
            {
                return new ErrorResult(Messages.ProductNameRepeatError);
            }
            return new SuccessResult();
        }

        //Mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez.

         private IResult CheckCategoryLimit()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
