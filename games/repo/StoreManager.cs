﻿using System;
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
                        string GamesRegion = "games_region".ToString();
                        string GamesGenre = "games_genre".ToString();
                        GameIL.Add(new GameConsole(GamesName, GamesId, GamesRegion, GamesGenre));
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
           using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name) values (@consolename); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@consolename", consoleName);
                cmd.Parameters.AddWithValue("@consolename", consoleId);
                return cmd.ExecuteNonQuery();
            }


        }

            public int insertnewconsole(Game Consoleptemp)
            {
                using (SqlCommand cmd = new SqlCommand("insert into product.console (console_name,console_supplier) values (@consolename,@consolesuppiler); select scope_identity();", conn))
                {
                //unable to fix the problem
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

       

        //games opatiton

        public int updategames(int GamesId, string GamesName)
        {
            using (SqlCommand cmd = new SqlCommand("insert into product.games (games_name) values (@gamesname); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@gamesname", GamesName);
                cmd.Parameters.AddWithValue("@gamesname", GamesId);
                return cmd.ExecuteNonQuery();
            }


        }

        public int insertnewgames(GameConsole gamestemp)
        {
            using (SqlCommand cmd = new SqlCommand("insert into product.games (games_name,games_region,games_genre) values (@gamesname,@GamesRegion,@gamesgenre); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@consolename", gamestemp.games_name);
                cmd.Parameters.AddWithValue("@consolesupplier", gamestemp.games_region);
                cmd.Parameters.AddWithValue("@gamesgenre", gamestemp.games_genre);
                return Convert.ToInt32(cmd.ExecuteScalar);
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
        public int updateacsseorys(int GamesId, string GamesName)
        {
            using (SqlCommand cmd = new SqlCommand("insert into product.peripheral (peripheral_name) values (@AcsseorysName); select scope_identity();", conn))
            {
                //unable to fix the problem
                cmd.Parameters.AddWithValue("@AcsseorysName", GamesName);
                cmd.Parameters.AddWithValue("@AcsseorysName", GamesId);
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
                return Convert.ToInt32(cmd.ExecuteScalar);
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
