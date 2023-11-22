namespace Invoices.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;
	public class Client
	{
        public Client()
        {
            Invoices = new HashSet<Invoice>();
			Addresses = new HashSet<Address>();
			ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(ClientNameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(NumberVatMaxLength)]
		public string NumberVat { get; set; } = null!;

		public ICollection<Invoice> Invoices { get; set; } = null!;

		public ICollection<Address> Addresses { get; set; } = null!;

		public ICollection<ProductClient> ProductsClients { get; set; } = null!;
	}
}
