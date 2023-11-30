namespace Artillery.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;

	public class Manufacturer
	{
        public Manufacturer()
        {
			Guns = new HashSet<Gun>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthManufacturerName)]
		public string ManufacturerName { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthManufacturerFounded)]
		public string Founded { get; set; } = null!;

		public ICollection<Gun> Guns { get; set; }
	}
}
