using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Telephony
{
    public class SmartPhone : IPhone
    {
        private string site;
        public SmartPhone()
        {
            
        }

        public string PhoneNumber { get; set; }

        public string Site
        {
            get { return this.site; }
            set
            {
                if (ContainsDigit(value))
                    throw new ArgumentException("Invalid URL!");

                this.site = value;
            }
        }

        private bool ContainsDigit(string value)
        {
            foreach (char c in value)
                if(char.IsDigit(c))
                    return true;

            return false;
        }

        public void Calling(string phoneNumber)
        {
            if (!ContainsLettersOrSymbols(phoneNumber))
                Console.WriteLine($"Calling... {phoneNumber}");
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

        public void Browsing(string site)
        {
            if (!ContainsDigit(site))
                Console.WriteLine($"Browsing: {site}!");
            else
                throw new ArgumentException("Invalid URL!");
        }
    }
}
