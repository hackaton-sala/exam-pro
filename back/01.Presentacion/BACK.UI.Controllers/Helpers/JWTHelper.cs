using BACK.CORE.Entities;
using BACK.CORE.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BACK.UI.Controllers.Helpers
{
    public class JWTHelper
    {
        public enum Claims
        {
            UserId,
            UserLogin
        }

        public static JwtSecurityToken BuildToken(IConfiguration config, Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"].PadRight(36, '0')));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"], claims,
              expires: DateTime.Now.AddMinutes(Convert.ToDouble(config["Jwt:ExpireMin"])),
              signingCredentials: creds);

            return token;
        }

        public static TokenValidationParameters GetValidationParameters(IConfiguration config)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"].PadRight(36, '0')))
            };
        }

        public static string GetToken(IConfiguration config, UserResource User)
        {
            var claims = new List<Claim>
            {
                new(Claims.UserId.ToString(), User.UserId.ToString()),
                new(Claims.UserLogin.ToString(), User.Email.ToString())
            };

            var token = BuildToken(config, [.. claims]);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static Claim GetClaim(IEnumerable<Claim> claims, Claims nombre)
        {
            Claim claim = claims.FirstOrDefault(c => c.Type == nombre.ToString());
            return claim;
        }

        public static int? GetUsuarioId(IEnumerable<Claim> claims)
        {
            string usuarioId = GetClaim(claims, Claims.UserId).Value;

            if (string.IsNullOrEmpty(usuarioId))
            {
                return null;
            }
            else
            {
                return int.Parse(usuarioId);
            }
        }

        public static string GetUsuarioLogin(IEnumerable<Claim> claims)
        {
            return GetClaim(claims, Claims.UserLogin).Value;
        }
    }
}
