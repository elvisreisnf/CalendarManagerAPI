using CalendarManager.Application.Utils;
using CalendarManager.Entities.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenService
{
    public static string GenerateToken(User user)
    {

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescripotor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                //Num sistema em produção poderiam ser adicionadas outras claims como perfis...
                new Claim(ClaimTypes.Name, user.Username.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Audience = "CalendarManager",
            Issuer = "EuMesmo",
        };

        var token = tokenHandler.CreateToken(tokenDescripotor);
        return tokenHandler.WriteToken(token);
    }
}
