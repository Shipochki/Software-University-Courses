namespace Boardgames.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Creator
	{
        public Creator()
		{
            Boardgames = new HashSet<Boardgame>();
		}

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(CreatorFirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(CreatorLastNameMaxLength)]
		public string LastName { get; set; } = null!;

		public ICollection<Boardgame> Boardgames { get; set; }
	}
}
