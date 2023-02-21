using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public void Main(string[] args)
        {
            RandomList strings = new RandomList();

            strings.Add("3");
            strings.Add("2");
            strings.Add("4");

            Console.WriteLine(strings.RandomString());
        }
    }
}
