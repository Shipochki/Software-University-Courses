using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());

            SoulMaster soulmaster = new SoulMaster(username, level);

            Console.WriteLine(soulmaster.ToString());
        }
    }
}