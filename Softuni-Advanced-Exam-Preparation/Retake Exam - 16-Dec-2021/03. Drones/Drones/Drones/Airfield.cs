using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public ICollection<Drone> Drones { get; set; }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            StringBuilder output = new StringBuilder();
            if (Count == Capacity)
            {
                output.AppendLine("Airfield is full.");
            }
            else if (string.IsNullOrEmpty(drone.Name))
            {
                output.AppendLine("Invalid drone.");
            }
            else if (string.IsNullOrEmpty(drone.Brand))
            {
                output.AppendLine("Invalid drone.");
            }
            else if (drone.Range < 5 || drone.Range > 15)
            {
                output.AppendLine("Invalid drone.");
            }
            else
            {
                Drones.Add(drone);
                output.AppendLine($"Successfully added {drone.Name} to the airfield.");
            }

            return output.ToString().TrimEnd();
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(d => d.Name == name))
            {
                Drone drone = Drones.First(d => d.Name == name);
                Drones.Remove(drone);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            while (Drones.Any(d => d.Brand == brand))
            {
                Drone drone = Drones.First(d => d.Brand == brand);
                Drones.Remove(drone);
                count++;
            }

            return count;
        }

        public Drone FlyDrone(string name)
        {
            if (Drones.Any(d => d.Name == name))
            {
                Drone drone = Drones.First(d => d.Name == name);
                drone.Available = false;
                return drone;
            }
            else
            {
                return null;
            }
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            return Drones.Where(d => d.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones)
            {
                if (drone.Available)
                {
                    output.AppendLine(drone.ToString());
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
