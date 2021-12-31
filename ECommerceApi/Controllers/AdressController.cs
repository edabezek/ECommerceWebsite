using ECommerceBusinnes.Abstract;
using ECommerceBusinnes.Concrete;
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
    public class AdressController : ControllerBase
    {
        private IAdressServices _adressServices;
        public AdressController(IAdressServices adressServices)
        {
            _adressServices = adressServices;
        } 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>>  Get()
        {
            var adress = await _adressServices.GetAllAdress();
            return Ok(adress);
        }
        //[HttpPost]
        //public IActionResult Post([FromBody] Adress adress)
        //{
        //    var createAdress = _adressServices.CreateAdress(adress);
        //    return Ok(createAdress);
        //}
        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    if (_adressServices.GetAdressById(id)!=null)
        //    {
        //        _adressServices.DeleteAdress(id);
        //        return Ok("Deleted adress");
        //    }
        //    return NotFound();
        //}
        //[HttpPut]
        //public IActionResult Put([FromBody] Adress adress)
        //{
        //    if (_adressServices.GetAdressById(adress.AdressId) != null)
        //    {
        //        return Ok(_adressServices.UpdateAdress(adress));
        //    }
        //    return NotFound();
        //}
    }
}
