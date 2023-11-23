using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.DataConfig;

namespace Invoices.DataProcessor.ImportDto
{
	[XmlType("Client")]
	public class ImportClientDto
	{
		[XmlElement("Name")]
		[Required]
		[MaxLength(ClientNameMaxLength)]
		[MinLength(ClientNameMinLength)]
		public string Name { get; set; } = null!;

		[XmlElement("NumberVat")]
		[Required]
		[MaxLength(NumberVatMaxLength)]
		[MinLength(NumberVatMinLength)]
		public string NumberVat { get; set; } = null!;

		[XmlArray("Addresses")]
		public ImportAddressDto[] Addresses { get; set; }
	}
}
