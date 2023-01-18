using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VipGuests = new HashSet<string>();
            HashSet<string> RegularGuests = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }
                else if (guest.Length == 8)
                {
                    if (char.IsDigit(guest[0]))
                    {
                        VipGuests.Add(guest);
                    }
                    else
                    {
                        RegularGuests.Add(guest);
                    }
                }
            }

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }
                else if (char.IsDigit(guest[0]))
                {
                    VipGuests.Remove(guest);
                }
                else
                {
                    RegularGuests.Remove(guest);
                }
            }

            Console.WriteLine(VipGuests.Count + RegularGuests.Count);

            foreach (var guest in VipGuests)
            {
                Console.WriteLine(guest.ToString());
            }
            foreach (var guest in RegularGuests)
            {
                Console.WriteLine(guest.ToString());
            }
        }
    }
}
