using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

using Quki.Entity.DtoModels.ApiModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Quki.Entity.Models;
using Quki.Entity.DtoModels;

namespace Quki.Bll
{
    public class TokenManager
    {
        IConfiguration configuration;

        public TokenManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateAccessToken(AppUser user)
        {
            //claim
            var claims = new[]
            {

                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                //new Claim("rol", user.issubscriber.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //rol claimlerini

            //security key//appsetting
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //creadential oluşturma//kimlik//şifreleme türü
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token settings
            var token = new JwtSecurityToken
             (
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires : DateTime.Now.AddDays(7),
                notBefore : DateTime.Now,
                signingCredentials : cred,
                claims : claimsIdentity.Claims
             );

            //token oluşturma sınıfı ile örnek alma

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }

        public string CreateAccessTokenClient(ClientModel client)
        {
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client.Id),
                new Claim(JwtRegisteredClaimNames.Jti, client.Secret),
                new Claim(JwtRegisteredClaimNames.NameId, client.DeviceId),
                new Claim(JwtRegisteredClaimNames.UniqueName, client.DeviceType),
                new Claim(JwtRegisteredClaimNames.Email, client.Email),
                new Claim(JwtRegisteredClaimNames.Sid, client.Password),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //rol claimlerini

            //security key//appsetting
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //creadential oluşturma//kimlik//şifreleme türü
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token settings
            var token = new JwtSecurityToken
             (
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now,
                signingCredentials: cred,
                claims: claimsIdentity.Claims
             );

            //token oluşturma sınıfı ile örnek alma

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
        public string CreateRefreshTokenClient(ClientModel client)
        {
            
            //claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client.Id),
                new Claim(JwtRegisteredClaimNames.Jti, client.Secret),
                new Claim(JwtRegisteredClaimNames.NameId, client.DeviceId),
                new Claim(JwtRegisteredClaimNames.UniqueName, client.DeviceType),
                new Claim(JwtRegisteredClaimNames.Email, client.Email),
                new Claim(JwtRegisteredClaimNames.Sid, client.Password),
                new Claim(JwtRegisteredClaimNames.Azp, client.ProviderKey),
                new Claim(JwtRegisteredClaimNames.Acr, client.ProviderName),

            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token");

            //rol claimlerini

            //security key//appsetting
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));

            //creadential oluşturma//kimlik//şifreleme türü
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //token settings
            var token = new JwtSecurityToken
             (
                issuer: configuration["Tokens:Issuer"],
                audience: configuration["Tokens:Issuer"],
                signingCredentials: cred,
                claims: claimsIdentity.Claims
             );

            //token oluşturma sınıfı ile örnek alma

            var tokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(token) };

            return tokenHandler.token;
        }
    }
}
