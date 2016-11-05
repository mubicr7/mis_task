using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows;

namespace DWH
{

    










    class DBConnection
    {

        public string name1 { get; set; }
        public string cnic1 { get; set; }
        public string number1 { get; set; }
        public string org1 { get; set; }


        List<DBConnection> datab = new List<DBConnection>();

        public MySqlConnection get_Connection()
        {

            MySqlConnection dbconnect = new MySqlConnection("Server=localhost; Port=3307; Database=dwh; Uid=root; Pwd=; pooling=true");
            return dbconnect;
        }



        public DBConnection(string a,string b,string c,string d)
        {

            name1 = a;
            cnic1 = b;
            number1 = c;
            org1 = d;

        }

        public DBConnection()
        {

        }



        public bool add_user(String query, MySqlConnection dbcon)
        {
            bool status = false;
            dbcon.Open();

            string sql = query;

            using (dbcon)
            {

                MySqlCommand command = new MySqlCommand(sql, dbcon);




               

                command.ExecuteNonQuery();

                status = true;

            }




            return status;


        }






        /* Select query */


        public List<DBConnection> select_user(String query, MySqlConnection dbcon)
        {
            string name = "";
            string cnic = "";
            string number = "";
            string org = "";

            bool status = false;
            dbcon.Open();


            DBConnection db = new DBConnection();
            
            String sql = query;
            using (dbcon)
            {
                MySqlCommand command = new MySqlCommand(sql, dbcon);


                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                         name = (String)reader["name"];
                         cnic = (string)reader["cnic"];
                       
                        number = (string)reader["number"];
                       
                        org = (string)reader["organization"];



                        db.name1 = name;
                        db.cnic1 = cnic;
                        db.number1 = number;
                        db.org1 = org;


                        datab.Add(new DBConnection(db.name1,db.cnic1,db.number1,db.org1));
                        
                        
                        status = true;
                        
                        
                    }
                }
            }

            return datab;
        }







    }
}
