using APIVersioningTaskDayOne.Application.DTOs;

namespace APIVersioningTaskDayOne.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}