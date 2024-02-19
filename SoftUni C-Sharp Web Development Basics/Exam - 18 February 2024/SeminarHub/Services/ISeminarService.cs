using SeminarHub.Models;
using SeminarHub.Services.Models;

namespace SeminarHub.Services
{
	public interface ISeminarService
	{
		Task AddSeminarAsync(AddSeminarModel model, string userId);
		Task EditSeminarAsync(int id, EditSeminarModel model, string userId);
		Task<List<AllSeminarViewModel>> GetAllJoindedSeminarsAsync(string userId);
		Task<List<AllSeminarViewModel>> GetAllSeminarsAsync();
		Task<EditSeminarModel> GetSeminarAsync(int id, string userId);
		Task<bool> JoinSeminarAsync(int id, string userId);
		Task LeaveSeminarAsync(int id, string userId);

		Task<DetailsSeminarViewModel> GetDetailsSeminarAsync(int id);
		Task<DeleteSeminarViewModel> GetDeleteSeminarAsync(int id, string userId);
		Task DeleteSeminarAsync(int id, string userId);
	}
}
