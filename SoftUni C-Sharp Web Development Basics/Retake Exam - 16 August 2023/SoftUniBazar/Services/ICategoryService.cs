using SoftUniBazar.Models;

namespace SoftUniBazar.Services
{
	public interface ICategoryService
	{
		public Task<List<CategoryViewModel>> GetAllCategoriesAsync();
	}
}
