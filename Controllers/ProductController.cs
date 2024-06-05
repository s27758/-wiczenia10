using Ćwiczenia10.DTO;
using Ćwiczenia10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ćwiczenia10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                _logger.LogError("ProductDto is null");
                return BadRequest("Invalid product data.");
            }

            try
            {
                var product = await _productService.AddProductAsync(productDto);
                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with id {id} not found");
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product by id");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
