using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Shape shape = null;

            string typeShape = Console.ReadLine();

            if (typeShape == "Rectangle")
            {
                double height = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                shape = new Rectangle(height, width);
            }
            else if (typeShape == "Circle")
            {
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
            }

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());
        }
    }
}
