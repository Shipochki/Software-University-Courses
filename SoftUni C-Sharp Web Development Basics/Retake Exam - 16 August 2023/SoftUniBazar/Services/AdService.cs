using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models;
using SoftUniBazar.Services.Models;

namespace SoftUniBazar.Services
{
    public class AdService : IAdService
	{
		private readonly BazarDbContext context;

        public AdService(BazarDbContext _context)
        {
            context = _context;
        }

		public async Task AddAdAsync(AddAdModel model, string ownerId)
		{
			Ad newAd = new Ad()
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				OwnerId = ownerId,
				ImageUrl = model.ImageUrl,
				CreatedOn = DateTime.Now,
				CategoryId = model.CategoryId,
			};

			await this.context.AddAsync<Ad>(newAd);
			await this.context.SaveChangesAsync();
		}

		public async Task<bool> AddAdToCartAsync(int id, string userId)
		{
			Ad ad = await this.context.Ads.FindAsync(id);

			AdBuyer result = await this.context.AdsBuyers
				.Where(a => a.BuyerId == userId && a.AdId == id)
				.FirstOrDefaultAsync();

			if (result != null) return false;

			AdBuyer newBuyer = new AdBuyer()
			{
				BuyerId = userId,
				AdId = id,
				Ad = ad,
			};

			await this.context.AdsBuyers.AddAsync(newBuyer);
			await this.context.SaveChangesAsync();

			return true;
		}

		public async Task EditAdAsync(EditAdModel model, int id)
		{
			Ad ad = await this.context.Ads.FindAsync(id);

			if(ad == null)
			{
				return;
			}

			ad.Name = model.Name;
			ad.Description = model.Description;
			ad.Price = model.Price;
			ad.ImageUrl = model.ImageUrl;
			ad.CategoryId = model.CategoryId;

			await this.context.SaveChangesAsync();
		}

		public async Task<EditAdModel> GetAdAsync(int id)
		{
			EditAdModel? result = await this.context
				.Ads
				.Where(a => a.Id == id)
				.Select(a => new EditAdModel()
				{
					Name = a.Name,
					Description = a.Description,
					Price = a.Price,
					ImageUrl = a.ImageUrl,
					CategoryId = a.CategoryId,
				})
				.FirstOrDefaultAsync();

			return result;
		}

		public async Task<List<AdAllViewModel>> GetAllAsync()
		{
			List<AdAllViewModel> result = await this.context
				.Ads
				.Select(a => new AdAllViewModel()
				{
					Id = a.Id,
					Name = a.Name,
					Description = a.Description,
					Price = a.Price,
					Owner = a.Owner.Email,
					ImageUrl = a.ImageUrl,
					CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
					Category = a.Category.Name
				})
				.ToListAsync();

			return result;
		}

		public async Task<List<AdAllCartViewModel>> GetAllCartAdsAsync(string userId)
		{
			List<AdAllCartViewModel> result = await this.context
				.AdsBuyers
				.Include(a => a.Ad)
				.Where(a => a.BuyerId == userId)
				.Select(a => new AdAllCartViewModel()
				{
					Id = a.Ad.Id,
					Name = a.Ad.Name,
					Description = a.Ad.Description,
					Price = a.Ad.Price,
					Owner = a.Ad.Owner.Email,
					ImageUrl = a.Ad.ImageUrl,
					CreatedOn = a.Ad.CreatedOn.ToString("yyyy-MM-dd H:mm"),
					Category = a.Ad.Category.Name
				})
				.ToListAsync();

			return result;
		}

		public async Task RemoveAdFromCartAsync(int id, string userId)
		{
			AdBuyer adBuyer = await this.context
				.AdsBuyers
				.Where(a => a.AdId == id && a.BuyerId == userId)
				.FirstOrDefaultAsync();

			if(adBuyer == null)
			{
				return;
			}

			this.context.AdsBuyers.Remove(adBuyer);

			await this.context.SaveChangesAsync();
		}
	}
}
