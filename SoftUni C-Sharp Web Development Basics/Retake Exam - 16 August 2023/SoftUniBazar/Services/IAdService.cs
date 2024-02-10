using SoftUniBazar.Models;
using SoftUniBazar.Services.Models;

namespace SoftUniBazar.Services
{
    public interface IAdService
	{
		Task<List<AdAllViewModel>> GetAllAsync();

		Task AddAdAsync(AddAdModel model, string ownerId);
		Task EditAdAsync(EditAdModel model, int id);
		Task<EditAdModel> GetAdAsync(int id);
		Task<List<AdAllCartViewModel>> GetAllCartAdsAsync(string userId);
		Task RemoveAdFromCartAsync(int id, string userId);

		Task<bool> AddAdToCartAsync(int id, string userId);
	}
}
