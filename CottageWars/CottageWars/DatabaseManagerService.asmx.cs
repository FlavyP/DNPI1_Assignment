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
         *It gets the Unit Id corresponding to the Username
         *It goes into table units and it adds the units to a buffer[] arryay.
         * It returns the buffer array.
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
         * First the method checks for the building_id with the correspoinding user, so it can access the correct row in Buildings table.
         * Then the method checks for last visited date in the Users table with the correct username
         * Then the method gets the current date.
         * It calculates the differeance between both dates in HOURS using compareandcontrats() method, see below. 
         * If the differance is more than one hour it gets the values for PPH from Clays table, PPH- Produce per hour.(Currently taking only from Clays because the production and cost is equal for all 3 resources).
         * It calculates the differance multiplied by production per hour.
         * Then it updates the last visited date and hour for the current one.
         * Then it gets the resources and stores them in a buffer[] array.
         * It adds the differance to the buffer[] and it Updates the resource table with the updated resources.
         * It returns the buffer[] array in the end.
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
         *Compares two dates and returns the diffrance in hours if it's more than one or it returns -1 if it's less.   
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
        /*First the method finds the Building id corresponding to the user to access the right Buildings row.
         * Then it finds the current level of the building in Buildings table.
         * Then it goes into the correct type of building table (Barracks, Towns and etc.) and it checks for the information for the current level.
         * it adds the information into a DataTable.
         * It returns the data table.
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
         * To be implemented.
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
