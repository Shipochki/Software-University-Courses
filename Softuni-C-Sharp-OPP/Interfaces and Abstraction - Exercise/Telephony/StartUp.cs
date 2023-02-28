using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers = Console.ReadLine().Split().ToList();
            List<string> sites = Console.ReadLine().Split().ToList();

            foreach (var currentPhone in phoneNumbers)
            {
                try
                {
                    if (currentPhone.Length == 7)
                    {
                        StationaryPhone phone = new StationaryPhone();
                        phone.Calling(currentPhone);
                    }
                    else
                    {
                        SmartPhone phone = new SmartPhone();
                        phone.Calling(currentPhone);
                    }
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                }

            }

            foreach (var site in sites)
            {
                try
                {
                    SmartPhone phone = new SmartPhone();
                    phone.Browsing(site);
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                }

            }
        }
    }
}
