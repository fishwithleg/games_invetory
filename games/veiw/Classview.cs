using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamese.repo;
using games.something;

namespace games.veiw
{
    internal class Classview
    {
        public string displaymenu()
        {
            Console.WriteLine("welcome to console inventory");
            Console.WriteLine("meun: ");
            Console.WriteLine("1. view all reconds in console");
            Console.WriteLine("2. update consoles name by console_id");
            Console.WriteLine("3. insert new console");
            Console.WriteLine("4. delete console by console_name");
            Console.WriteLine("select the opition");

            return Console.ReadLine();

        }

        public void displayconsole(List<game> consoleTR)
        {
            foreach (game consoleT in consoleTR)
            {
                Console.WriteLine($"{consoleT.console_id},{consoleT.console_name}");

            }


        }

        public string getinput()
        {
            return Console.ReadLine();




        }

        public void displaymessage(string message)
        {
            Console.WriteLine(message);

        }

        public int Getintinput1()
        {

            return int.Parse(Console.ReadLine());        
        }

    }
}
