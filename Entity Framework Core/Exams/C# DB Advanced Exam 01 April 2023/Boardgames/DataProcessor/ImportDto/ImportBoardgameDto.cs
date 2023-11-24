namespace Boardgames.DataProcessor.ImportDto
{
	using Boardgames.Data.Models.Enums;
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;
	using static Boardgames.Data.DataConfig;

	[XmlType("Boardgame")]
	public class ImportBoardgameDto
	{
		[XmlElement("Name")]
		[Required]
		[MaxLength(BoardgameNameMaxLength)]
		[MinLength(BoardgameNameMinLength)]
		public string Name { get; set; } = null!;

		[XmlElement("Rating")]
		[Required]
		[Range((double)BoardgameRatingMinRange, (double)BoardgameRatingMaxRange)]
		public double Rating { get; set; }

		[XmlElement("YearPublished")]
		[Required]
		[Range(BoardgameYearPublisherMinRange, BoardgameYearPublisherMaxRange)]
		public int YearPublished { get; set; }

		[XmlElement("CategoryType")]
		[Required]
		[Range(0, 4)]
		public CategoryType CategoryType { get; set; }

		[XmlElement("Mechanics")]
		[Required]
		public string Mechanics { get; set; } = null!;
	}
}
