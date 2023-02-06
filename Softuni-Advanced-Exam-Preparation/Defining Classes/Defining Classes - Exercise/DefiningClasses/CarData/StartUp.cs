namespace CarData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] spliteInputData = Console.ReadLine().Split();
                string model = spliteInputData[0];
                double fuelAmount = double.Parse(spliteInputData[1]);
                double fuelConsumtionPerKm = double.Parse(spliteInputData[2]);

                Car car = new Car(model, fuelAmount, fuelConsumtionPerKm);
                cars.Add(car);
            }

            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "End")
                {
                    break;
                }

                string[] splitedData = inputData
                    .Split()
                    .ToArray();

                string comand = splitedData[0];
                string model = splitedData[1];
                double distance = double.Parse(splitedData[2]);

                if (comand == "Drive")
                {
                    Car car = cars.FirstOrDefault(c => c.Model == model);
                    car.Drive(distance);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}