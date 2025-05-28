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
                cmd.Parameters.AddWithValue("@brandname", Consoleptemp.console_name);
                return Convert.ToInt32(cmd.ExecuteScalar);
                }
        
        
            }

        public int deleteconsole(string consoleName)
        {
            using(SqlCommand cmd = new SqlCommand("delete from product.console where console_name = @brandname", conn))
            {
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
