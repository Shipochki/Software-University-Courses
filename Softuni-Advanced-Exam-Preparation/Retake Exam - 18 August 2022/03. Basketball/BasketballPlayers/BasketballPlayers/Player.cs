using System;
using System.Collections.Generic;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public double Rating { get; set; }

        public int Games { get; set; }

        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"-Player: {this.Name}");
            output.AppendLine($"--Position: {this.Position}");
            output.AppendLine($"--Rating: {this.Rating}");
            output.AppendLine($"--Games: {this.Games}");

            return output.ToString().TrimEnd();
        }
    }
}
