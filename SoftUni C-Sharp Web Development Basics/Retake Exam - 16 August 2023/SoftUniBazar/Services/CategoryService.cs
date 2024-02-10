using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;

namespace SoftUniBazar.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly BazarDbContext context;

        public CategoryService(BazarDbContext _context)
        {
            context = _context;
        }

		public async Task<List<CategoryViewModel>> GetAllCategoriesAsync()
		{
			return await this.context
				.Categories
				.Select(c => new CategoryViewModel()
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToListAsync();
		}
	}
}
