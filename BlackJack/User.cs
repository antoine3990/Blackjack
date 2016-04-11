using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class User : Player
    {
        public string name { get; private set; }

        public User(string name, Cards deck, int nbCards) : base(deck, nbCards)
        {
            this.name = name;   //Affecte le nom du joueur
        }

        public void addToLog(string text)
        {
            log.Add(name.ToUpper() + ": " + text); //Affiche le nom du joueur dans la console
        }
    }
}
