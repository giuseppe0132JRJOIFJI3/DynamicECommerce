using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public OrdersController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //implements crud operatiom
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            IEnumerable<Orders> orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                orders = _idecommerceRepository.GetOrders();
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        //get orders By User ID
        [HttpGet("UserID{ID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersByUserID(int userID)
        {
            IEnumerable<Orders> orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                orders = _idecommerceRepository.GetOrdersByUserID(userID);
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting BankAccounts {ex.Message}");
            }

            return result;
        }

        //get Order by ID
        [HttpGet("OrderID{ID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrderByID(int orderID)
        {
            Orders order = new Orders();
            ActionResult result = null;
            try
            {
                order = _idecommerceRepository.GetOrderById(orderID);
                result = Ok(order);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        //create order
        //post request
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(Orders order)
        {
            ActionResult<int> result = null;
            try
            {
                if (order == null)
                {
                    result = BadRequest();
                }
                else
                {
                    //ci carichiamo l'orderID per poi usarlo nell'orderdetails
                    int orderID = _idecommerceRepository.CreateOrder(order);
                    if (orderID > 0)
                    {
                        result = Ok(orderID);
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

        //delete User
        [HttpDelete("Order{ID}")]
        public async Task<ActionResult<Orders>> DeleteOrder(int orderID)
        {
            ActionResult result = null;
            try
            {
                if (orderID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteOrder(orderID))
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
