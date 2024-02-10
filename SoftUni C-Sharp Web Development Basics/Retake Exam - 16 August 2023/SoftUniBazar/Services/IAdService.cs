using SoftUniBazar.Models;

namespace SoftUniBazar.Services
{
	public interface IAdService
	{
		Task<List<AdAllViewModel>> GetAllAsync();

		Task AddAdAsync();

		Task<AdEditModel> EditAdAsync();
	}
}
