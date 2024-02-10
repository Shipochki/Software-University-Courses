using SoftUniBazar.Models;
using SoftUniBazar.Services.Models;

namespace SoftUniBazar.Services
{
    public interface IAdService
	{
		Task<List<AdAllViewModel>> GetAllAsync();

		Task AddAdAsync(AddAdModel model, string ownerId);

		//Task<AdEditModel> EditAdAsync();
	}
}
