﻿using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OnlineShop.Common.Constants.ExceptionMessages;

namespace OnlineShop.Models.Products.Computers
{
	public abstract class Computer : Product, IComputer
	{
		protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
			: base(id, manufacturer, model, price, overallPerformance)
		{
			this.components = new List<IComponent>();
			this.peripherals = new List<IPeripheral>();
		}

		private List<IComponent> components;

		public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();


		private List<IPeripheral> peripherals;

		public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();


		public override double OverallPerformance
		{
			get
			{
				if (this.components.Count == 0)
				{
					return base.overallPerformance;
				}

				return base.overallPerformance + this.components.Average(c => c.OverallPerformance);
			}
		}

		public override decimal Price
		{
			get
			{
				return base.price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);
			}
		}

		public void AddComponent(IComponent component)
		{
			if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
			{
				throw new ArgumentException(
					string.Format(ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
			}

			this.components.Add(component);
		}

		public void AddPeripheral(IPeripheral peripheral)
		{
			if (this.peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
			{
				throw new ArgumentException(
					string.Format(ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
			}

			this.peripherals.Add(peripheral);
		}

		public IComponent RemoveComponent(string componentType)
		{
			if (this.components.Count == 0 || !this.components.Any(c => c.GetType().Name == componentType))
			{
				throw new ArgumentException(string.Format(NotExistingComponent, componentType, this.GetType().Name, this.Id));
			}

			IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
			this.components.Remove(component);
			return component;
		}

		public IPeripheral RemovePeripheral(string peripheralType)
		{
			if (this.peripherals.Count == 0 || !this.peripherals.Any(p => p.GetType().Name == peripheralType))
			{
				throw new ArgumentException(string.Format(NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
			}

			IPeripheral peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
			this.peripherals.Remove(peripheral);
			return peripheral;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {base.Manufacturer} {this.Model} (Id: {this.Id})");

			sb.AppendLine($" Components ({this.components.Count}):");
			foreach (var component in this.components)
			{
				sb.AppendLine(component.ToString());
			}

			if (this.peripherals.Count == 0)
			{
				sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance (0.00):");
			}
			else
			{
				sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance):f2}):");
				foreach (var peripheral in this.peripherals)
				{
					sb.AppendLine(peripheral.ToString());
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
