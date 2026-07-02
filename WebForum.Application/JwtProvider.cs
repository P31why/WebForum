
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebForum.Core;
using WebForum.Core.Models;

namespace WebForum.Application
{
    public class JwtProvider(IOptions<JwtOptions> options): IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateUser(UserDto dto)
        {
            Claim[] claims = [new("userId", dto.Id.ToString())];

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), 
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials: creds,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpiresTime));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
