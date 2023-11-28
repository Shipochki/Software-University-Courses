using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Footballers.Data.DataConfig;

namespace Footballers.DataProcessor.ImportDto
{
	[JsonObject]
	public class ImportTeamDto
	{
		[JsonProperty("Name")]
		[Required]
		[MaxLength(MaxLengthTeamName)]
		[MinLength(MinLengthTeamName)]
		[RegularExpression(@"[a-z,A-Z,0-9, ,.,\-]*$")]
		public string Name { get; set; } = null!;

		[JsonProperty("Nationality")]
		[Required]
		[MaxLength(MaxLengthTeamNationality)]
		[MinLength(MinLengthTeamNationality)]
		public string Nationality { get; set; } = null!;

		[JsonProperty("Trophies")]
		[Required]
		public int Trophies { get; set; }

		[JsonProperty("Footballers")]
		public int[] Footballers { get; set; }
	}
}
