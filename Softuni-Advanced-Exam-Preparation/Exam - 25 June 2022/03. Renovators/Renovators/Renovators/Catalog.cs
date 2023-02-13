using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Renovators
{
    public class Catalog
    {
        private ICollection<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            string output = string.Empty;

            if(string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                output = "Invalid renovator's information.";
            }
            else if(this.Count == this.NeededRenovators)
            {
                output = "Renovators are no more needed.";
            }
            else if(renovator.Rate > 350)
            {
                output = "Invalid renovator's rate.";
            }
            else
            {
                output = $"Successfully added {renovator.Name} to the catalog.";
                this.renovators.Add(renovator);
            }

            return output;
        }

        public bool RemoveRenovator(string name)
        {
            if(this.renovators.Any(r => r.Name == name))
            {
                Renovator renovator = this.renovators.First(r => r.Name == name);
                this.renovators.Remove(renovator);
                return true;
            }
            
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            while (this.renovators.Any(r => r.Type == type))
            {
                Renovator renovator = this.renovators.First(r => r.Type == type);
                this.renovators.Remove(renovator);
                count++;
            }

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            if(this.renovators.Any(r => r.Name == name))
            {
                Renovator renovator = this.renovators.First(r => r.Name == name);
                renovator.Hired = true;
                return renovator;
            }
            else
            {
                return null;
            }
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in this.renovators)
            {
                if(!renovator.Hired)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
