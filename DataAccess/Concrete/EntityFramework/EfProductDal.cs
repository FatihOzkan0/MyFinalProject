using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{

    //Bu şekilde implemente ederek kod tekrarı yapmadan veri tabanı crud işlemlerimizi çağırıyoruz.
    //IProductDal implemente etmeye ne gerek var diyebiliriz fakat IProductDal da sadece ürüne ait operasyonları eklicez ve Business da onu kullanarak erişiyoruz.
    public class EfProductDal : EfEntityRepositoryBase<Product, MasterContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()       
        {
            using (MasterContext context = new MasterContext())
            {
                var result = from p in context.Products         //Products ile Categories birleştir , productda ki ile category de ki categoryId ler eşit ise.
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto        //Bu verileri ProductsDetailDto dan seç.
                             { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };

                return result.ToList();
            }

            
        }
    }
}
