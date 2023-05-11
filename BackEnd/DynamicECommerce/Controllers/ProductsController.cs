using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public ProductsController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //get request
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProducts();

                foreach (var product in products)
                {
                    if (!string.IsNullOrEmpty(product.Image))
                    {
                        //convert byte to string base64
                        byte[] imageBytes = Convert.FromBase64String(product.Image);
                        string imageSrc = Convert.ToBase64String(imageBytes);
                        product.Image = imageSrc;
                    }
                    if (product.UnitPrice.ToString().Length == 4)
                    {
                        product.UnitPrice = Convert.ToDecimal(product.UnitPrice);
                    }
                }

                result = Ok(products);
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting Products {ex.Message} inner: {ex.InnerException}");
            }

            return result;
        }


        //get product by ID
        [HttpGet("ProductID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductByID(int productID)
        {
            Products products = new Products();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProductByID(productID);
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }

        //get orderDetails By User ID
        [HttpGet("ProductCategoriesID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsByProductCategoriesID(int productCategoriesID)
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _idecommerceRepository.GetProductsByProductCategoriesID(productCategoriesID);
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting BankAccounts {ex.Message}");
            }

            return result;
        }

        //post request

        // POST api/products

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<Products>> AddProduct([FromForm] Products product, IFormCollection formData)
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
                    // Recupera i dati dell'immagine dal FormData
                    var image = formData.Files[0];

                    if (image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            var base64String = Convert.ToBase64String(fileBytes);
                            product.Image = base64String;
                        }
                    }
                    if (_idecommerceRepository.CreateProduct(product))
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
                     $"Error creating new Product record. {ex.Message}. Inner Exception: {ex.InnerException?.Message}");

            }

            return result;
        }

        //delete User
        [HttpDelete("ProductID{ID}")]
        public async Task<ActionResult<Products>> DeleteProduct(int productID)
        {
            ActionResult result = null;
            try
            {
                if (productID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteProduct(productID))
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

