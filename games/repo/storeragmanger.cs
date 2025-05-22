using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using games.something;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace gamese.repo
{
    public class storeragmanger
    {
        private SqlConnection conn;

        public storeragmanger(string connectionstring)
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




        public List<game> GetEveryconsole()
        {
            List<game> consoleTR = new List<game>();
            string sqlstring = "select * from production console";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))

            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int consoleid = Convert.ToInt32(reader["console_id"]);
                        string consolename = reader["console_name"].ToString();
                        consoleTR.Add(new game(consoleid, consolename));
                    }
                }

            }

            return consoleTR; 
        }








            public int insertnewconsole(game consoleptemp)
            {
            using (SqlCommand cmd = new SqlCommand("insert into game.console (console_name) values (console_id); select scope_identity();", conn))
            {
                cmd parameters.AddWithValue("@brandname", consoleptemp.consoleName);
                return Convert.ToInt32(cmd.ExecuteScalar);
            }
        
        
            }










        }

    }
