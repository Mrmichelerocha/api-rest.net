using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserApi.Dtos;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto login)
    {
        // Simulação de login fixo
        if (login.Email != "admin@pokevibes.com" || login.Senha != "123456")
            return Unauthorized(new { message = "Credenciais inválidas" });

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pika-ultra-mega-super-secret-key-256bits!!")); // chave secreta
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "pokeapi",
            audience: "pokeapi",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}
