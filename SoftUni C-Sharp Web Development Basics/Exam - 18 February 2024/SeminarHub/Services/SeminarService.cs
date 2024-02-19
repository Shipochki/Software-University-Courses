using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Entities;
using SeminarHub.Models;
using SeminarHub.Services.Models;
using System.Globalization;

namespace SeminarHub.Services
{
	public class SeminarService : ISeminarService
	{
		private readonly SeminarHubDbContext context;

		public SeminarService(SeminarHubDbContext _context)
		{
			context = _context;
		}

		public async Task AddSeminarAsync(AddSeminarModel model, string userId)
		{
			IdentityUser? user = await this.context.Users.FindAsync(userId);

			if (user == null)
			{
				return;
			}

			Category? category = await this.context.Categories.FindAsync(model.CategoryId);

			if (category == null)
			{
				return;
			}

			DateTime dateAndTime = DateTime.Now;
			if(!DateTime.TryParseExact(model.DateAndTime,
				"dd/MM/yyyy HH:mm",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out dateAndTime))
			{
				throw new ArgumentException("Invalid date!");
			}

			Seminar seminar = new Seminar()
			{
				Topic = model.Topic,
				Lecturer = model.Lecturer,
				Details = model.Details,
				OrganizerId = userId,
				Organizer = user,
				DateAndTime = dateAndTime,
				Duration = model.Duration,
				CategoryId = category.Id,
				Category = category,
			};

			await this.context.Seminars.AddAsync(seminar);
			await this.context.SaveChangesAsync();
		}

		public async Task DeleteSeminarAsync(int id, string userId)
		{
			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if (seminar == null || seminar.OrganizerId != userId)
			{
				return;
			}

			List<SeminarParticipant> seminarParticipants = await this.context
				.SeminarsParticipants
				.Where(s => s.SeminarId == id)
				.ToListAsync();

			foreach (var sem in seminarParticipants)
			{
				this.context.SeminarsParticipants.Remove(sem);
			}

			await this.context.SaveChangesAsync();

			this.context.Seminars.Remove(seminar);
			await this.context.SaveChangesAsync();
		}

		public async Task EditSeminarAsync(int id, EditSeminarModel model, string userId)
		{
			IdentityUser? user = await this.context.Users.FindAsync(userId);

			if (user == null)
			{
				return;
			}

			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if (seminar == null || seminar.OrganizerId != userId)
			{
				return;
			}

			Category? category = await this.context.Categories.FindAsync(model.CategoryId);

			if (category == null)
			{
				return;
			}


			seminar.Topic = model.Topic;
			seminar.Lecturer = model.Lecturer;
			seminar.Details = model.Details;
			seminar.DateAndTime = DateTime.Parse(model.DateAndTime);
			seminar.Duration = model.Duration;
			seminar.CategoryId = model.CategoryId;
			seminar.Category = category;
			seminar.OrganizerId = userId;
			seminar.Organizer = user;

			await this.context.SaveChangesAsync();
		}

		public async Task<List<AllSeminarViewModel>> GetAllJoindedSeminarsAsync(string userId)
		{
			return await this.context
				.SeminarsParticipants
				.Where(s => s.ParticipantId == userId)
				.Select(s => new AllSeminarViewModel()
				{
					Id = s.Seminar.Id,
					Topic = s.Seminar.Topic,
					Lecturer = s.Seminar.Lecturer,
					Category = s.Seminar.Category.Name,
					Organizer = s.Seminar.Organizer.UserName,
					DateAndTime = s.Seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm")
				})
				.ToListAsync();
		}

		public async Task<List<AllSeminarViewModel>> GetAllSeminarsAsync()
		{
			return await this.context
				.Seminars
				.Select(s => new AllSeminarViewModel()
				{
					Id = s.Id,
					Topic = s.Topic,
					Lecturer = s.Lecturer,
					Category = s.Category.Name,
					Organizer = s.Organizer.UserName,
					DateAndTime = s.DateAndTime.ToString("dd/MM/yyyy HH:mm")
				})
				.ToListAsync();
		}

		public async Task<DeleteSeminarViewModel> GetDeleteSeminarAsync(int id, string userId)
		{
			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if(seminar == null)
			{
				return null;
			}

			if(seminar.OrganizerId != userId)
			{
				throw new ArgumentException("Method GetDeleteSeminarAsync: userId is not matching OrganizerId");
			}

			DeleteSeminarViewModel model = new DeleteSeminarViewModel()
			{
				Id = seminar.Id,
				Topic = seminar.Topic,
				DateAndTime = seminar.DateAndTime,
			};

			return model;
		}

		public async Task<DetailsSeminarViewModel> GetDetailsSeminarAsync(int id)
		{
			DetailsSeminarViewModel? model = await this.context
				.Seminars
				.Where(s => s.Id == id)
				.Select(c => new DetailsSeminarViewModel()
				{
					Id = c.Id,
					Topic = c.Topic,
					Details = c.Details,
					Lecturer = c.Lecturer,
					Category = c.Category.Name,
					Duration = c.Duration,
					Organizer = c.Organizer.UserName,
					DateAndTime = c.DateAndTime.ToString("dd/MM/yyyy HH:mm")
				})
				.FirstOrDefaultAsync();

			if (model == null)
			{
				return null;
			}

			return model;
		}

		public async Task<EditSeminarModel> GetSeminarAsync(int id, string userId)
		{
			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if (seminar == null)
			{
				return null;
			}

			if (seminar.OrganizerId != userId)
			{
				throw new ArgumentException("Method GetSeminarAsync: userId is not matching OrganizerId");
			}

			EditSeminarModel? model = new EditSeminarModel()
			{
				Topic = seminar.Topic,
				Lecturer = seminar.Lecturer,
				Details = seminar.Details,
				DateAndTime = seminar.DateAndTime.ToString("dd/MM/yyyy HH:mm"),
				Duration = seminar.Duration,
				CategoryId = seminar.CategoryId
			};

			return model;
		}

		public async Task<bool> JoinSeminarAsync(int id, string userId)
		{
			IdentityUser? user = await this.context.Users.FindAsync(userId);

			if (user == null)
			{
				return false;
			}

			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if (seminar == null || seminar.OrganizerId == userId)
			{
				return false;
			}

			SeminarParticipant? seminarParticipant1 = await this.context
				.SeminarsParticipants
				.Where(s => s.SeminarId == id && s.ParticipantId == userId)
				.FirstOrDefaultAsync();

			if (seminarParticipant1 != null)
			{
				return false;
			}


			SeminarParticipant seminarParticipant = new SeminarParticipant()
			{
				SeminarId = id,
				Seminar = seminar,
				ParticipantId = userId,
				Participant = user
			};

			await this.context.SeminarsParticipants.AddAsync(seminarParticipant);
			await this.context.SaveChangesAsync();

			return true;
		}

		public async Task LeaveSeminarAsync(int id, string userId)
		{
			IdentityUser? user = await this.context.Users.FindAsync(userId);

			if (user == null)
			{
				return;
			}

			Seminar? seminar = await this.context.Seminars.FindAsync(id);

			if (seminar == null || seminar.OrganizerId == userId)
			{
				return;
			}

			SeminarParticipant? seminarParticipant = await this.context
				.SeminarsParticipants
				.Where(s => s.SeminarId == id && s.ParticipantId == userId)
				.FirstOrDefaultAsync();

			if (seminarParticipant == null)
			{
				return;
			}

			this.context.SeminarsParticipants.Remove(seminarParticipant);
			await this.context.SaveChangesAsync();
		}
	}
}
