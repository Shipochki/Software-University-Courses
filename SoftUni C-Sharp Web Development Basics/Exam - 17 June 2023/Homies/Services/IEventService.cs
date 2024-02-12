using Homies.Models;
using Homies.Services.Models;

namespace Homies.Services
{
	public interface IEventService
	{
		public Task<List<EventAllViewModel>> GetAllEventsAsync();

		public Task AddEventAsync(EventAddModel model, string userId);

		public Task<bool> IsOwnerAsync(int eventId, string userId);
		Task EditEventAsync(int id, EventEditModel model);
		Task<EventEditModel> GetEventAsync(int id);
        Task<EventDetailsViewModel> GetEventDetailsAsync(int id);
        Task<List<EventJoinedViewModel>> GetAllJoinedEventsAsync(string userId);

		Task Join(int id, string userId);

		Task Leave(int id, string userId);
    }
}
