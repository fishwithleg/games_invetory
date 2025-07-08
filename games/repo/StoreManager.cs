using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using games.something;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

//consoleRL = console row list
//GameIL = nothing
//AcsseorysLL = nothing

namespace gamese.repo
{
    public class StoreManager
    {
        private SqlConnection conn;

        public  StoreManager(string connectionstring)
        {
            try

            {

                conn = new SqlConnection(connectionstring);
                conn.Open();
                Console.WriteLine("connection succesful");

            }
            catch (SqlException e)
            {

                Console.WriteLine("conncetions not found \n");
                Console.WriteLine(e.Message);






            }

            catch (Exception ex)
            {

                Console.WriteLine("error found");
                Console.WriteLine(ex.Message);

            }
        }



        //connects to console
        public List<Game> GetEveryconsole()
        {
            List<Game> consoleRL = new List<Game>();
            string sqlstring = "select * from product.console";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))

            {
               
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int consoleId = Convert.ToInt32(reader["console_id"]);
                        string consoleName = reader["console_name"].ToString();
                        string consoleSupplier = "console_suppiler".ToString();
                        consoleRL.Add(new Game(consoleId, consoleName, consoleSupplier));
                    }
                }

            }

            return consoleRL; 
        }

        //connects to the games

        public List<GameConsole> GetEveryGame()
        {
            List<GameConsole> GameIL = new List<GameConsole>();
            string sqlstrings = "select * from product.games";
            using (SqlCommand cmd = new SqlCommand(sqlstrings, conn))

            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int GamesId = Convert.ToInt32(reader["games_id"]);
                        string GamesName = reader["games_name"].ToString();
                        string GamesRegion = "games_region".ToString();
                        string GamesGenre = "games_genre".ToString();
                        string ConsolesForGamesName = "consoles_name".ToString();
                        GameIL.Add(new GameConsole(GamesName, GamesId, GamesRegion, GamesGenre, ConsolesForGamesName));
                    }
                }

            }

            return GameIL;
        }


        //connects to acsseorys
        public List<Acsseorys> GetEveryAcsseorys()
        {
            List<Acsseorys> AcsseorysLL = new List<Acsseorys>();
            string sqlstrings = "select * from product.peripheral";
            using (SqlCommand cmd = new SqlCommand(sqlstrings, conn))

            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int AcsseorysId = Convert.ToInt32(reader["peripheral_id"]);
                        string AcsseorysName = reader["peripheral_name"].ToString();
                        string AcsseorysSupplier = "AcsseorysSupplier".ToString();
                        AcsseorysLL.Add(new Acsseorys(AcsseorysName, AcsseorysId, AcsseorysSupplier));
                    }
                }

            }

            return AcsseorysLL;
        }



        //console optiation

        public int updateconsole(int consoleId, string consoleName)
        {
            using (SqlCommand cmd = new SqlCommand($"update product.console set console_name = @consolename where console_id = @consoleid", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@consolename", consoleName);
                cmd.Parameters.AddWithValue("@consoleid", consoleId);
                return cmd.ExecuteNonQuery();
            }


        }

            public int insertnewconsole(Game Consoleptemp)
            {
                using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name,console_supplier) values (@consolename,@consolesuppile); select scope_identity();", conn))
                {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@consolename", Consoleptemp.console_name);
                cmd.Parameters.AddWithValue("@consolesuppile", Consoleptemp.console_supplier);
                return Convert.ToInt32(cmd.ExecuteScalar());
                Console.ReadLine();
            }        
            }

        public int deleteconsole(string consoleName)
        {
            using(SqlCommand cmd = new SqlCommand("delete from product.console where console_name = @consolename", conn))
            {
                //works
                cmd.Parameters.AddWithValue("@consolename", consoleName);
                return cmd.ExecuteNonQuery();
            
            }
        }

       

        //games opatiton

        public int updategames(int GamesId, string GamesName)
        {
            using (SqlCommand cmd = new SqlCommand($"update product.games set games_name = @gamesname where games_id = @gamesid", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@gamesname", GamesName);
                cmd.Parameters.AddWithValue("@gamesid", GamesId);
                return cmd.ExecuteNonQuery();
            }


        }

        public int insertnewgames(GameConsole gametemp)
        {
            using (SqlCommand cmd = new SqlCommand("insert into product.games (games_name,games_region,games_genre,consoles_name) values (@gamesname,@gamesregion,@gamesgenre,@gamesfakeshare); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@gamesname", gametemp.games_name);
                cmd.Parameters.AddWithValue("@gamesregion", gametemp.games_region);
                cmd.Parameters.AddWithValue("@gamesgenre", gametemp.games_genre);
                cmd.Parameters.AddWithValue("gamesfakeshare", gametemp.consoles_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
                Console.ReadLine();
                
            }
        }

        public int deletegame(string GamesName)
        {
            using (SqlCommand cmd = new SqlCommand("delete from product.games where games_name = @consolename", conn))
            {
                //works
                cmd.Parameters.AddWithValue("@GamesName", GamesName);
                return cmd.ExecuteNonQuery();

            }
        }



        //Acsseorys opition
        public int updateacsseorys(int AcsseorysId, string AcsseorysName)
        {
            using (SqlCommand cmd = new SqlCommand($"update product.peripheral set peripheral_name = @AcsseorysName where peripheral_id = @Acsseorysid", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@AcsseorysName", AcsseorysName);
                cmd.Parameters.AddWithValue("@Acsseorysid", AcsseorysId);
                return cmd.ExecuteNonQuery();
            }


        }

        public int insertnewacsseorys(Acsseorys peripheraltemp)
        {
            using (SqlCommand cmd = new SqlCommand("insert into product.peripheral(peripheral_name,peripheral_supplier) values (@AcsseorysName,@AcsseorysSupplier); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@AcsseorysName", peripheraltemp.peripheral_name);
                cmd.Parameters.AddWithValue("@AcsseorysSupplier", peripheraltemp.peripheral_supplier);
                return Convert.ToInt32(cmd.ExecuteScalar());
                Console.ReadLine();  
            }
        }

        public int deleteacsseorys(string AcsseorysName)
        {
            using (SqlCommand cmd = new SqlCommand("delete from product.peripheral where peripheral_name = (@AcsseorysName), conn"))
            {
                //works
                cmd.Parameters.AddWithValue("@AcsseorysName", AcsseorysName);
                return cmd.ExecuteNonQuery();

            }
        }

        public void closeconncetion()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("connection closed");
            
            
            }


        }





    }

    }
