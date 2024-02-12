using Homies.Models;

namespace Homies.Services
{
	public interface ITypeService
	{
		public Task<List<TypeViewModel>> GetAllTypesAsync();
	}
}
