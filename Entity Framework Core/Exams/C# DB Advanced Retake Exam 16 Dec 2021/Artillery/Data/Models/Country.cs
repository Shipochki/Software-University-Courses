namespace Artillery.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Country
	{
        public Country()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthCountryName)]
		public string CountryName { get; set; } = null!;

		[Required]
		public int ArmySize { get; set; }

		public ICollection<CountryGun> CountriesGuns { get; set; }
	}
}
