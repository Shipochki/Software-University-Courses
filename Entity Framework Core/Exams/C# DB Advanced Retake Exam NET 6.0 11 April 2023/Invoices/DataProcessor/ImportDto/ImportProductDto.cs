using Invoices.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Invoices.Data.DataConfig;

namespace Invoices.DataProcessor.ImportDto
{
	[JsonObject]
	public class ImportProductDto
	{
		[Required]
		[JsonProperty("Name")]
		[MaxLength(NameMaxLength)]
		[MinLength(NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[JsonProperty("Price")]
		[Range((double)PriceMinRange, (double)PriceMaxRange)]
		public decimal Price { get; set; }

		[Required]
		[JsonProperty("CategoryType")]
		[Range(0, 4)]
		public CategoryType CategoryType { get; set; }

		[JsonProperty("Clients")]
		public int[] Clients { get; set; } = null!;
	}
}
