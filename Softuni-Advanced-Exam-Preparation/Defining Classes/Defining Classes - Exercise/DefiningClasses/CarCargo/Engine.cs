namespace CarCargo
{
    public class Engine
    {
        public Engine(int engineSpeed, int horsePower)
        {
            EngineSpeed = engineSpeed;
            HorsePower = horsePower;
        }

        public int EngineSpeed { get; set; }
        public int HorsePower { get; set; }
    }
}