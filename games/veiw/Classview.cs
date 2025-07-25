﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamese.repo;
using games.something;

//consoleR = console row
//gameI = nothing

namespace games.veiw
{
    internal class Classview
    {
        public string displaymenu()
        {
            
            Console.WriteLine("[welcome to console inventory]" +
                              "\n------------------------------");
            Console.WriteLine("meun: ");
            Console.WriteLine("1. [view all reconds in console]");
            Console.WriteLine("2. [update consoles name]");
            Console.WriteLine("3. [insert new console]");
            Console.WriteLine("4. [delete console]");
            Console.WriteLine("5. [next]");
            Console.WriteLine("6. [clear current opration]" +
                              "\n------------------------------");
            Console.WriteLine("[select the opition]" +
                              "\n------------------------------");

            return Console.ReadLine();
            

            
        }

        public string DisplayGameMenu()
        {
            
            Console.WriteLine("[games inventory]" +
                              "\n--------------------------------");
            Console.WriteLine("meun: ");
                Console.WriteLine("1. [view all reconds in games]");
                Console.WriteLine("2. [update games name]");
                Console.WriteLine("3. [insert new games]");
                Console.WriteLine("4. [delete games]");
                Console.WriteLine("5. [next]");
                Console.WriteLine("6. [back]" +
                                  "\n----------------------------");
                Console.WriteLine("[select the opition]" +
                                  "\n----------------------------");

            return Console.ReadLine();
        }

        public string DisplayAccsseorey()
        {

            Console.WriteLine("[console Accsseorey inventory]" +
                              "\n----------------------------");
            Console.WriteLine("meun: ");
            Console.WriteLine("1. [view all reconds in peripheral]");
            Console.WriteLine("2. [update peripheral name]");
            Console.WriteLine("3. [insert new peripheral]");
            Console.WriteLine("4. [delete peripheral]");
            Console.WriteLine("5. [back]" +
                              "\n----------------------------");
            Console.WriteLine("[select the opition]" +
                              "\n----------------------------");

            return Console.ReadLine();
        }


        public string Displayreport()
        {

            Console.WriteLine("[console report veiw]" +
                              "\n-------------------");
            Console.WriteLine("meun: ");
            Console.WriteLine("[1. view the report]" +
                              "\n-------------------");

            return Console.ReadLine();
        }


        //console table
        public void displayconsole(List<Game> consoleRL)
        {
            foreach (Game consoleR in consoleRL)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"[{consoleR.console_id}] [{consoleR.console_name},{consoleR.console_supplier}]");
                Console.WriteLine("------------------------------------------");
            }


        }

        public string getinput()
        {
            return Console.ReadLine();
            Console.Clear();




        }

        public void displaymessage(string message)
        {
            Console.WriteLine(message);

        }

        public int Getintinput1()
        {
            return int.Parse(Console.ReadLine());        
        }






        //games table
        public void displaygames(List<GameConsole> GameIL)
        {
            foreach (GameConsole gameI in GameIL)
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine($"[{gameI.games_id}] [{gameI.games_name},{gameI.games_region},{gameI.games_genre},{gameI.consoles_name}]");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
            }


        }

        //Accsseorey table
        public void DisplayAccsseorey(List<Acsseorys> AcsseorysLL)
        {
            foreach (Acsseorys AcsseorysL in AcsseorysLL)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"[{AcsseorysL.peripheral_id}] [{AcsseorysL.peripheral_name},{AcsseorysL.peripheral_supplier}] ");
                Console.WriteLine("------------------------------------------");
            }


        }
    }
}
