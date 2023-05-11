using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public UserRoleController (IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //implements crud operatiom
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRole()
        {
            IEnumerable<UserRole> userRole = new List<UserRole>();
            ActionResult result = null;
            try
            {
                userRole = _idecommerceRepository.GetUserRole();
                result = Ok(userRole);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
        //per login

        //METODO PER IL LOGIN
        //GET api/OrderDetails/orderId
        [HttpGet("{UserByUserRole}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByUserId(int userId)
        {
            UserRole userRole = null;
            ActionResult result = null;

            try
            {
                userRole = _idecommerceRepository.GetUserRoleByUserId(userId);
                if (userRole == null)
                {
                    result = NotFound($"User Role with UserID {userId} not found.");
                }
                else
                {
                    result = Ok(userRole);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting User Role {ex.Message}");
            }

            return result;
        }

        // POST api/Userrole
        [HttpPost]
        public async Task<ActionResult<UserRole>> AddUserRole(UserRole userRole)
        {
            ActionResult result = null;
            try
            {
                if (userRole == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.AddUserRole(userRole))
                    {
                        result = Ok();
                    }
                    else
                    {
                        result = StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error creating new UserRole record {ex.Message}");
            }

            return result;
        }
    }
}
