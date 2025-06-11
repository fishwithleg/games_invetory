using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamese.repo;
using games.something;

//consoleR = console row

namespace games.veiw
{
    internal class Classview
    {
        public string displaymenu()
        {
            Console.WriteLine("welcome to console inventory");
            Console.WriteLine("meun: ");
            Console.WriteLine("1. view all reconds in console");
            Console.WriteLine("2. update consoles name");
            Console.WriteLine("3. insert new console");
            Console.WriteLine("4. delete console");
            Console.WriteLine("5. next");
            Console.WriteLine("6. exit");
            Console.WriteLine("select the opition");

            return Console.ReadLine();

        }

        public void displayconsole(List<Game> consoleRL)
        {
            foreach (Game consoleR in consoleRL)
            {
                Console.WriteLine($"{consoleR.console_id},{consoleR.console_name}");

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
