namespace Artillery.DataProcessor.ImportDto
{

	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;
	using static Data.DataConfig;

	[XmlType("Country")]
	public class ImportCountryDbo
	{
		[XmlElement("CountryName")]
		[Required]
		[MinLength(MinLengthCountryName)]
		[MaxLength(MaxLengthCountryName)]
		public string CountryName { get; set; } = null!;

		[XmlElement("ArmySize")]
		[Required]
		[Range(MinRangeCountryArmySize, MaxRangeCountryArmySize)]
		public int ArmySize { get; set; }
	}
}
