using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public StationaryPhone() 
        {
            
        }

        public string PhoneNumber { get; set; }

        public void Calling(string phoneNumber)
        {
            if(!ContainsLettersOrSymbols(phoneNumber))
                Console.WriteLine($"Dialing... {phoneNumber}");
            else
                throw new ArgumentException("Invalid number!");
        }

        private bool ContainsLettersOrSymbols(string phoneNumber)
        {
            foreach (var currentChar in phoneNumber)
            {
                if (char.IsLetter(currentChar) || char.IsSymbol(currentChar))
                    return true;
            }

            return false;
        }
    }
}
