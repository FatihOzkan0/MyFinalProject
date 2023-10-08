﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        //Burada efproductDal'a geçişimiz yada başka bir sisteme geçerken hiç bir kod değiştirmememiz SOLID prensibinin "O" su Open Closed prencipledir.
        static void Main(string[] args)
        {
             Product();

            //Category();

        }

        private static void Category()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var c in categoryManager.GetAll())
            {
                Console.WriteLine(c.CategoryName);
            }
        }

        private static void Product()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());   //IProductService yaptığım işlem ile burada istediğim sistemle çalışabiliyorum.

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+" / "+product.CategoryName);    //Dto joın işlemi ile category tablosunda ki isime ulaşıyorum

            }
        }
    }
}
