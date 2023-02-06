using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> family;

        public Family()
        {
            this.family = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.family.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = this.family.Max(m => m.Age);
            Person oldest = this.family.First(m => m.Age == maxAge);
            

            return oldest;
        }

        public List<Person> GetOldestMembers() 
        {
            return this.family.Where(m => m.Age > 30).ToList();
        }
    }
}
