using APIVersioningTaskDayOne.Domain.Entities;
using APIVersioningTaskDayOne.Domain.Repositores;
using Microsoft.EntityFrameworkCore;

namespace APIVersioningTaskDayOne.Infrastructure.Repositores
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _dbContext.Products
            .Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
