using APIVersioningTaskDayOne.Api.Contracts.V2;
using APIVersioningTaskDayOne.Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningTaskDayOne.Api.Controllers.V2
{

    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            var response = new ProductResponse(product.Id, product.Name, product.Price, product.CategoryName);
            return Ok(response);
        }
    }
}
