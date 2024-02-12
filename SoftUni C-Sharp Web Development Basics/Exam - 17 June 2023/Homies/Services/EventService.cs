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

        public async Task<List<EventJoinedViewModel>> GetAllJoinedEventsAsync(string userId)
        {
            return await this.context
                .EventsParticipants
				.Where(e => e.HelperId == userId)
                .Select(e => new EventJoinedViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Event.Type.Name,
                    Organiser = e.Event.Organiser.UserName
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

        public async Task<EventDetailsViewModel> GetEventDetailsAsync(int id)
        {
            EventDetailsViewModel model = await this.context
				.Events
				.Where(e => e.Id == id)
				.Select(e => new EventDetailsViewModel()
				{
					Id = e.Id,
					Name = e.Name,
					Description = e.Description,
					Start = e.Start.ToString(),
					End = e.End.ToString(),
					CreatedOn = e.CreatedOn.ToString(),
					Organiser = e.Organiser.UserName,
					Type = e.Type.Name,
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

        public async Task Join(int id, string userId)
        {
			Event? currentEvent = await this.context.Events.FindAsync(id);

			if(currentEvent == null)
			{
				return;
			}

			EventParticipant? eventParticipant = await this.context
				.EventsParticipants
				.Where(e => e.EventId == id && e.HelperId == userId)
				.FirstOrDefaultAsync();
			
			if(eventParticipant != null)
			{
				return;
			}

			eventParticipant = new EventParticipant()
			{
				EventId = id,
				Event = currentEvent,
				HelperId = userId
			};

			await this.context.EventsParticipants.AddAsync(eventParticipant);
			await this.context.SaveChangesAsync();
        }

        public async Task Leave(int id, string userId)
        {
            Event? currentEvent = await this.context.Events.FindAsync(id);

            if (currentEvent == null)
            {
                return;
            }

            EventParticipant? eventParticipant = await this.context
                .EventsParticipants
                .Where(e => e.EventId == id && e.HelperId == userId)
                .FirstOrDefaultAsync();

            if (eventParticipant == null)
            {
                return;
            }

			context.EventsParticipants.Remove(eventParticipant);

			await this.context.SaveChangesAsync();
        }
    }
}
