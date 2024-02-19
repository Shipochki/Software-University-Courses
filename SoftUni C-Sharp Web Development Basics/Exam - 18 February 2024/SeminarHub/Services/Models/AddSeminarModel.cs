using SeminarHub.Models;
using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstatns;

namespace SeminarHub.Services.Models
{
	public class AddSeminarModel
	{
		[Required]
		[MinLength(TopicMinLength)]
		[MaxLength(TopicMaxLength)]
		public string Topic { get; set; } = null!;

		[Required]
		[MinLength(LecturerMinLength)]
		[MaxLength(LecturerMaxLength)]
		public string Lecturer { get; set; } = null!;

		[Required]
		[MinLength(DetailsMinLength)]
		[MaxLength(DetailsMaxLength)]
		public string Details { get; set; } = null!;

		[Required]
		public string DateAndTime { get; set; } = null!;

		[Range(DurationMinRange, DurationMaxRange)]
		public int Duration { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
	}
}
