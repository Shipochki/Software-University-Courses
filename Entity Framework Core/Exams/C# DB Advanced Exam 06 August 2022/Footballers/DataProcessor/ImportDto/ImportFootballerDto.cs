using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Footballers.Data.DataConfig;

namespace Footballers.DataProcessor.ImportDto
{
	[XmlType("Footballer")]
	public class ImportFootballerDto
	{
		[XmlElement("Name")]
		[Required]
		[MaxLength(MaxLengthFootballerName)]
		[MinLength(MinLengthFootballerName)]
		public string Name { get; set; } = null!;

		[XmlElement("ContractStartDate")]
		[Required]
		public string ContractStartDate { get; set; }

		[XmlElement("ContractEndDate")]
		[Required]
		public string ContractEndDate { get; set; }

		[XmlElement("BestSkillType")]
		[Required]
		[Range(0, 4)]
		public int BestSkillType { get; set; }

		[XmlElement("PositionType")]
		[Required]
		[Range(0, 3)]
		public int PositionType { get; set; }
	}
}
