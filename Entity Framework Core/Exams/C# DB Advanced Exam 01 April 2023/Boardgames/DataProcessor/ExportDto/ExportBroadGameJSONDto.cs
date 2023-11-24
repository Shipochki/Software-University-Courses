namespace Boardgames.DataProcessor.ExportDto
{
	using Newtonsoft.Json;

	[JsonObject]
	public class ExportBroadGameJSONDto
	{
		[JsonProperty("Name")]
		public string Name { get; set; } = null!;

		[JsonProperty("Rating")]
		public double Rating { get; set; }

		[JsonProperty("Mechanics")]
		public string Mechanics { get; set; } = null!;

		[JsonProperty("Category")]
		public string Category { get; set; } = null!;
	}
}
