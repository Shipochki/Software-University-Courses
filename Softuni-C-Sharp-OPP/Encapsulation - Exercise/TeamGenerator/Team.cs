using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            int index = 0;
            bool isContainded = false;
            foreach (var currentPlayer in this.players)
            {
                if (currentPlayer.Name == player)
                {
                    isContainded = true;
                    break;
                }
                index++;
            }
            if (isContainded)
                this.players.RemoveAt(index);
            else
                throw new ArgumentException($"Player {player} is not in {Name} team.");
        }

        public int GetAverageStatOfTeam()
        {

            int stat = (int)Math.Round(this.players.Select(p => p.GetAverageStat()).Average());
            //if (players.count != 0)
            //{
            //    foreach (var player in this.players)
            //    {
            //        stat += (int)math.round(player.getaveragestat());
            //    }

            //    stat = stat / this.players.count;

            //}
            return stat;
        }
    }
}
