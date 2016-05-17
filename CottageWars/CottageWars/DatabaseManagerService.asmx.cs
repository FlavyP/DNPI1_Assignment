using System;
using System.Collections.Generic;
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
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd;

        public DatabaseManagerService()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
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
        [WebMethod]
        public bool updateBuilding(string username, string building)
        {
            conn.Open();
            conn.Close();
            return false;
        }
        [WebMethod]
        public bool buildUnits(string username, int gladiator, int brute, int infatry)
        {
            conn.Open();
            conn.Close();
            return false;
        }
        [WebMethod]
        public bool getUnits(string Username)
        {
            conn.Open();
            conn.Close();
            return false;
        }
        [WebMethod]
        public int[] getResources(string Username)
        {
            int[] buffer = new int[3];
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            int count = (int)cmd.ExecuteScalar();
             command = "Select clayAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[0] = (int)cmd.ExecuteScalar();
            command = "Select woodAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[1] = (int)cmd.ExecuteScalar();
            command = "Select ironAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[2] = (int)cmd.ExecuteScalar();
            conn.Close();
            return buffer;
        }

    }
}
