using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Family
    {
        private List<Person> familyList;

        public Family()
        {
            this.familyList = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.familyList.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = this.familyList.Max(member => member.Age);
            Person member = this.familyList.Find(member => member.Age == maxAge);
            return member;
        }

        public List<Person> GetOldestMembers()
        {
            return this.familyList.Where(member => member.Age > 30).OrderBy(a => a.Name).ToList();    
        }
    }
}
