using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }

        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{this.Brand} CPU:");
            output.AppendLine($"Cores: {this.Cores}");
            output.AppendLine($"Frequency: {this.Frequency:f1} GHz");
            return output.ToString().TrimEnd();
        }
    }
}
