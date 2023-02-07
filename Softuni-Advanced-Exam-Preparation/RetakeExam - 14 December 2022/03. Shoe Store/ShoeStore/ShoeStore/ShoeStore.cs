using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            this.shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        IReadOnlyCollection<Shoe> Shoes => this.shoes;

        public int Count => this.shoes.Count;


        public string AddShoe(Shoe shoe)
        {
            if (this.shoes.Count == this.StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            this.shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int countRemoveShoes = 0;

            for (int i = 0; i < this.shoes.Count; i++)
            {
                if (shoes[i].Material == material.ToLower())
                {
                    shoes.RemoveAt(i--);
                    countRemoveShoes++;
                }
            }

            return countRemoveShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> output = new List<Shoe>();

            foreach (var shoe in this.Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    output.Add(shoe);
                }
            }
            return output;
        }

        public Shoe GetShoeBySize(double size) => this.shoes.FirstOrDefault(s => s.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> shoes = this.shoes.Where(s => s.Type == type && s.Size == size).ToList();

            StringBuilder output = new StringBuilder();

            if (shoes.Count == 0)
            {
                output.AppendLine("No matches found!");
            }
            else
            {
                output.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in shoes)
                {
                    output.AppendLine(shoe.ToString());
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
