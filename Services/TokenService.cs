using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Interfaces;
using API.Intities;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class TokenService (IConfiguration config) : ItokenService
{
    public string createToken(AppUser user)
    {
    var tokenKey= config["TokenKey"] ?? throw new Exception("Token key is missing");
    if(tokenKey.Length < 64)    
    {
        throw new Exception("Token key must be at least 16 characters long");
    }
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokeDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokeDescriptor);
        return tokenHandler.WriteToken(token);
        
    }
}
