using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Data.DataConfig;

namespace Boardgames.DataProcessor.ImportDto
{
	[XmlType("Creator")]
	public class ImportCreatorDto
	{
		[XmlElement("FirstName")]
		[Required]
		[MaxLength(CreatorFirstNameMaxLength)]
		[MinLength(CreatorFirstNameMinLength)]
		public string FirstName { get; set; } = null!;

		[XmlElement("LastName")]
		[Required]
		[MaxLength(CreatorLastNameMaxLength)]
		[MinLength(CreatorLastNameMinLength)]
		public string LastName { get; set; } = null!;

		[XmlArray("Boardgames")]
		public ImportBoardgameDto[] Boardgames { get; set; } 
	}
}
