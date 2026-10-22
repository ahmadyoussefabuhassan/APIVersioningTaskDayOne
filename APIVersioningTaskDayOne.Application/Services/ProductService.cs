using APIVersioningTaskDayOne.Application.DTOs;
using APIVersioningTaskDayOne.Application.Interfaces;
using APIVersioningTaskDayOne.Domain.Repositores;

namespace APIVersioningTaskDayOne.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product is null)
            {
                return null;
            }

            return new ProductDto(
                product.Id,
                product.Name,
                product.Price,
                product.Category?.Name ?? string.Empty
            );
        }
    }
}
