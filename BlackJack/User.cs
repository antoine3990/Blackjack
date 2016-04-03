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

        public User(string name)
        {
            this.name = name;
        }

        public void addToLog(string text)
        {
            log.Add(name.ToUpper() + ": " + text);
        }
    }
}
