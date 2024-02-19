using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Models;

namespace SeminarHub.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly SeminarHubDbContext context;

        public CategoryService(SeminarHubDbContext _context)
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
