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
					CreatedOn = a.CreatedOn.ToString(),
					Category = a.Category.Name
				})
				.ToListAsync();

			return result;
		}
	}
}
