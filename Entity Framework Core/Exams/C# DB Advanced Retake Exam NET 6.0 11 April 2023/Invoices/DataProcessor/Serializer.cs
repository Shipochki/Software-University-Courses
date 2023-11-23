namespace Invoices.DataProcessor
{
    using Invoices.Data;
	using Invoices.DataProcessor.ExportDto;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;

	public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            StringBuilder sb = new StringBuilder();

            ExportClientXmlDto[] exportClientXmlDtos = context
                .Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientXmlDto()
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i => i.DueDate)
                    .Select(i => new ExportInvoiceDto()
                    {
                        Number = i.Number,
                        Amount = i.Amount,
                        DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        Currency = i.CurrencyType.ToString(),
                    })
                    .ToArray(),
                    InvoicesCount = c.Invoices.Count()
                })
                .OrderByDescending(c => c.Invoices.Length)
                .ThenBy(c => c.ClientName)
                .ToArray();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Clients");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportClientXmlDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, exportClientXmlDtos, namespaces);

            return sb.ToString().Trim();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            ExportProductDto[] productDtos = context
                .Products
                .Where(c => c.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .ToArray()
                .Select(c => new ExportProductDto()
                {
                    Name = c.Name,
                    Price = c.Price,
                    Category = c.CategoryType.ToString(),
                    Clients = c.ProductsClients
                    .Where(pc => pc.Client.Name.Length >= nameLength)
                    .OrderBy(pc => pc.Client.Name)
                    .Select(pc => new ExportClientDto()
                    {
                        Name = pc.Client.Name,
                        NumberVat = pc.Client.NumberVat
                    })
                    .ToArray()
                })
                .OrderByDescending(c => c.Clients.Length)
                .ThenBy(c => c.Name)
                .Take(5)
				.ToArray();

            string json = JsonConvert.SerializeObject(productDtos, Formatting.Indented);

            return json;
        }
    }
}