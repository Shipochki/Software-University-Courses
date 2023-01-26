using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Trainer
    {
        private string name;
        private int numOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;
            numOfBadges = 0;
            Pokemons = pokemons;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NumOfBadges
        {
            get { return numOfBadges; }
            set { numOfBadges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
            set { pokemons = value; }
        }

        public void Add(Trainer trainer)
        {
            trainer.Add(trainer);
        }
    }
}
