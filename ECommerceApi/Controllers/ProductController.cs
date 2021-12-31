using ECommerceBusinnes.Abstract;
using ECommerceEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductServices _productServices;
        public ProductController(IProductServices productServices) => this._productServices = productServices;

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productServices.GetAllProduct();
            return Ok(products);
        }
    }
}
