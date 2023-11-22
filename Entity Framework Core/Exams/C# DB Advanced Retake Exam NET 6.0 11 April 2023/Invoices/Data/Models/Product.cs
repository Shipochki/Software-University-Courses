namespace Invoices.Data.Models
{
	using Invoices.Data.Models.Enums;
	using System.ComponentModel.DataAnnotations;
	using static DataConfig;
	public class Product
	{
        public Product()
        {
            ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public CategoryType CategoryType { get; set; }

		public ICollection<ProductClient> ProductsClients { get; set; } = null!;
	}
}
