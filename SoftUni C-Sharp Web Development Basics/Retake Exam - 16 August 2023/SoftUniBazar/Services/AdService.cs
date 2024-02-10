using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;

namespace SoftUniBazar.Services
{
	public class AdService : IAdService
	{
		private readonly BazarDbContext context;

        public AdService(BazarDbContext _context)
        {
            context = _context;
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
					OwnerId = a.OwnerId,
					ImageUrl = a.ImageUrl,
					CreatedOn = a.CreatedOn.ToString(),
					Category = a.Category.Name
				})
				.ToListAsync();

			return result;
		}
	}
}
