using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDetailsController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public OrdersDetailsController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            IEnumerable<OrderDetails> orderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                orderDetails = _idecommerceRepository.GetOrderDetails();
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        //get orderDetails By order ID
        [HttpGet("OrderID{ID}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsByOrderID(int orderID)
        {
            IEnumerable<OrderDetails> orderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                orderDetails = _idecommerceRepository.GetOrderDetailsByOrderID(orderID);
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting BankAccounts {ex.Message}");
            }

            return result;
        }

        //delete order detail
        //delete User
        [HttpDelete("OrderDetailID{ID}")]
        public async Task<ActionResult<Orders>> DeleteOrderDetail(int orderDetailID)
        {
            ActionResult result = null;
            try
            {
                if (orderDetailID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteOrderDetail(orderDetailID))
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

        //post request
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> CreateOrderDetail(OrderDetails orderDetail)
        {
            ActionResult result = null;
            try
            {
                if (orderDetail == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.CreateOrderDetail(orderDetail))
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
