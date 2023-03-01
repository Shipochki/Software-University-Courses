using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numOfHeroes = int.Parse(Console.ReadLine());

            for (int line = 0; line < numOfHeroes; line++)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                BaseHero hero;
                if (typeHero == "Druid")
                    hero = new Druid(name);
                else if (typeHero == "Paladin")
                    hero = new Paladin(name);
                else if (typeHero == "Rogue")
                    hero = new Rogue(name);
                else if (typeHero == "Warrior")
                    hero = new Warrior(name);
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            int raidGroupPower = heroes.Select(x => x.Power).Sum();
            if(raidGroupPower >= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
    }
}
