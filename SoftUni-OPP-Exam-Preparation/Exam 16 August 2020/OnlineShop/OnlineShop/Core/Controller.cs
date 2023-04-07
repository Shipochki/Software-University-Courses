using OnlineShop.Models.Products.Computers;
using System;
using System.Collections;
using System.Collections.Generic;
using static OnlineShop.Common.Constants.ExceptionMessages;
using static OnlineShop.Common.Constants.SuccessMessages;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
	public class Controller : IController
	{
		private ICollection<IComputer> computers;
		private ICollection<IComponent> components;
		private ICollection<IPeripheral> peripherals;

		public Controller()
		{
			this.computers = new List<IComputer>();
			this.components = new List<IComponent>();
			this.peripherals = new List<IPeripheral>();
		}

		public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			if(this.components.FirstOrDefault(c => c.Id == id) != null)
			{
				throw new ArgumentException(ExistingComponentId);
			}

			IComponent component;
			if(componentType == nameof(CentralProcessingUnit))
			{
				component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if(componentType == nameof(Motherboard))
			{
				component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if(componentType == nameof(PowerSupply))
			{
				component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if(componentType == nameof(RandomAccessMemory))
			{
				component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if(componentType == nameof(SolidStateDrive))
			{
				component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if(componentType == nameof(VideoCard))
			{
				component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
			}
			else
			{
				throw new ArgumentException(InvalidComponentType);
			}

			computer.AddComponent(component);
			this.components.Add(component);

			return string.Format(AddedComponent, componentType, id, computerId);
		}

		public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
		{
			if (this.computers.FirstOrDefault(c => c.Id == id) != null)
			{
				throw new ArgumentException(ExistingComputerId);
			}

			IComputer computer;
			if (computerType == nameof(DesktopComputer))
			{
				computer = new DesktopComputer(id, manufacturer, model, price);
			}
			else if(computerType == nameof(Laptop))
			{
				computer = new Laptop(id, manufacturer, model, price);
			}
			else
			{
				throw new ArgumentException(InvalidComputerType);
			}

			this.computers.Add(computer);
			return string.Format(AddedComputer, id);
		}

		public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			if(this.peripherals.FirstOrDefault(p => p.Id == id) != null)
			{
				throw new ArgumentException(ExistingPeripheralId);
			}

			IPeripheral peripheral;
			if (peripheralType == nameof(Headset))
			{
				peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if(peripheralType == nameof(Keyboard)) 
			{
				peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if(peripheralType == nameof(Monitor))
			{
				peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if(peripheralType == nameof(Mouse))
			{
				peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else
			{
				throw new ArgumentException(InvalidPeripheralType);
			}

			computer.AddPeripheral(peripheral);
			this.peripherals.Add(peripheral);

			return string.Format(AddedPeripheral, peripheralType, id, computer.Id);
		}

		public string BuyBest(decimal budget)
		{
			IComputer computer = this.computers
				.OrderByDescending(c => c.OverallPerformance)
				.Where(c => c.Price <= budget)
				.FirstOrDefault();

			if(computer == null)
			{
				throw new ArgumentException(string.Format(CanNotBuyComputer, budget));
			}

			return BuyComputer(computer.Id);
		}

		public string BuyComputer(int id)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			this.computers.Remove(computer);
			return computer.ToString();
		}

		public string GetComputerData(int id)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			return computer.ToString();
		}

		public string RemoveComponent(string componentType, int computerId)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			IComponent component = computer.RemoveComponent(componentType);
			this.components.Remove(component);

			return string.Format(RemovedComponent, componentType, component.Id);
		}

		public string RemovePeripheral(string peripheralType, int computerId)
		{
			IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(NotExistingComputerId);
			}

			IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
			this.peripherals.Remove(peripheral);

			return string.Format(RemovedPeripheral, peripheralType, peripheral.Id);
		}
	}
}
