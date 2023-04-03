using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    internal class Player
    {
        private int score;
        private string name;

        public Player(string name)
        {
            this.score = 0;
            this.name = name;
        }

        public Player clone()
        {
            return new Player(this.name);
        }
        public string Name { get => name; }
        public int Score { get => score; set => score = value; }
    }

    
}
