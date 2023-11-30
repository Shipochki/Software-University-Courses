namespace Artillery.DataProcessor.ImportDto
{
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;
	using static Data.DataConfig;

	[XmlType("Manufacturer")]
	public class ImportManufacturerDto
	{
		[XmlElement("ManufacturerName")]
		[Required]
		[MinLength(MinLengthManufacturerName)]
		[MaxLength(MaxLengthManufacturerName)]
		public string ManufacturerName { get; set; } = null!;

		[XmlElement("Founded")]
		[Required]
		[MinLength(MinLengthManufacturerFounded)]
		[MaxLength(MaxLengthManufacturerFounded)]
		public string Founded { get; set; } = null!;
	}
}
