using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
	[JsonObject]
	public class ExportClientDto
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Trucks")]
		public ExportTruckDto[] Trucks {  get; set; } 
	}
}
