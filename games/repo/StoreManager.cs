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
                        consoleRL.Add(new Game(consoleid, consolename));
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




        public int updateconsole(int consoleId, string consoleName)
        { 
           using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name) values (console_id); select scope_identity();", conn))
            {
                cmd.Parameters.AddWithValue("@brandname", consoleName);
                cmd.Parameters.AddWithValue("@brandname", consoleId);
                return cmd.ExecuteNonQuery();
            }


        }






            public int insertnewconsole(Game Consoleptemp)
            {
                using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name) values (console_id); select scope_identity();", conn))
                {
                //leads to a error
                cmd.Parameters.AddWithValue("@brandname", Consoleptemp.console_name);
                return Convert.ToInt32(cmd.ExecuteScalar);
                }
        
        
            }

        public int deleteconsole(string consoleName)
        {
            using(SqlCommand cmd = new SqlCommand("delete from product.console where console_name = @brandname", conn))
            {
                //problem
                cmd.Parameters.AddWithValue("@brandname", consoleName);
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
