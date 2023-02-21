using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public RandomList()
        {
            List = new List<string>();
        }
        public List<string> List { get; set; }

        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0, Count);
            string text = this[index];
            RemoveAt(index);
            return text;
        }
    }
}
