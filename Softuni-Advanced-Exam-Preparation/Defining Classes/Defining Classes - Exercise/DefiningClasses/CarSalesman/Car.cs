using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {

        }
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = null;
            Color = null;
        }

        public Car(string model, Engine engine, int? weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int? weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"{this.Model}: ");
            output.AppendLine($"  {this.Engine.Model}:");
            output.AppendLine($"    Power: {this.Engine.Power}");
            if(this.Engine.Displacement == null)
            {
                output.AppendLine($"    Displacement: n/a");
            }
            else
            {
                output.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }
            if (this.Engine.Efficiency == null)
            {
                output.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                output.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }
            if(this.Weight != null)
            {
                output.AppendLine($"  Weight: {this.Weight}");
            }
            else
            {
                output.AppendLine($"  Weight: n/a");
            }
            if (this.Color != null)
            {
                output.AppendLine($"  Color: {this.Color}");
            }
            else
            {
                output.AppendLine($"  Color: n/a");
            }

            return output.ToString().TrimEnd();
        }
    }
}
