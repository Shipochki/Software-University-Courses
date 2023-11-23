using Newtonsoft.Json;

namespace Invoices.DataProcessor.ExportDto
{
	[JsonObject]
	public class ExportProductDto
	{
		[JsonProperty("Name")]
		public string Name { get; set; } = null!;

		[JsonProperty("Price")]
		public decimal Price { get; set; }

		[JsonProperty("Category")]
		public string Category { get; set; } = null!;

		[JsonProperty("Clients")]
		public ExportClientDto[] Clients { get; set; } = null!;
	}
}
