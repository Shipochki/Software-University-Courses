using SeminarHub.Models;

namespace SeminarHub.Services
{
	public interface ICategoryService
	{
		Task<List<CategoryViewModel>> GetAllCategoriesAsync();
	}
}
