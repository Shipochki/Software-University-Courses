namespace Invoices.DataProcessor
{
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;
	using System.Xml.Serialization;
	using Invoices.Data;
	using Invoices.Data.Models;
	using Invoices.DataProcessor.ImportDto;
	using Newtonsoft.Json;

	public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Clients");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportClientDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportClientDto[] importClientDtos = (ImportClientDto[])xmlSerializer.Deserialize(reader);

            ICollection<Client> clients = new List<Client>();

            foreach (var dto in importClientDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = dto.Name,
                    NumberVat = dto.NumberVat,
                };

                ICollection<Address> addresses = new List<Address>();

                foreach (var aDto in dto.Addresses) 
                {
                    if (!IsValid(aDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = aDto.StreetName,
                        StreetNumber = aDto.StreetNumber,
                        PostCode = aDto.PostCode,
                        City = aDto.City,
                        Country = aDto.Country,
                    };

                    addresses.Add(address);
                }

                client.Addresses = addresses;

                clients.Add(client);

                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportInvoiceDto[] importInvoiceDtos =
                JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);

            ICollection<Invoice> invoices = new List<Invoice>();

            foreach (var dto in importInvoiceDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(dto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    || dto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Number = dto.Number,
                    IssueDate = dto.IssueDate,
                    DueDate = dto.DueDate,
                    Amount = dto.Amount,
                    CurrencyType = dto.CurrencyType,
                    ClientId = dto.ClientId,
                };

                if(dto.DueDate < dto.IssueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

				invoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportProductDto[] importProductDtos =
                JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            ICollection<Product> products = new HashSet<Product>();
            

            foreach (var prodDto in importProductDtos)
            {
                if (!IsValid(prodDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new Product()
                {
                    Name = prodDto.Name,
                    Price = prodDto.Price,
                    CategoryType = prodDto.CategoryType,
                };

                foreach (var clientId in prodDto.Clients.Distinct())
                {
                    Client client = context.Clients.Find(clientId);

                    if(client == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient()
                    {
                        Client = client
                    });
                }

                products.Add(product);

                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
