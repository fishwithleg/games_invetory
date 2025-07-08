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
                                    deletegames();


                                    break;
                                case "3":
                                    insertnewgames();

                                    break;
                                case "2":
                                    updategames();

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
                                                    Console.Clear();
                                                    Console.WriteLine("[heres the list]");
                                                    Console.WriteLine("--------------");
                                                    List<Acsseorys> AcsseorysLL = storemanager.GetEveryAcsseorys();
                                                    view.DisplayAccsseorey(AcsseorysLL);
                                                    Console.WriteLine("--------------");
                                                   


                                                }

                                                break;
                                            case "4":
                                                deleteacsseorys();


                                                break;
                                            case "3":
                                                insertnewacsseorys();

                                                break;
                                            case "2":
                                                updateacsseorys();

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
            } while (!choice.Equals("loop")); Console.Clear();


        }


        
        // console swtich
        public static void updateconsole()
        {
            // uses the id of the console table
            view.displaymessage("[enter the console id to update it]\n [how to use]\n---------------------------------\n[1.use the id of the console not the name]\n---------------------------------\n");
            view.displaymessage("[enter new console id] ");
            int consoleId = view.Getintinput1();
            view.displaymessage("[enter new console name] ");
            string consoleName = view.getinput(); 
            int rowaffected = storemanager.updateconsole(consoleId,consoleName);
            view.displaymessage($"rows affected");
        }

        public static void insertnewconsole()
        {
            view.displaymessage("[enter the console you want to add]\n------------------------------------\n");
            view.displaymessage("please entre a new console: ");
            string consoleName = view.getinput();
            view.displaymessage("please enter a new suppiler");
            string consoleSupplier = view.getinput();
            int consoleId = 0;
            Game console1 = new Game(consoleId,consoleName,consoleSupplier);
            int createId = storemanager.insertnewconsole(console1);
            view.displaymessage($"new console ineserted with ID: {consoleId}");
        }

        private static void deleteconsole()
        {
            // use the name of the table to delete
            view.displaymessage("[enter the console name to delete]\n [how to use]\n-----------------------------------------\n[1.be sure its in the table]\n[2.it cant be a id only the name of the console]\n------------------------------------------");
            string consoleName = view.getinput();
            int rowaffected = storemanager.deleteconsole(consoleName);
        }



        //game swtich
        public static void updategames()
        {
            
            view.displaymessage("[enter the games id to update it]\n [how to use]\n---------------------------------\n[1.use the id of the game not the name]\n---------------------------------\n");
            int GamesId = view.Getintinput1();
            view.displaymessage("[enter new games name] ");
            string GamesName = view.getinput();
            int rowaffected = storemanager.updategames(GamesId, GamesName);
            view.displaymessage($"rows affected");
        }

        public static void insertnewgames()
        {
            view.displaymessage("[enter the games you want to add]\n------------------------------------\n");
            view.displaymessage("[please entre a new games:] ");
            string GamesName = view.getinput();
            view.displaymessage("[please enter a new place of origin]");
            string GamesRegion = view.getinput();
            view.displaymessage("[what genre is the game]");
            string GamesGenre = view.getinput();
            view.displaymessage("[what games is compabiltable with what console]");
            string ConsolesForGamesName = view.getinput();
            int GamesId = 0;
            GameConsole console2 = new GameConsole(GamesName, GamesId, GamesRegion,GamesGenre,ConsolesForGamesName);
            int createId = storemanager.insertnewgames(console2);
            view.displaymessage($"new games ineserted with ID: {GamesId}");
        }

        private static void deletegames()
        {
            view.displaymessage("[enter the games name to delete]\n [how to use]\n-----------------------------------------\n[1.be sure its in the table]\n[2.it cant be a id only the name of the game]\n------------------------------------------");
            string GamesName = view.getinput();
            int rowaffected = storemanager.deletegame(GamesName);
        }



        //Acsseorys swtich
        public static void updateacsseorys()
        {
            
            view.displaymessage("[enter the acsseorys id to update it]\n [how to use] \n---------------------------------\n[1.use the id of the acsseorys not the name]\n---------------------------------\n");
            int AcsseorysId = view.Getintinput1();
            view.displaymessage("[enter new acsseorys name] ");
            string AcsseorysName = view.getinput();
            int rowaffected = storemanager.updateacsseorys(AcsseorysId, AcsseorysName);
            view.displaymessage($"rows affected");
        }


        public static void insertnewacsseorys()
        {
            view.displaymessage("[enter the acsseorys you want to add]\n------------------------------------\n");
            view.displaymessage("please entre a new acsseorys: ");
            string AcsseorysName = view.getinput();
            view.displaymessage("please enter a new suppiler");
            string AcsseorysSupplier = view.getinput();
            int AcsseorysId = 0;
            Acsseorys console1 = new Acsseorys(AcsseorysName, AcsseorysId, AcsseorysSupplier);
            int createId = storemanager.insertnewacsseorys(console1);
            view.displaymessage($"new acsseorys ineserted with ID: {AcsseorysId}");
        }

        
        private static void deleteacsseorys()
        {
            view.displaymessage("[enter the acsseorys name to delete]\n [how to use]\n-----------------------------------------\n[1.be sure its in the table]\n[2.it cant be a id only the name of the acsseorys]\n------------------------------------------");
            string AcsseorysName = view.getinput();
            int rowaffected = storemanager.deleteacsseorys(AcsseorysName);
        }



    }

    
 }


        


//List<gamese> consoleTR = storeragmanger.GetBrands();
//foreach (gamese conbose in consoleTR)
//{
//    Console.WriteLine($"{consoleTR.consoleid},{consoleTR.consoleiname}");

//}