namespace Trucks.DataProcessor.ImportDto
{
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using static Trucks.Data.DataConfig;

	[JsonObject]
	public class ImportClientDto
	{
		[JsonProperty("Name")]
		[Required]
		[MaxLength(MaxLengthClientName)]
		[MinLength(MinLengthClinetName)]
		public string Name { get; set; } = null!;

		[JsonProperty("Nationality")]
		[Required]
		[MaxLength(MaxLengthNationality)]
		[MinLength(MinLengthNationality)]
		public string Nationality { get; set; } = null!;

		[JsonProperty("Type")]
		[Required]
		public string Type { get; set; } = null!;

		[JsonProperty("Trucks")]
		public int[] Trucks { get; set; }
	}
}
