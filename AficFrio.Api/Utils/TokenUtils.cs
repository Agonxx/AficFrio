using AficFrio.Shared.Dtos;
using AficFrio.Shared.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AficFrio.Api.Utils
{
    public class TokenUtils
    {
        private readonly string _secretKey;

        public TokenUtils(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"];
        }

        public string GerarToken(int id, int empresaid, string username, string email, ERole role, DateTime criadoEm)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                            new Claim(nameof(InfoToken.Id), id.ToString()),
                            new Claim(nameof(InfoToken.EmpresaId), empresaid.ToString()),
                            new Claim(nameof(InfoToken.Username), username),
                            new Claim(nameof(InfoToken.Email), email),
                            new Claim(nameof(InfoToken.CriadoEm), criadoEm.ToString("yyyy-MM-dd HH:mm:ss")),
                            new Claim(nameof(InfoToken.Role), role.ToString()),
                            new Claim(nameof(ClaimTypes.Role), role.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
