using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
	[XmlType("Despatcher")]
	public class ExportDespatcherDto
	{
		[XmlElement("DespatcherName")]
		public string DespatcherName { get; set; }

		[XmlAttribute("TrucksCount")]
		public int TrucksCount { get; set; }

		[XmlArray("Trucks")]
		public ExportTruckXmlDto[] Trucks { get; set; }
	}
}
