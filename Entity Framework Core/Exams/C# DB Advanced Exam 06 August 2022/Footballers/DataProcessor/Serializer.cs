namespace Footballers.DataProcessor
{
	using Data;
	using Footballers.DataProcessor.ExportDto;
	using Newtonsoft.Json;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;

	public class Serializer
	{
		public static string ExportCoachesWithTheirFootballers(FootballersContext context)
		{
			StringBuilder sb = new StringBuilder();

			ExportCoachDto[] coaches = context
				.Coaches
				.Where(c => c.Footballers.Any())
				.ToArray()
				.Select(c => new ExportCoachDto()
				{
					CoachName = c.Name,
					Footballers = c.Footballers
					.Select(f => new ExportFootabllerXmlDto()
					{
						Name = f.Name,
						Position = f.PositionType.ToString()
					})
					.OrderBy(c => c.Name)
					.ToArray(),
					FootballersCount = c.Footballers.Count()
				})
				.OrderByDescending(c => c.FootballersCount)
				.ThenBy(c => c.CoachName)
				.ToArray();

			XmlRootAttribute xmlRoot = new XmlRootAttribute("Coaches");

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachDto[]), xmlRoot);

			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			using StringWriter writer = new StringWriter(sb);
			xmlSerializer.Serialize(writer, coaches, namespaces);

			return sb.ToString().Trim();
		}

		public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
		{
			ExportTeamDto[] teams = context
				.Teams
				.Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
				.ToArray()
				.Select(t => new ExportTeamDto()
				{
					Name = t.Name,
					Footballers = t.TeamsFootballers
					.Where(tf => tf.Footballer.ContractStartDate >= date)
					.ToArray()
					.OrderByDescending(tf => tf.Footballer.ContractEndDate)
					.ThenBy(tf => tf.Footballer.Name)
					.Select(tf => new ExportFootballerDto()
					{
						FootballerName = tf.Footballer.Name,
						ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
						ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
						BestSkillType = tf.Footballer.BestSkillType.ToString(),
						PositionType = tf.Footballer.PositionType.ToString()
					})
					.ToArray()
				})
				.OrderByDescending(t => t.Footballers.Length)
				.ThenBy(t => t.Name)
				.Take(5)
				.ToArray();

			string json = JsonConvert.SerializeObject(teams, Formatting.Indented);

			return json;
		}
	}
}
