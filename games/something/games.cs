using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace games.something
{
    public class game
    {
        public string console_name { get; set; }
        public int console_id { get; set; }


        public game(int consoleId, string consoleName)
        {

            console_id = consoleId;
            console_name = consoleName;

        }

        
    }
}
