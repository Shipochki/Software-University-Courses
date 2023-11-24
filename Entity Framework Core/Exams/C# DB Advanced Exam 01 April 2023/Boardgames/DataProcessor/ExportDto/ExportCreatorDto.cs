using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
	[XmlType("Creator")]
	public class ExportCreatorDto
	{
		[XmlElement("CreatorName")]
		public string CreatorName { get; set; } = null!;

		[XmlAttribute]
		public int BoardgamesCount { get; set; }

		[XmlArray("Boardgames")]
		public ExportBoardgameXMLDto[] Boardgames { get; set; } 
	}
}
