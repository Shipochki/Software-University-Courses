using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }
        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if(string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            else if(fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if(fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            else if(this.Count == this.Capacity)
            {
                return "Fishing net is full.";
            }

            this.Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if(this.Fish.Any(f => f.Weight == weight))
            {
                Fish fishToRemove = this.Fish.First(f => f.Weight == weight);
                this.Fish.Remove(fishToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double maxLenght = this.Fish.Max(f => f.Length);
            return this.Fish.FirstOrDefault(f => f.Length == maxLenght);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var item in this.Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
