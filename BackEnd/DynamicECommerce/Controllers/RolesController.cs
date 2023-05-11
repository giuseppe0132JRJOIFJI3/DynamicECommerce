using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public RolesController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //implements crud operatiom
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            IEnumerable<Roles> roles = new List<Roles>();
            ActionResult result = null;
            try
            {
                roles = _idecommerceRepository.GetRoles();
                result = Ok(roles);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        //get role by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRole(int roleId)
        {
            Roles role = null;
            ActionResult result = null;

            try
            {
                role = _idecommerceRepository.GetRoleById(2);
                if (role == null)
                {
                    result = NotFound($"Role with id {roleId} not found.");
                }
                else
                {
                    result = Ok(role);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting Role {ex.Message}");
            }

            return result;
        }
    }
}
