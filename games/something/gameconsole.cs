using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace games.something
{
    public class GameConsole
    {
        public string games_name {  get; set; }

        public int games_id { get; set; }

        public GameConsole (string GamesName, int GamesId)
        {

            games_id = GamesId;

            games_name = GamesName;

        }
    }
}
