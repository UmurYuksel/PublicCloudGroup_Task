using Microsoft.IdentityModel.Tokens;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Interfaces;
using publiccloudgroup_api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace publiccloudgroup_api.Services
{
    public class TokenService : IToken
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<(bool isSuccess, string errorMessage, object? token)> GenerateToken(UserDto user)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())}),
                    Expires = DateTime.UtcNow.AddDays(10),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return (true, string.Empty, new { token = tokenHandler.WriteToken(token), expires = token.ValidTo });

            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
