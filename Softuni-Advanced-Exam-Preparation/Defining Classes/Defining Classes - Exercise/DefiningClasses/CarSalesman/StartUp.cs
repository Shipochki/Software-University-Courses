namespace CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int linesEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesEngines; i++)
            {
                Engine engine = new Engine();
                string[] splitedData = Console.ReadLine()
                    .Split();

                string model = splitedData[0];
                int power = int.Parse(splitedData[1]);
                string thirthInput = string.Empty;
                int displacement = 0;

                if (splitedData.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                else if (splitedData.Length == 4)
                {
                    displacement = int.Parse(splitedData[2]);
                    string efficiency = splitedData[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (int.TryParse(splitedData[2], out displacement))
                {
                    displacement = int.Parse(splitedData[2]);
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficieny = splitedData[2];
                    engine = new Engine(model, power, efficieny);
                }
                engines.Add(engine);
            }

            int linesCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCars; i++)
            {
                Car car = new Car();

                string[] splitedData = Console.ReadLine()
                    .Split();

                string model = splitedData[0];
                string engineModel = splitedData[1];
                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
                int weight = 0;

                if (splitedData.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (splitedData.Length == 4)
                {
                    weight = int.Parse(splitedData[2]);
                    string color = splitedData[3];

                    car = new Car(model, engine, weight, color);
                }
                else if (int.TryParse(splitedData[2], out weight))
                {
                    weight = int.Parse(splitedData[2]);
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = splitedData[2];
                    car = new Car(model, engine, color);
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}