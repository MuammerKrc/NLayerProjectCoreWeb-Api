using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NLayerProject.Core;
using NLayerProject.Core.Dtos;
using NLayerProject.Core.Models;
using NLayerProject.Core.Serivces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Service.CustomTokenServices
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<UserApp> _userManager;

        public TokenService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        private IEnumerable<Claim> GetClaimForClient(Client client)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,client.ClientId),
            };
            claims.AddRange(client.Audiences.Select(i => new Claim(JwtRegisteredClaimNames.Aud, i)));
            return claims;
        }
        private IEnumerable<Claim> GetClaimForUser(UserApp userApp)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,userApp.Id),
                new Claim(JwtRegisteredClaimNames.Email,userApp.Email),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            claims.AddRange()
        }
        public ClientTokenDto CreateTokenByClient(Client client)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("alfnavoaawlvasvava"));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken securityToken = new JwtSecurityToken
                (
                issuer: "https://localhost:5001",
                expires: DateTime.Now.AddMinutes(2),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: GetClaimForClient(client)
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(securityToken);
            return new ClientTokenDto()
            {
                AccessToken = token,
                AccessTokenExpiration = DateTime.Now.AddMinutes(2)
            };
        }
        public TokenDto CreateTokenByUser(UserApp userApp)
        {
            JwtSecurityToken token = new JwtSecurityToken
                (
                issuer: "https://localhost:5001",
                expires: DateTime.Now.AddMinutes(2),
                notBefore: DateTime.Now,

                );
        }
    }

}






