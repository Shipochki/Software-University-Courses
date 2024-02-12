using Homies.Data;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
	public class TypeService : ITypeService
	{
		private readonly HomiesDbContext context;

        public TypeService(HomiesDbContext _context)
        {
            context = _context;
        }

        public async Task<List<TypeViewModel>> GetAllTypesAsync()
		{
			return await this.context
				.Types
				.Select(t => new TypeViewModel()
				{
					Id = t.Id,
					Name = t.Name,
				})
				.ToListAsync();
		}
	}
}
