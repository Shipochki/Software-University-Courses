namespace Artillery.DataProcessor.ImportDto
{
	using Artillery.Data.Models.Enums;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using static Data.DataConfig;

	[JsonObject]
	public class ImportGunDto
	{
		[JsonProperty("ManufacturerId")]
		[Required]
		public int ManufacturerId { get; set; }

		[JsonProperty("GunWeight")]
		[Required]
		[Range(MinRangeGunWeight, MaxRangeGunWeight)]
		public int GunWeight { get; set; }

		[JsonProperty("BarrelLength")]
		[Required]
		[Range((double)MinRangeGunBarrelLength, (double)MaxRangeGunBarrelLength)]
		public double BarrelLength { get; set; }

		[JsonProperty("NumberBuild")]
		public int? NumberBuild {  get; set; }

		[JsonProperty("Range")]
		[Required]
		[Range(MinRangeGunRange, MaxRangeGunRange)]
		public int Range { get; set; }

		[JsonProperty("GunType")]
		[Required]
		public string GunType { get; set; } = null!;

		[JsonProperty("ShellId")]
		[Required]
		public int ShellId { get; set; }

		[JsonProperty("Countries")]
		public ImportCountryIdDto[] Countries {  get; set; }
	}
}
