using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace games.something
{
    internal class gameconsole
    {
        public char games_name {  get; set; }

        public int games_id { get; set; }

        public gameconsole (char ingamesname, int ingamesid)
        {

            games_id = ingamesid;

            games_name = ingamesname;

        }
    }
}
