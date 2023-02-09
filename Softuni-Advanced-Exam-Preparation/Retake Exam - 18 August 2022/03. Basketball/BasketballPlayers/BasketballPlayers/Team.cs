using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            this.players = new List<Player>();
        }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public IReadOnlyCollection<Player> Players => this.players;

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                this.players.Add(player);
                OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isRemoved = false;
            int index = 0;
            foreach (Player player in Players)
            {
                if (player.Name == name)
                {
                    isRemoved = true;
                }
                index++;
            }

            if (isRemoved)
            {
                this.players.RemoveAt(index);
                OpenPositions++;
            }

            return isRemoved;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            for (int i = 0; i < Players.Count; i++)
            {
                if (this.players[i].Position == position)
                {
                    this.players.RemoveAt(i);
                    count++;
                }
            }

            OpenPositions += count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player in Players)
            {
                if(player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> output = new List<Player>();
            foreach (var player in Players)
            {
                if(player.Games >= games)
                {
                    output.Add(player);
                }
            }

            return output;
        }

        public string Report()
        {
            StringBuilder oupput = new StringBuilder();

            oupput.AppendLine($"Active players competing for Team {Name} from Group {Group}:");
            foreach (var player in Players)
            {
                if(player.Retired != true)
                {
                    oupput.AppendLine(player.ToString());
                }
            }

            return oupput.ToString().TrimEnd();
        }
    }
}
