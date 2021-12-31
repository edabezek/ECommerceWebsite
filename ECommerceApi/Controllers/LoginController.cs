using ECommerceApi.Helpers;
using ECommerceApi.TokenModels;
using ECommerceDataAccess;
using ECommerceEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EComerceDBAccess _context;
        private readonly IConfiguration _configuration;//Token'a erişim
        //Microsoft.Extension.Configuration seçiyoruz:genişletileblir metotlar 
        //Automapper.Configuration:Tablolarımız karşılığında otomatik modeller üretir
        private readonly GenericHelperMethods _genericHelperMethods;
        public LoginController(EComerceDBAccess context, IConfiguration configuration, GenericHelperMethods genericHelperMethods)
        {
            _context = context;
            _configuration = configuration;
            _genericHelperMethods = genericHelperMethods;
        }
        //önce kullanıcının kayıt işlemini yapacağız ,herhangi bir token ataması yapmayacağız
        //token atamasını authocation olayı gerçekleştiği zaman yapacaağız,yani loginden başarılı geçiyorsa token atayacağız.
        //www.bombabomba.com/api/login/create
        [HttpPost("[action]")]//login js de Post kullandık
        public async Task<bool> Create([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost("[action]")]//action kullanmamızın faydası metot bazlı yetkilendirme yapmak
        public async Task<Token> Login([FromBody] UserLogin userLogin)//burada kendi yazdığımız token'ı kullanıyoruz
        {
            //bu kişi bizim sistemimizde varsa kişiye token göndereceğiz
            User user = await _context.Users.FirstOrDefaultAsync(w => w.Email == userLogin.Email && w.Password == userLogin.Password);//metoda gelen mail ile sistemdeki mail ve aynı şekilde parola eşleşiyorsa bizim user'ımıza atanacak
            //FirstOrDefault ilk eşleşeni yakala getir,eşleşme olmazsa sonucu null döner.
            //SingleOrDefault eşleşmesi durumuna tek sonuc gelir, eşleşmiyorsa 0 döner.
            if (user != null)//eşlenip eşenmediğinin kontrolu
            {
                //kişi sistemimizde var,Token üretip bu token'ı kullnıcıya göndereceğiz
                return await _genericHelperMethods.CreateRefreshToken(user,_context,_configuration);
            }
            return null;//sistemimizde yok 
        }
        //token yenileme için
        [HttpPost("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            User user = await _context.Users.FirstOrDefaultAsync(w => w.RefreshToken == refreshToken);//kullanıcı bir token'a sahip mi değil mi 
            if (user!=null && user?.RefreshTokenEndTime>DateTime.Now)//ve token süresi dolmuş ise
            {
                //token süresi dolmuş,Token üretip bu token'ı kullnıcıya göndereceğiz
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;

        }
        
    }
}
