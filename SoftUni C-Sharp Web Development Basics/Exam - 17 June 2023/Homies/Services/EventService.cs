using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Homies.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
	public class EventService : IEventService
	{
		private readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            context = _context;
        }

        public async Task AddEventAsync(EventAddModel model, string userId)
		{
			Event newEvent = new Event()
			{
				Name = model.Name,
				Description = model.Description,
				Start = DateTime.Parse(model.Start),
				End = DateTime.Parse(model.End),
				TypeId = model.TypeId,
				CreatedOn = DateTime.Now,
				OrganiserId = userId,
			};

			await context.Events.AddAsync(newEvent);
			await context.SaveChangesAsync();
		}

		public async Task EditEventAsync(int id, EventEditModel model)
		{
			Event event1 = await context.Events.FindAsync(id);

			if(event1 == null)
			{
				return;
			}

			event1.Name = model.Name;
			event1.Description = model.Description;
			event1.Start = DateTime.Parse(model.Start);
			event1.End = DateTime.Parse(model.End);
			event1.TypeId = model.TypeId;

			await this.context.SaveChangesAsync();
		}

		public async Task<List<EventAllViewModel>> GetAllEventsAsync()
		{
			return await this.context
				.Events
				.Select(e => new EventAllViewModel()
				{
					Id = e.Id,
					Name = e.Name,
					Start = e.Start.ToString("yyyy-MM-dd H:mm"),
					Type = e.Type.Name,
					Organiser = e.Organiser.UserName
				})
				.ToListAsync();
		}

		public async Task<EventEditModel> GetEventAsync(int id)
		{
			EventEditModel model = await this.context
				.Events
				.Where(e => e.Id == id)
				.Select(e => new EventEditModel()
				{
					Name = e.Name,
					Description = e.Description,
					Start = e.Start.ToString("yyyy-MM-dd H:mm"),
					End = e.End.ToString("yyyy-MM-dd H:mm"),
					TypeId = e.TypeId,
				})
				.FirstAsync();

			return model;
		}

		public async Task<bool> IsOwnerAsync(int eventId, string userId)
		{
			Event event1 = await this.context.Events.FindAsync(eventId);

			if(event1 == null || event1.OrganiserId != userId)
			{
				return false;
			}

			return true;
		}

		public Task RemoveEventAsync()
		{
			throw new NotImplementedException();
		}
	}
}
