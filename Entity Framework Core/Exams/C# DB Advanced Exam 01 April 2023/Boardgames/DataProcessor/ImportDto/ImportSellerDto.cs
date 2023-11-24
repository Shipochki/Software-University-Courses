namespace Boardgames.DataProcessor.ImportDto
{
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using static Boardgames.Data.DataConfig;

	[JsonObject]
	public class ImportSellerDto
	{
		[JsonProperty("Name")]
		[Required]
		[MaxLength(SellerNameMaxLength)]
		[MinLength(SellerNameMinLength)]
		public string Name { get; set; } = null!;

		[JsonProperty("Address")]
		[Required]
		[MaxLength(SellerAddressMaxLength)]
		[MinLength(SellerAddressMinLength)]
		public string Address { get; set; } = null!;

		[JsonProperty("Country")]
		[Required]
		public string Country { get; set; } = null!;

		[JsonProperty("Website")]
		[Required]
		[RegularExpression(@"www.[a-z,A-Z,0-9,-]*.com")]
		public string Website { get; set; } = null!;

		[JsonProperty("Boardgames")]
		public int[] Boardgames { get; set; }
	}
}
