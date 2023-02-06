namespace CarSalesman
{
    public class Engine
    {
        public Engine()
        {

        }

        public Engine(string model, int power)
        {
            Model= model;
            Power= power;
            Displacement = null;
            Efficiency = null;
        }

        public Engine(string model, int power, int? displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int? displacement, string efficiency) : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}