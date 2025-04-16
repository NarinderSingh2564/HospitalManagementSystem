using HospitalManagementSystem.Models.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Web.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalManagementSystem.API.Helpers
{
	public class JwtService
	{
		private readonly IConfiguration _config;
		public JwtService(IConfiguration config)
		{
			_config = config;
		}
		private string secureKey = "this is my custom secret key for authentication";
		public string GenerateToken(int id)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var claims = new[]
						{
							new Claim(JwtRegisteredClaimNames.Iat, 
							new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(),
							ClaimValueTypes.Integer64)
						};
			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(2),
				signingCredentials: creds
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
		public JwtSecurityToken VerifyToken(string jwt)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secureKey);

			tokenHandler.ValidateToken(jwt, new TokenValidationParameters
			{
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuerSigningKey = true,
				ValidateIssuer = false,
				ValidateAudience = false
			}, out SecurityToken validatedToken);

			return (JwtSecurityToken)validatedToken;
		}
	}
}
