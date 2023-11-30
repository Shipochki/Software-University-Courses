namespace Artillery.DataProcessor.ImportDto
{
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;
	using static Data.DataConfig;

	[XmlType("Shell")]
	public class ImportShellDto
	{
		[XmlElement("ShellWeight")]
		[Required]
		[Range(MinRangeShellWeight, MaxRangeShellWeight)]
		public double ShellWeight { get; set; }

		[XmlElement("Caliber")]
		[Required]
		[MinLength(MinLengthShellCaliber)]
		[MaxLength(MaxLengthShellCaliber)]
		public string Caliber { get; set; } = null!;
	}
}
