namespace Trucks.DataProcessor
{
    using Data;
	using Newtonsoft.Json;
	using System.Text;
	using System.Xml.Serialization;
	using Trucks.DataProcessor.ExportDto;

	public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            StringBuilder sb = new StringBuilder();

            ExportDespatcherDto[] despatcherDtos = context
                .Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                    .Select(t => new ExportTruckXmlDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString(),
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray(),
                    TrucksCount = d.Trucks.Count
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Despatchers");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportDespatcherDto[]), xmlRoot);

			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, despatcherDtos, namespaces);

            return sb.ToString().Trim();
		}

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            ExportClientDto[] clients = context
                .Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new ExportClientDto()
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(ct => ct.Truck.TankCapacity >= capacity)
                    .Select(ct => new ExportTruckDto()
                    {
                        TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                        VinNumber = ct.Truck.VinNumber,
                        TankCapacity = ct.Truck.TankCapacity,
                        CargoCapacity = ct.Truck.CargoCapacity,
                        CategoryType = ct.Truck.CategoryType.ToString(),
                        MakeType = ct.Truck.MakeType.ToString()
                    })
                    .OrderBy(ct => ct.MakeType)
                    .ThenByDescending(ct => ct.CargoCapacity)
                    .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            return json;
        }
    }
}
