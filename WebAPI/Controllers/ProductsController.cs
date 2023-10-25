using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //IoC Container(Inversion of Control): IoC nin içine referanslar koyarız new EfProduct gibi sonra ihtiyacı olanlar onu alıp kullanır.Bunu yapmamızın sebebi bağımlılığı kaldırmak.
        //Bunu Business da DependcyResolvers içinde autofac de yaptık. 


        IProductService _productService;    

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet ("getall")] //Alyans verme işlemidir url de getall ile çağırırız
        public IActionResult GetAll()
        {
            
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);     //İStek okey olduğunda döner.
            }
            return BadRequest(result);   //İsteğin hatalı (400) olduğunda döner
            
        }

        [HttpGet ("getbyid")]
        public IActionResult GetById (int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost ("add")]     //Ekleme İşlemi.
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
