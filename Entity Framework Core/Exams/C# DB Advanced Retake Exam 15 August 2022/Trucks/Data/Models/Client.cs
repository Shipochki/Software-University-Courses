namespace Trucks.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Trucks.Data.DataConfig;

	public class Client
	{
        public Client()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthClientName)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthNationality)]
		public string Nationality { get; set; } = null!;

		[Required]
		public string Type { get; set; } = null!;

		public ICollection<ClientTruck> ClientsTrucks { get; set; }
	}
}
