using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Trucks.Data.DataConfig;

namespace Trucks.DataProcessor.ImportDto
{
	[XmlType("Truck")]
	public class ImportTruckDto
	{
		[XmlElement("RegistrationNumber")]
		[Required]
		[RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
		public string RegistrationNumber { get; set; } = null!;

		[XmlElement("VinNumber")]
		[Required]
		[StringLength(17)]
		public string VinNumber { get; set; } = null!;

		[XmlElement("TankCapacity")]
		[Required]
		[Range(MinRangeTankCapacity, MaxRangeTankCapacity)]
		public int TankCapacity { get; set; }

		[XmlElement("CargoCapacity")]
		[Required]
		[Range(MinRangeCargoCapacity, MaxRangeCargoCapacity)]
		public int CargoCapacity { get; set;}

		[XmlElement("CategoryType")]
		[Required]
		[Range(0, 3)]
		public int CategoryType { get; set; }

		[XmlElement("MakeType")]
		[Required]
		[Range(0, 4)]
		public int MakeType { get; set; }
	}
}
