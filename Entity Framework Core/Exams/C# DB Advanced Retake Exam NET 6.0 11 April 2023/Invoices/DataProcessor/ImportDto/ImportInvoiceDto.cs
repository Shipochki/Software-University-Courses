using Invoices.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static Invoices.Data.DataConfig;

namespace Invoices.DataProcessor.ImportDto
{
	[JsonObject]
	public class ImportInvoiceDto
	{
		[JsonProperty("Number")]
		[Required]
		[Range(NumberMinRange, NumberMaxRange)]
		public int Number { get; set; }

		[JsonProperty("IssueDate")]
		[Required]
		public DateTime IssueDate { get; set; }

		[JsonProperty("DueDate")]
		[Required]
		public DateTime DueDate { get; set; }

		[JsonProperty("Amount")]
		[Required]
		public decimal Amount { get; set; }

		[JsonProperty("CurrencyType")]
		[Range(0, 2)]
		[Required]
		public CurrencyType CurrencyType { get; set; }

		[JsonProperty("ClientId")]
		[Required]
		public int ClientId { get; set; }
	}
}
