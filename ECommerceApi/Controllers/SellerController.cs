using ECommerceBusinnes.Abstract;
using ECommerceDataAccess;
using ECommerceEntities.Models;
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
    public class SellerController : ControllerBase
    {
        private readonly ISellerServices _sellerServices;
        private readonly EComerceDBAccess _context;
        public SellerController(ISellerServices sellerServices)
        { 
            this._sellerServices = sellerServices; 
        } 

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Seller>>> GetAll()
        {
            var sellers = await _sellerServices.GetAllSeller();
            return Ok(sellers);
        }
        [HttpPost("[action]")]
        public async Task<Seller> Create(Seller seller)
        {
            await _sellerServices.CreateSeller(seller);
            return seller;
        }
    }
}
