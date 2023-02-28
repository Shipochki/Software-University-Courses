using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : ICitizen
    {
        private string model;
        public Robot(string model, string iD)
        {
            this.model = model;
            ID = iD;
        }

        public string ID { get; set; }
    }
}
