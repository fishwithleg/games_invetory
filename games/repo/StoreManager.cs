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
                        int consoleid = Convert.ToInt32(reader["console_id"]);
                        string consolename = reader["console_name"].ToString();
                        string consoleSupplier = "console_suppiler".ToString();
                        consoleRL.Add(new Game(consoleid, consolename, consoleSupplier));
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
                        GameIL.Add(new GameConsole(GamesName, GamesId));
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
                        AcsseorysLL.Add(new Acsseorys(AcsseorysName, AcsseorysId));
                    }
                }

            }

            return AcsseorysLL;
        }




        public int updateconsole(int consoleId, string consoleName)
        { 
           using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name) values (console_id); select scope_identity();", conn))
            {
                // problem here
                cmd.Parameters.AddWithValue("@brandname", consoleName);
                cmd.Parameters.AddWithValue("@brandname", consoleId);
                return cmd.ExecuteNonQuery();
            }


        }






            public int insertnewconsole(Game Consoleptemp)
            {
                using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name,console_supplier) values (@consolename,@consolesuppiler); select scope_identity();", conn))
                {
                //problem here
                cmd.Parameters.AddWithValue("@consolename", Consoleptemp.console_name);
                cmd.Parameters.AddWithValue("@consolesupplier", Consoleptemp.console_supplier);
                return Convert.ToInt32(cmd.ExecuteScalar);
                
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
