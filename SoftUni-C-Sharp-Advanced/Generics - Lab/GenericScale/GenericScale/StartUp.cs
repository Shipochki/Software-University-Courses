using System;

namespace GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var n = new EqualityScale<int>(5, 6);

            Console.WriteLine(n.AreEqual());
        }
    }
}
