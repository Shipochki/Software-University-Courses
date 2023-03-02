using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter intrepeter;
        public Engine(ICommandInterpreter intrepeter)
        {
            this.intrepeter = intrepeter;
        }
        public void Run()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();
                Console.WriteLine(this.intrepeter.Read(inputLine));
            }
        }
    }
}
