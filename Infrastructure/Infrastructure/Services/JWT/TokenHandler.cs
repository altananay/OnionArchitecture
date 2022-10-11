using Application.Helpers;
using Application.Security;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TokenOptions = Application.Security.TokenOptions;
using Application.Extensions;

namespace Infrastructure.Services.JWT
{
    public class TokenHandler : ITokenHelper
    {
        //IConfiguration interface'i, appsetting.json dosyasındaki konfigürasyonları okumaya yarar.
        public IConfiguration Configuration { get; }
        //TokenOptions sınıfının içerisinde property olarak belirtilen token ayarları
        private TokenOptions _tokenOptions;
        //Token'ın süresi ne zaman bitecek
        private DateTime _accessTokenExpiration;
        public TokenHandler(IConfiguration configuration)
        {
            //dışardan gelen configuration'ı sınıf içerisindeki property olan configuration' ata.
            Configuration = configuration;
            /*appsettings.json dosyasındaki JWT ayarlarının olduğu section olan TokenOptinos section'ını al
            ve TokenOptions sınıfındaki propertyler ile maple*/
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        //User bilgisini ve operasyonlar için yetkileri ver.
        public AccessToken CreateToken(User user/*, OperationClaim operationClaims*/)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials/*, operationClaims*/);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials/*, OperationClaim operationClaims*/)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user/*, OperationClaim operationClaims*/)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user._id);
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(user.Claims);

            return claims;
        }
    }
}
