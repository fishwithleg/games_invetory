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

        public string games_region {  get; set; }

        public string games_genre {  get; set; }

        public string consoles_name { get; set; }
        public GameConsole (string GamesName, int GamesId, string GamesRegion, string GamesGenre, string ConsolesForGamesName)
        {

            games_id = GamesId;

            games_name = GamesName;

            games_region = GamesRegion;

            games_genre = GamesGenre;

            consoles_name = ConsolesForGamesName;
        }
    }
}
