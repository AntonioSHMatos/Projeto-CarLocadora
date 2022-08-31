
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarLocadora.Database
{
    public class GeradorToken
    {
        private readonly string _secreto;
        public GeradorToken()
        {

            _secreto = Environment.GetEnvironmentVariable("JWT_SECRETO");
        }

        public LoginRespostaModel GerarToken(LoginRespostaModel loginRespostaModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Convert.FromBase64String(_secreto);

            var claimsIdenty = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, loginRespostaModel.Usuario)
            });

            SigningCredentials signingCredential = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdenty,
                Issuer = "EmitenteDoJWT",
                Audience = "DestinatarioDoJWT",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = signingCredential,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginRespostaModel.Autenticado = true;
            loginRespostaModel.DataExpiracao = tokenDescriptor.Expires;
            loginRespostaModel.Token = tokenHandler.WriteToken(token);

            return loginRespostaModel;
        }
    }
}
