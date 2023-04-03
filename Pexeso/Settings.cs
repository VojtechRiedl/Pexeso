using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pexeso
{
    internal class Settings
    {
        private List<string> possibleNames = new List<string>{ "Miroslav", "Jan", "Kateřina", "Karolína", "Jiří", "Dominik", "Monika", "Marta", "Lenka", "Martin" };
        List<Player> players = new List<Player>();
        private int pieces;
        Random rd = new();

        public int Pieces { get => pieces; set => pieces = value; }
        internal List<Player> Players { get => players;}

        public Settings() {
            this.pieces = 2;
        }

        public void AddPlayer(string name)
        {
            players.Add(new Player(name));
        }

        public string GenerateName()
        {
            if(possibleNames.Count == 0)
            {
                return "Anonym";
            }

            string name = possibleNames[rd.Next(0, possibleNames.Count)];
            possibleNames.Remove(name);
            return name;
            
        }
    }
}
