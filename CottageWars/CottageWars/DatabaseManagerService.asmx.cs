using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CottageWars
{
    /// <summary>
    /// Summary description for DatabaseManagerService
    /// </summary>
    [WebService(Namespace = "MySuperAwesomeService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DatabaseManagerService : System.Web.Services.WebService
    {
        /*
         * string connectionString - neccesarry for making the connection with the database;
         * SqlConnection conn - the connection, using it to run queries, open/close connection after each query.
         * SqlCommand cmd - The command formulated by the connection and a String statement.
         * 
         */

        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd;

        public DatabaseManagerService()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
        /*
         *   
         * 
         */

        [WebMethod]
        public bool checkForUserE(string userEmail)
        {
            conn.Open();
            string command = "SELECT COUNT(*) from Users where Email like '" + userEmail + "';";
            cmd = new SqlCommand(command, conn);
            int userCount = (int)cmd.ExecuteScalar();
            if (userCount > 0)
            {
                return true;
            }
            conn.Close();
            return false;
        }
        /*
         *   
         * 
         */
        [WebMethod]
        public bool checkForUserUP(string username, string password)
        {
            conn.Open();
            string command = "SELECT COUNT(*) from Users where Username like '" + username + "' AND Password like '" + password + "';";
            cmd = new SqlCommand(command, conn);
            int userCount = (int)cmd.ExecuteScalar();
            if (userCount > 0)
            {
                conn.Close();
                return true;
            }

            conn.Close();
            return false;

        }   


        /*
         *   
         * 
         */

        [WebMethod]
        public bool registerUser(string username, string password, string email)
        {
            conn.Open();
            string command;
            try
            {
                string checkCurrentAmount = "SELECT COUNT(Id) FROM Users";


                cmd = new SqlCommand(checkCurrentAmount, conn);
                Int32 count = (Int32)cmd.ExecuteScalar();
                count++;

                string buildUnits = "Insert INTO Units(Infatry, Gladiator, Brute) VALUES ('0','0','0')";

                string buildBuildings = "Insert INTO Buildings(clayAmount, woodAmount, ironAmount, Barrack_id, Clay_id, Iron_id, Wood_id, Storage_id, Townhall_id) VALUES ('100','100','100','1','1','1','1','1','1')";
                command = "INSERT INTO Users (Username, Email, Password, LastVisited, Building_id, Unit_id ) VALUES (" + "'" + username + "','" + email + "','" + password + "','" + DateTime.Now.ToString() + "','" + count + "','" + count + "')";

                cmd = new SqlCommand(buildBuildings, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(buildUnits, conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }catch(Exception e)
            {
                conn.Close();
                return false;

            }
        }
        /*
         *   
         * 
         */
        [WebMethod]
        public Int16[] getUnits(string Username)
        {
            Int16[] buffer = new Int16[3];
            conn.Open();
            String command = "Select Unit_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select Brute FROM Units where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[0] = (Int16)cmd.ExecuteScalar();
            command = "Select Infatry FROM Units where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[1] = (Int16)cmd.ExecuteScalar();
            command = "Select Gladiator FROM Units where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[2] = (Int16)cmd.ExecuteScalar();
            conn.Close();
            return buffer;
        }

        /*
         *   
         * 
         */

        [WebMethod]
        public Int16[] getResources(string Username)
        {
            Int16[] buffer = new Int16[3];
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select LastVisited From Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            string last = (string)cmd.ExecuteScalar();
            string current = DateTime.Now.ToString();
            double differance = compareandcontrast(current, last);
            int total = 0;
            if (differance != -1)
                
            {
                Console.Write(last + " " + current);
                command = "Select Clay_Id from Buildings where Id='" + count + "'";
                cmd = new SqlCommand(command, conn);
                int level = (int)cmd.ExecuteScalar();
                command = "Select PPH from Clays where id='" + level + "'";
                cmd = new SqlCommand(command, conn);
                Int16 PPH = (Int16)cmd.ExecuteScalar();
               total = (int)differance * PPH;
                command = "Update Users SET LastVisited ='" + DateTime.Now.ToString() + "' WHERE Username='" + Username +"'";
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();

            }
            command = "Select clayAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[0] = (Int16)cmd.ExecuteScalar();
            command = "Select woodAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[1] = (Int16)cmd.ExecuteScalar();
            command = "Select ironAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[2] = (Int16)cmd.ExecuteScalar();
            for(int i =0; i<3; i++)
            {
                buffer[i] +=(short) total;
            }
            command = "Update Buildings SET clayAmount=' " + buffer[0] + "' WHERE Id = " + count;
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            command = "Update Buildings SET woodAmount=' " + buffer[0] + "' WHERE Id = " + count;
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            command = "Update Buildings SET ironAmount= ' " + buffer[0] + "' WHERE Id = " + count;
            cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            return buffer;
        }

        /*
         *   
         * 
         */

        private double compareandcontrast(string current, string past)
        {
            if (DateTime.Parse(past) <= DateTime.Parse(current))

            {
                return (DateTime.Parse(current) - DateTime.Parse(past)).TotalHours;
                
            }
            return -1;

        }
        /*
         *   
         * 
         */

        [WebMethod]
        public DataTable getBuilding(string Username, string building)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable dt = new DataTable();
            dt.TableName = "MyTable";
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select " + building + " from Buildings where id='" + count + "'";
            cmd = new SqlCommand(command, conn);
            count = (Int32)cmd.ExecuteScalar();
            command = "Select Id From Barracks where id='" + count + "'";
            cmd = new SqlCommand(command, conn);
            count = (Int32)cmd.ExecuteScalar();
            
            switch (building)
            {
                case "Barrack_Id":
                    command = "Select * From Barracks where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;

                case "Clay_Id":
                    command = "Select * From Clays where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;

                case "Wood_Id":
                    command = "Select * From Woods where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;

                case "Iron_Id":
                    command = "Select * From Irons where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;

                case "Storage_Id":
                    command = "Select * From Storages where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;
                case "Townhall_Id":
                    command = "Select * From Townhalls where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    conn.Close();
                    return dt;
                default:
                    conn.Close();
                    return null;

            }

        }

        /*
         *   
         * 
         */

        [WebMethod]
        public bool updateBuilding(string username, string building)
        {
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select " + building + " from Buildings where id='" + count + "'";
           Int32 current = (Int32)cmd.ExecuteScalar();
            Int16 next = (Int16)count;
            switch (building)
            {
                case "Barrack_Id":
                    command = "Select cost From Barracks where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;

                case "Clay_Id":
                    command = "Select cost From Clays where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;

                case "Wood_Id":
                    command = "Select cost From Woods where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;

                case "Iron_Id":
                    command = "Select cost From Irons where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;

                case "Storage_Id":
                    command = "Select cost From Storages where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;
                case "Townhall_Id":
                    command = "Select cost From Townhalls where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int16)cmd.ExecuteScalar();
                    break;
                default:
                    break; 
            }
            conn.Close();
            var webResources = this.getResources(username);
            conn.Open();
            Int16[] resources = webResources.ToArray();
            if (resources[0] >= next)
            {
                command = "Update Buildings SET " + building + " = '" + (current + 1) +" ' WHERE Id = " + count;
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                resources[0] -= next;
                command = "Update Buildings SET clayAmount = '" + (resources[0]) + " ' WHERE Id = " + count;
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                command = "Update Buildings SET woodAmount = '" + (resources[0]) + " ' WHERE Id = " + count;
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                command = "Update Buildings SET ironAmount = '" + (resources[0]) + " ' WHERE Id = " + count;
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            conn.Close();
            return false;
        }

        /*
         *   
         * 
         */

        [WebMethod]
        public bool buildUnits(string username, int gladiator, int brute, int infatry)
        {
            conn.Open();
            conn.Close();
            return false;
        }

    }
}
