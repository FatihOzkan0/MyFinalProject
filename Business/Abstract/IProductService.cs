using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult <List<Product>> GetAll();       //"List<Product> GetAll()"yerine bu methodu yazmamızın sebebi GetAll da doğrulama kontrolleri yapmak. 
        IDataResult <List<Product>> GetAllCategoryId(int id);
        IDataResult <List<Product>> GetByUnitPrice (decimal min , decimal max);
        IDataResult <List<ProductDetailDto>> GetProductDetails();
        IDataResult <Product> GetById(int productid);     //Tek bir product döndürüyor.
        IResult Add(Product product);        //IResult dememizin sebebi void yerine ,ekleme operasyonumuzun gerçekleşip gerçekleşmediğini anlayabilmek.
        IResult Update(Product product);


    }
}
