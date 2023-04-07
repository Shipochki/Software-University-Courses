using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
	public abstract class Peripheral : Product, IPeripheral
	{
		public Peripheral(int id, string manufacturer, string model, 
			decimal price, double overallPerformance, string connectionType) 
			: base(id, manufacturer, model, price, overallPerformance)
		{
			this.connectionType = connectionType;
		}

		private string connectionType;

		public string ConnectionType
		{
			get { return connectionType; }
			private set { connectionType = value; }
		}

		public override string ToString()
		{
			return $"Overall Performance: {base.OverallPerformance}. Price: {base.Price} - {this.GetType().Name}: {base.Manufacturer} {base.Model} (Id: {base.Id}) Connection Type: {this.connectionType}";
		}
	}
}
