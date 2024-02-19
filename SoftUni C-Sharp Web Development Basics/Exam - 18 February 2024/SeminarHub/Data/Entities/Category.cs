using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstatns;

namespace SeminarHub.Data.Entities
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public List<Seminar> Seminars { get; set; } = new List<Seminar>();
	}
}
