using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if(this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            int index = 0;
            foreach (var cpu in this.Multiprocessor)
            {
                if(cpu.Brand == brand)
                {
                    this.Multiprocessor.RemoveAt(index);
                    return true;
                }
                index++;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            double powerFul = this.Multiprocessor.Max(c => c.Frequency);
            foreach (var cpu in this.Multiprocessor)
            {
                if(cpu.Frequency == powerFul)
                {
                    return cpu;
                }
            }

            return null;
        }

        public CPU GetCPU(string brand)
        {
            foreach (var cpu in this.Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    return cpu;
                }
            }

            return null;
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var cpu in this.Multiprocessor)
            {
                output.AppendLine(cpu.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
