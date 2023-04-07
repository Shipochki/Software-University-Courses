using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
	public abstract class Component : Product, IComponent
	{
		public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
			: base(id, manufacturer, model, price, overallPerformance)
		{
			this.generation = generation;
		}

		private int generation;

		public int Generation
		{
			get { return generation; }
			private set { generation = value; }
		}

		public override string ToString()
		{
			return $"  Overall Performance: {base.OverallPerformance:f2}. Price: {base.Price:f2} - {this.GetType().Name}: {base.Manufacturer} {base.Model} (Id: {base.Id}) Generation: {this.generation}";
		}
	}
}
