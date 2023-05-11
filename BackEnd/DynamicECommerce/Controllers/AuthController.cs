using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        //key jwt
        string keyAppsetingJson = "J4xpEz6iVepAKzuEz1iKHgWHeInXsfOaHsh0FNS5nSOywOrkA4GPRnz5Tz6fmIASm1rULmet93YXkhj3xkIWuuIQCFE9GrTOGGM2onrFwQUwXc0xA7059fO2WHxcZ7RRku6Zr9R3X88TN6atVGIXRVydH9jdCQAZYLUHqUJyf2GWhOMxHxW5PINaWFLOfLDKcxKdlRSdHMprajVYZLOZmP7lRQhtBhawFfCwP2IH2MnQvPNR6SjN2sZGZEPmfm2zWOpQx0NkhvXSKXALegi6q4FKv4q1v9DnpqZEzEWTcH2VOteTr9DCwCdfWSaAOQVNdTkDF8nGLlWwXUkVhrLMlEpYd4shd16NleOp4PSTbc1qk55vk7wjgzg3pmxlh59rv5dlgewd9jem5nrt4wIzQOT8cUD8045fEJFMFUIkZj8eOCC8Asm9ERLlzCHtM8DghBTX2eQcZqQuWMAt5pu4qLKR7JgfaN3eZ4RzI91Qi270jsDOhS9R4KCs6MQ39GfpkNuq";
        
        private readonly IDECommerceReposiory _idecommerceRepository;


        public AuthController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users user)
        {
            var storedUser = _idecommerceRepository.GetUserByUsername(user.Username);

            if (storedUser == null || storedUser.Password != user.Password)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(keyAppsetingJson);

            if (storedUser != null)
            {
                var userRole = _idecommerceRepository.GetUserRoleByUserId(storedUser.UserID);
                if (userRole == null)
                {
                    // Gestire il caso in cui non esiste un UserRole per l'utente
                    return BadRequest("UserRole non trovato per l'utente");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, storedUser.UserID.ToString()),
                    new Claim(ClaimTypes.Name, storedUser.Username),
                    new Claim(ClaimTypes.Role, userRole.RoleID.ToString())
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Audience = "your_audience",
                    Issuer = "your_issuer",
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), roleId = userRole.RoleID, userID = storedUser.UserID });
            }
            else
            {
                // Gestire il caso in cui storedUser è null
                return BadRequest("Utente non trovato");
            }
        }
    }
}
