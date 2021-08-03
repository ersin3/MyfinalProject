using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Losely coupling
        //naming convetion
        //IoC Container -- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]    
        public IActionResult GetAll()
        {

            //Swagger
            //Dependency chain --
           var result = _productService.GettAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.add(product);
            if (result.Success)
            {
                return Ok(result);
                 
            }
            return BadRequest(result);
        }

    }
}
