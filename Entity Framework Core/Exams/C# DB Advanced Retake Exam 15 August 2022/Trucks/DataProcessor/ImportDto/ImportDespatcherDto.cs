using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Trucks.Data.DataConfig;

namespace Trucks.DataProcessor.ImportDto
{
	[XmlType("Despatcher")]
	public class ImportDespatcherDto
	{
		[XmlElement("Name")]
		[Required]
		[MinLength(MinLengthDespatcherName)]
		[MaxLength(MaxLengthDespatcherName)]
		public string Name { get; set; } = null!;

		[XmlElement("Position")]
		public string? Position {  get; set; }

		[XmlArray("Trucks")]
		public ImportTruckDto[] Trucks { get; set; }
	}
}
