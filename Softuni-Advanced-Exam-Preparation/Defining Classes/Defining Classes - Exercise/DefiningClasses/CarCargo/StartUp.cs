namespace CarCargo
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] splitedInputData = Console.ReadLine()
                    .Split()
                    .ToArray();

                string modelCar = splitedInputData[0];

                int engineSpeed = int.Parse(splitedInputData[1]);
                int enginePower = int.Parse(splitedInputData[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(splitedInputData[3]);
                string cargoType = splitedInputData[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double frontLeftTirePressure = double.Parse(splitedInputData[5]);
                int frontLeftTireAge = int.Parse(splitedInputData[6]);
                Tire frontLeftTire = new Tire(frontLeftTirePressure, frontLeftTireAge);

                double frontRightTirePressure = double.Parse(splitedInputData[7]);
                int frontRightTireAge = int.Parse(splitedInputData[8]);
                Tire frontRightTire = new Tire(frontRightTirePressure, frontRightTireAge);

                double backLeftTirePressure = double.Parse(splitedInputData[9]);
                int backLeftTireAge = int.Parse(splitedInputData[10]);
                Tire backLeftTire = new Tire(backLeftTirePressure, backLeftTireAge);

                double backRightTirePressure = double.Parse(splitedInputData[11]);
                int backRightTireAge = int.Parse(splitedInputData[12]);
                Tire backRightTire = new Tire(backRightTirePressure, backRightTireAge);

                List<Tire> tires = new List<Tire>();
                tires.Add(frontLeftTire);
                tires.Add(frontRightTire);
                tires.Add(backLeftTire);
                tires.Add(backRightTire);

                Car car = new Car(modelCar, engine, cargo, tires);
                cars.Add(car);
            }

            string typeCargo = Console.ReadLine();

            foreach (var car in cars)
            {
                if(typeCargo == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
                else if(typeCargo == "flammable" && car.Engine.HorsePower > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}