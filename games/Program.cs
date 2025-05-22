using gamese.repo;
using games.something;
using games.veiw;
using Microsoft.Identity.Client;

namespace games
{
    public class Program
    {
        private static storeragmanger StoragManger;
        private static Classview view;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionstring = "Data Source=(localdb)\\ProjectModels;Initial Catalog=colonse;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            new storeragmanger(connectionstring);
            view = new Classview();
            string choice = view.displaymenu();


            switch (choice)
            {
                case "1":
                    {

                        List<game> consoleTR = storeragmanger.GetEveryconsole();
                        view.displayconsole(consoleTR);

                    }

                    break;
                case "2":
                    updateconsoleid();

                    break;
                case "3":
                    insertnewconsole();

                    break;
                case "4":
                    updateconsolename();


                    break;
                case "5":
                    exit = true;
                    break;


                    break;
                default:
                    Console.WriteLine("invalid choice please try again");
                    break;


            }
        
        }




        public static void updateconsolename()
        {

            view.displaymessage("enter the new console name");
            int consoleId = view.Getintinput1();
            view.displaymessage("enter new brand name: ");
            string consoleName = view.getinput();
            int rowaffected = storeragmanger.updateconsolename(consoleId, consoleName);
            view.displaymessage($"rows affected");





        }

        public static void insertnewconsole()
        {
            view.displaymessage("please entre a new console: ");
            string consoleName = view.getinput();
            int consoleId = 0;
            game console1 = new game(consoleId, consoleName);
            int createId = storeragmanger.insertnewconsole(console1);
            view.displaymessage($"new console ineserted with ID: {consoleId}");



        }











    }
 }

//List<gamese> consoleTR = storeragmanger.GetBrands();
//foreach (gamese conbose in consoleTR)
//{
//    Console.WriteLine($"{consoleTR.consoleid},{consoleTR.consoleiname}");

//}