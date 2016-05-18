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
        [WebMethod]
        public Int16[] getResources(string Username)
        {
            Int16[] buffer = new Int16[3];
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
             command = "Select clayAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[0] = (Int16)cmd.ExecuteScalar();
            command = "Select woodAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[1] = (Int16)cmd.ExecuteScalar();
            command = "Select ironAmount FROM Buildings where id ='" + count + "'";
            cmd = new SqlCommand(command, conn);
            buffer[2] = (Int16)cmd.ExecuteScalar();
            conn.Close();
            return buffer;
        }
        [WebMethod]
        public DataTable getBuilding(string Username, string building)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DataTable dt = new DataTable();
            Int16[] buffer = new Int16[3];
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + Username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select " + building + " from Buildings where id='" + count + "'";
            count = (Int32)cmd.ExecuteScalar();
            switch (building)
            {
                case "Barrack_Id":
                    command = "Select * From Barracks where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;

                case "Clay_Id":
                    command = "Select * From Clays where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;

                case "Wood_Id":
                    command = "Select * From Woods where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;

                case "Iron_Id":
                    command = "Select * From Irons where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;

                case "Storage_Id":
                    command = "Select * From Storages where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;
                case "Townhall_Id":
                    command = "Select * From Townhalls where id='" + count + "'";
                    cmd = new SqlCommand(command, conn);
                    DA.SelectCommand = cmd;
                    DA.Fill(dt);
                    return dt;
                default:
                    return null;

            }

        }
        [WebMethod]
        public bool updateBuilding(string username, string building)
        {
            conn.Open();
            String command = "Select Building_Id FROM Users where Username ='" + username + "'";
            cmd = new SqlCommand(command, conn);
            Int32 count = (Int32)cmd.ExecuteScalar();
            command = "Select " + building + " from Buildings where id='" + count + "'";
            count = (Int32)cmd.ExecuteScalar();
            Int32 next = count + 1;
            switch (building)
            {
                case "Barrack_Id":
                    command = "Select cost From Barracks where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;

                case "Clay_Id":
                    command = "Select cost From Clays where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;

                case "Wood_Id":
                    command = "Select cost From Woods where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;

                case "Iron_Id":
                    command = "Select cost From Irons where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;

                case "Storage_Id":
                    command = "Select cost From Storages where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;
                case "Townhall_Id":
                    command = "Select cost From Townhalls where id='" + next + "'";
                    cmd = new SqlCommand(command, conn);
                    next = (Int32)cmd.ExecuteScalar();
                    break;
                default:
                    break; 
            }
            var webResources = this.getResources(username);
            Int16[] resources = webResources.ToArray();
            if (resources[0] >= next)
            {
                command = "Update Buildings SET " + building + " = " + building +" 1 WHERE Building_Id = " + count;
                conn.Close();
                return true;
            }

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

    }
}
