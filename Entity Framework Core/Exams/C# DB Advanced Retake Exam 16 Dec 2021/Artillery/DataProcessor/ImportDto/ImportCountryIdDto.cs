namespace Artillery.DataProcessor.ImportDto
{
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;


	[JsonObject]
	public class ImportCountryIdDto
	{
		[Required]
		public int Id { get; set; }
	}
}
