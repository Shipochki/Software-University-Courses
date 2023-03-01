using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var splitedDataForCar = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(splitedDataForCar[1]);
            double consumPerKm = double.Parse(splitedDataForCar[2]);
            double tankCapacity = double.Parse(splitedDataForCar[3]);
            Car car = new Car(fuelQuantity, consumPerKm, tankCapacity);

            var splitedDataForTruck = Console.ReadLine().Split();
            fuelQuantity = double.Parse(splitedDataForTruck[1]);
            consumPerKm = double.Parse(splitedDataForTruck[2]);
            tankCapacity = double.Parse(splitedDataForTruck[3]);
            Truck truck = new Truck(fuelQuantity, consumPerKm, tankCapacity);

            var splitedDataForBus = Console.ReadLine().Split();
            fuelQuantity = double.Parse(splitedDataForBus[1]);
            consumPerKm = double.Parse(splitedDataForBus[2]);
            tankCapacity = double.Parse(splitedDataForBus[3]);
            Bus bus = new Bus(fuelQuantity, consumPerKm, tankCapacity);

            int numOfComands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfComands; i++)
            {
                var splitedData = Console.ReadLine().Split();
                string comand = splitedData[0];
                string type = splitedData[1];

                try
                {
                    if (comand == "Drive")
                    {
                        double distance = double.Parse(splitedData[2]);
                        if (type == "Car")
                            car.Drive(distance);
                        else if (type == "Truck")
                            truck.Drive(distance);
                        else if (type == "Bus")
                            bus.Drive(distance);
                    }
                    else if (comand == "Refuel")
                    {
                        double quantity = double.Parse(splitedData[2]);
                        if (type == "Car")
                            car.Refuel(quantity);
                        else if (type == "Truck")
                            truck.Refuel(quantity);
                        else if (type == "Bus")
                            bus.Refuel(quantity);
                    }
                    else if (comand == "DriveEmpty")
                    {
                        double distance = double.Parse(splitedData[2]);
                        if (type == "Bus")
                            bus.DriveEmpty(distance);
                    }
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
