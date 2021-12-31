using ECommerceApi.TokenModels;
using ECommerceDataAccess;
using ECommerceEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Helpers
{
    public class GenericHelperMethods
    {
        public GenericHelperMethods()
        {
                
        }
        public async Task<Token> CreateRefreshToken(User user, EComerceDBAccess _context, IConfiguration _configuration)
        {
            //user için token üretiliyor
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken();

            //refresh token kullanıcı tablosuna ekleniyor
            //RefreshToken token süresine göre kendini yenileyen tokendır.5dk Expration belirlemiştik,5dk geçince kullanıcı loginden düşer,bunu engellemek için refreshtoken veriyoruz ki güncellensin
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndTime = token.Expration.AddMinutes(5);//refresh tokenın ayakta kalma süresi

            await _context.SaveChangesAsync();
            return token;
        }
    }
}
