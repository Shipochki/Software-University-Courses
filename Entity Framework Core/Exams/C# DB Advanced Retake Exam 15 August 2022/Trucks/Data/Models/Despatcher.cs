namespace Trucks.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Trucks.Data.DataConfig;

	public class Despatcher
	{
        public Despatcher()
        {
            Trucks = new HashSet<Truck>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthDespatcherName)]
		public string Name { get; set; } = null!;

		public string? Position { get; set; } 

		public ICollection<Truck> Trucks { get; set; }
	}
}
