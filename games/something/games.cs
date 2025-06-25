using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace games.something
{
    public class Game
    {
        public string console_name { get; set; }
        public int console_id { get; set; }

        public string console_supplier { get; set; }

        public Game(int consoleId, string consoleName, string consoleSupplier)
        {

            console_id = consoleId;
            console_name = consoleName;
            console_supplier = consoleSupplier;
        }

        
    }
}
