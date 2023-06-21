using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

namespace Api.Jwt
{
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(User user)
        {
            var configuration = new ConfigurationManager();
            configuration.AddJsonFile("appsettings.json");

            // appsetting for Token JWT

            string key = configuration["Jwt:Key"];
            Claim[] claims;

            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);

            if (user.Person != null)
            {
                claims = new []
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Name!),
                    new Claim(ClaimTypes.Role, user.Role!),
                    new Claim("Document", user.Person!.Document!),
                    new Claim("FirstName", user.Person!.FirstName!),
                    new Claim("FirstLastName", user.Person!.FirstLastName!),
                    new Claim("Email", user.Person!.InstitutionalMail!)
                };
            }
            else
            {
                claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Name!),
                    new Claim(ClaimTypes.Role, user.Role!),
                };
            }

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
