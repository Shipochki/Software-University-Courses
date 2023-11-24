namespace Boardgames.DataProcessor.ExportDto
{
	using Newtonsoft.Json;

	[JsonObject]
	public class ExportSellerDto
	{
		[JsonProperty("Name")]
		public string Name { get; set; } = null!;

		[JsonProperty("Website")]
		public string Website { get; set; } = null!;

		[JsonProperty("Boardgames")]
		public ExportBroadGameJSONDto[] Boardgames { get; set;}
	}
}
