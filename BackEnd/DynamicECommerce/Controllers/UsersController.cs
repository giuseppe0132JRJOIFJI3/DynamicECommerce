using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDECommerceReposiory _idecommerceRepository;

        public UsersController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }


        //implements crud operatiom
        //get request
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            IEnumerable<Users> users = new List<Users>();
            ActionResult result = null;
            try
            {
                users = _idecommerceRepository.GetUsers();

                foreach (var user in users)
                {
                    if (!string.IsNullOrEmpty(user.Field2))
                    {
                        //convert byte to string base64
                        byte[] imageBytes = Convert.FromBase64String(user.Field2);
                        string imageSrc = Convert.ToBase64String(imageBytes);
                        user.Field2 = imageSrc;
                    }
                }

                result = Ok(users);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
        //post request
        //automaticamente esegue anche la post allo user role per assegnare il ruolo allo user
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<Users>> CreateUsers([FromForm] Users user, IFormCollection formData)
        {
            ActionResult result = null;
            try
            {
                if (formData == null)
                {
                    result = BadRequest();
                }
                else
                {
                    Roles role = _idecommerceRepository.GetRoleById(2);//ci carichiamo l'id 2 di role che sarebbe customer
                    if (_idecommerceRepository.CreateUsers(user))
                    {
                        UserRole userRole = new UserRole { UserID = user.UserID, RoleID = role.RoleID };//crezione user role con id 2 e user id per greare customer
                                                                                                        // Recupera i dati dell'immagine dal FormData
                        var image = formData.Files[0];

                        if (image.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                image.CopyTo(ms);
                                var fileBytes = ms.ToArray();
                                var base64String = Convert.ToBase64String(fileBytes);
                                user.Field2 = base64String;
                            }
                        }
                        if (_idecommerceRepository.AddUserRole(userRole))
                        {
                            result = Ok();
                        }
                        else
                        {
                            result = StatusCode(StatusCodes.Status500InternalServerError);
                        }
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
                     $"Error creating new Product record. {ex.Message}. Inner Exception: {ex.InnerException?.Message}");

            }


            return result;
        }

        //get by userID
        [HttpGet("User{ID}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserById(int userID)
        {
            Users user = new Users();
            ActionResult result = null;
            try
            {
                user = _idecommerceRepository.GetUserById(userID);
                result = Ok(user);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        //delete User
        [HttpDelete("User{ID}")]
        public async Task<ActionResult<Users>> DeleteUsers(int userID)
        {
            ActionResult result = null;
            try
            {
                if (userID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteUsers(userID))
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
                    $"Error getting users {ex.Message}");
            }

            return result;
        }
    }
}
