using gamese.repo;
using games.something;
using games.veiw;
using Microsoft.Identity.Client;
using System;

namespace games
{
    public class Program
    {
        private static StoreManager storemanager;
        private static Classview view;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello there");
            string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=console;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storemanager = new StoreManager(connectionstring);
            view = new Classview();
            string choice; 
            do
            { 
              choice = view.displaymenu();
                Console.Clear();




                switch (choice)
            {
                case "1":
                    {
                            Console.WriteLine("[heres the list]");
                            Console.WriteLine("--------------");
                        List<Game> consoleRL = storemanager.GetEveryconsole();
                        view.displayconsole(consoleRL);
                            Console.WriteLine("--------------");
                        

                    }

                    break;
                case "4":
                    deleteconsole();
                   

                    break;
                case "3":
                    insertnewconsole();

                    break;
                case "2":
                    updateconsole();

                        break;
                    case "6":
                        view.displaymenu();

                   break;   
                case "5":
                        
                        Console.Clear();
                        {
                            string choice2;
                            choice2 = view.DisplayGameMenu();
                            switch (choice2)


                            {
                                case "1":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("[heres the list]");
                                        Console.WriteLine("--------------");
                                        List<GameConsole> GameIL = storemanager.GetEveryGame();
                                        view.displaygames(GameIL);
                                        Console.WriteLine("--------------");

                                    }

                                    break;
                                case "4":
                                    //deleteconsole();


                                    break;
                                case "3":
                                    //insertnewconsole();

                                    break;
                                case "2":
                                    //updateconsole();

                                    break;
                                    case "6":
                                    Console.Clear();
                                    


                                    break;
                                case "5":
                                    Console.Clear();
                                    {

                                        string choice3 = view.DisplayAccsseorey();
                                        switch (choice3)
                                        {
                                            case "1":
                                                {

                                                    //List<Game> consoleRL = storemanager.GetEveryconsole();
                                                    //view.displayconsole(consoleRL);
                                                    //Console.Clear();

                                                }

                                                break;
                                            case "4":
                                                //deleteconsole();


                                                break;
                                            case "3":
                                                //insertnewconsole();

                                                break;
                                            case "2":
                                                //updateconsole();

                                                break;
                                            case "5":
                                                Console.Clear();
                                                choice2.Equals("5");

                                                break;
                                        }
                                        
                                      
                                    }
                                    break;
                            }

                        }
                    
                    


                    break;
                case "loop":
                        
                        //exit = true;
                        storemanager.closeconncetion();
                        
                        break;


                    
                default:
                    Console.WriteLine("invalid choice please try again");
                    break;
   

             }
            } while (!choice.Equals("loop"));


        }


        

        public static void updateconsole()
        {

            view.displaymessage("enter the new console name");
            int consoleId = view.Getintinput1();
            view.displaymessage("enter new brand name: ");
            string consoleName = view.getinput();
            int rowaffected = storemanager.updateconsole(consoleId, consoleName);
            view.displaymessage($"rows affected");





        }

        public static void insertnewconsole()
        {
            view.displaymessage("please entre a new console: ");
            string consoleName = view.getinput();
            int consoleId = 0;
            Game console1 = new Game(consoleId, consoleName);
            int createId = storemanager.insertnewconsole(console1);
            view.displaymessage($"new console ineserted with ID: {consoleId}");



        }

        private static void deleteconsole()
        {
            view.displaymessage("enter the brand name to delete: ");
            string consoleName = view.getinput();
            int rowaffected = storemanager.deleteconsole(consoleName);
        }




        




    }

    
 }


        


//List<gamese> consoleTR = storeragmanger.GetBrands();
//foreach (gamese conbose in consoleTR)
//{
//    Console.WriteLine($"{consoleTR.consoleid},{consoleTR.consoleiname}");

//}