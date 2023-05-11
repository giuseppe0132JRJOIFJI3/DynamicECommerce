using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    public class LoginController : Controller
    {
        private IDECommerceReposiory _idecommerceRepository;

        public LoginController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //GET:api/Users/Username
        [HttpGet("{username}")]
        public async Task<ActionResult<Users>> GetUserByUsername(string username)
        {
            Users user = null;
            ActionResult result = null;

            try
            {
                user = _idecommerceRepository.GetUserByUsername(username);
                if (user == null)
                {
                    result = NotFound($"User with id {username} not found.");
                }
                else
                {
                    result = Ok(user);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting user {ex.Message}");
            }

            return result;
        }

    }
}
