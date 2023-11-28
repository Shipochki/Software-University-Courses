namespace Footballers.DataProcessor.ImportDto
{
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;
	using static Footballers.Data.DataConfig;


	[XmlType("Coach")]
	public class ImportCoachDto
	{
		[XmlElement("Name")]
		[Required]
		[MaxLength(MaxLengthCoachName)]
		[MinLength(MinLengthCoachName)]
		public string Name { get; set; } = null!;

		[XmlElement("Nationality")]
		[Required]
		public string Nationality { get; set; } = null!;

		[XmlArray("Footballers")]
		public ImportFootballerDto[] Footballers { get; set; }
	}
}
