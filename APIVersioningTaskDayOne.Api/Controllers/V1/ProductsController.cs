using APIVersioningTaskDayOne.Api.Contracts.V1;
using APIVersioningTaskDayOne.Application.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioningTaskDayOne.Api.Controllers.V1
{
   
    [ApiController]
    [ApiVersion("1.0" , Deprecated = true)]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id , CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(id, cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            var response = new ProductResponse(product.Id, product.Name, product.Price);
            return Ok(response);
        }
    }
}
