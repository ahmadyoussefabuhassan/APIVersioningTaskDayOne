using APIVersioningTaskDayOne.Domain.Entities;
using APIVersioningTaskDayOne.Domain.Repositores;

namespace APIVersioningTaskDayOne.Infrastructure.Repositores
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
