using ECommerceEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ECommerceApi.TokenModels
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Token CreateAccessToken()
        {
            Token token = new Token();

            //securitykey simetriğini alıyoruz
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            //şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturulacak tokenın ayarlarını veriyoruz
            token.Expration = DateTime.Now.AddMinutes(5);//tokenın geçerlilik süresi,ayakta kalma süresi 

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:Configuration["Token:Issuer"],
                audience:Configuration["Token:Audience"],
                expires:token.Expration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );
            //tokrn oluuştrucu sınıfından bir örnek alıyoruz
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //token üretiyoruz
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            //refresh token üretiyoruz
            token.RefreshToken = CreateRefreshToken();
            return token;
        }
        public string CreateRefreshToken()
        {
            byte[] tokenArray = new byte[32];
            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(tokenArray);
                return Convert.ToBase64String(tokenArray);
            }

        }
    }
}
