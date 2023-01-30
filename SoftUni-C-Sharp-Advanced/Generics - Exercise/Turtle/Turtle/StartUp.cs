using System;
using System.Collections.Generic;
using System.Linq;

namespace Turtle
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Threeuple> turtles = new List<Threeuple>();

            FirstData(turtles);

            SecondData(turtles);

            LastData(turtles);

            foreach (var cTurtle in turtles)
            {
                Console.WriteLine($"{cTurtle.Item1} -> {cTurtle.Item2} -> {cTurtle.Item3}");
            }
        }

        private static void LastData(List<Threeuple> turtles)
        {
            var lastData = Console.ReadLine().Split();
            string nameOfPersonFromBank = lastData[0];
            double accountBalance = double.Parse(lastData[1]);
            string bankName = lastData[2];
            var turtle = new Threeuple(nameOfPersonFromBank, accountBalance, bankName);
            turtles.Add(turtle);
        }

        private static void SecondData(List<Threeuple> turtles)
        {
            var secondData = Console.ReadLine().Split();
            string nameOfPerson = secondData[0];
            int amountOfBeer = int.Parse(secondData[1]);
            bool drunOrNot = secondData[2] == "drunk";
            var turtle = new Threeuple(nameOfPerson, amountOfBeer, drunOrNot);
            turtles.Add(turtle);
        }

        private static void FirstData(List<Threeuple> turtles)
        {
            var firstData = Console.ReadLine().Split().ToList();
            string name = $"{firstData[0]} {firstData[1]}";
            string address = firstData[2];
            firstData.RemoveRange(0, 3);
            string city = string.Empty;

            foreach (var item in firstData)
            {
                city += item + " ";
            }

            var turtle = new Threeuple(name, address, city);
            turtles.Add(turtle);
        }

    }
}
