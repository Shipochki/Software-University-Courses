using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if(Registry.Count == Capacity)
            {
                return false;
            }
            else
            {
                Registry.Add(child);
                return true;
            }
        }

        public bool RemoveChild(string childFullName)
        {
            string firstName = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[1];
            bool isContained = false;
            Child childToRemove = null;

            foreach(Child child in Registry)
            {
                if(child.FirstName == firstName && child.LastName == lastName)
                {
                    isContained = true;
                    childToRemove = child;
                    break;
                }
            }

            if(isContained)
            {
                Registry.Remove(childToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            string firstName = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries)[1];

            foreach (Child child in Registry)
            {
                if (child.FirstName == firstName && child.LastName == lastName)
                {
                    return child;
                }
            }

            return null;
        }

        public string RegistryReport()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry
                .OrderByDescending(c => c.Age)
                .ThenBy(c => c.LastName)
                .ThenBy(c => c.FirstName))
            {
                output.AppendLine(child.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
