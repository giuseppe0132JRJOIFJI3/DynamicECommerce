using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private IDECommerceReposiory _idecommerceRepository;

        public ProductCategoriesController(IDECommerceReposiory idecommerceRepository)
        {
            _idecommerceRepository = idecommerceRepository;
        }

        //get request
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetGetProductCategories()
        {
            IEnumerable<ProductCategories> productCategories = new List<ProductCategories>();
            ActionResult result = null;
            try
            {
                productCategories = _idecommerceRepository.GetProductCategories();

                foreach (var productCategory in productCategories)
                {
                    if (!string.IsNullOrEmpty(productCategory.Field1))
                    {
                        //convert byte to string base64
                        byte[] imageBytes = Convert.FromBase64String(productCategory.Field1);
                        string imageSrc = Convert.ToBase64String(imageBytes);
                        productCategory.Field1 = imageSrc;
                    }
                }
                //productCategories = _idecommerceRepository.GetProductCategories();    
                result = Ok(productCategories);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        //create Product category
        //post request
        [HttpPost]
        public async Task<ActionResult<ProductCategories>> CreateProductCategory([FromForm] ProductCategories productCategories, IFormCollection formData)
        {
            ActionResult result = null;
            try
            {
                if (productCategories == null)
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
                            productCategories.Field1 = base64String;
                        }
                    }
                    if (_idecommerceRepository.CreateProductCategory(productCategories))
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

        //delete Product category
        [HttpDelete("ProductCategoriesID{ID}")]
        public async Task<ActionResult<ProductCategories>> DeleteProductCategory(int productCategoriesID)
        {
            ActionResult result = null;
            try
            {
                if (productCategoriesID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_idecommerceRepository.DeleteProductCategory(productCategoriesID))
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
        //get product by ID
        [HttpGet("ProductCategoryByID{ID}")]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetProductCategoriesByID(int productCategoriesID)
        {
            ProductCategories productCategory = new ProductCategories();
            ActionResult result = null;
            try
            {
                productCategory = _idecommerceRepository.GetProductCategoriesById(productCategoriesID);
                result = Ok(productCategory);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
    }
}
