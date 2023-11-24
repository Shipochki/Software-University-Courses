namespace Boardgames.DataProcessor
{
	using Boardgames.Data;
	using Boardgames.DataProcessor.ExportDto;
	using Newtonsoft.Json;
	using System.Linq;
	using System.Text;
	using System.Xml.Serialization;

	public class Serializer
	{
		public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
		{
			StringBuilder sb = new StringBuilder();

			ExportCreatorDto[] exportCreatorDtos = context
				.Creators
				.Where(c => c.Boardgames.Any())
				.ToArray()
				.Select(c => new ExportCreatorDto()
				{
					CreatorName = $"{c.FirstName} {c.LastName}",
					Boardgames = c.Boardgames
					.ToArray()
					.Select(b => new ExportBoardgameXMLDto()
					{
						BoardgameName = b.Name,
						BoardgameYearPublished = b.YearPublished,
					})
					.OrderBy(b => b.BoardgameName)
					.ToArray(),
					BoardgamesCount = c.Boardgames.Count
				})
				.OrderByDescending(c => c.BoardgamesCount)
				.ThenBy(c => c.CreatorName)
				.ToArray();

			XmlRootAttribute xmlRoot = new XmlRootAttribute("Creators");

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCreatorDto[]), xmlRoot);

			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			using StringWriter writer = new StringWriter(sb);
			xmlSerializer.Serialize(writer, exportCreatorDtos, namespaces);

			return sb.ToString().Trim();
		}

		public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
		{
			ExportSellerDto[] exportCreatorsDtos = context
			   .Sellers
			   .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
			   .ToArray()
			   .Select(s => new ExportSellerDto()
			   {
				   Name = s.Name,
				   Website = s.Website,
				   Boardgames = s.BoardgamesSellers
				   .Where(s => s.Boardgame.YearPublished >= year && s.Boardgame.Rating <= rating)
				   .OrderByDescending(bs => bs.Boardgame.Rating)
				   .ThenBy(bs => bs.Boardgame.Name)
				   .Select(bs => new ExportBroadGameJSONDto()
				   {
					   Name = bs.Boardgame.Name,
					   Rating = bs.Boardgame.Rating,
					   Mechanics = bs.Boardgame.Mechanics,
					   Category = bs.Boardgame.CategoryType.ToString(),
				   })
				   .ToArray()
			   })
			   .OrderByDescending(s => s.Boardgames.Length)
			   .ThenBy(s => s.Name)
			   .Take(5)
			   .ToArray();

			string json = JsonConvert.SerializeObject(exportCreatorsDtos, Formatting.Indented);

			return json;
		}
	}
}