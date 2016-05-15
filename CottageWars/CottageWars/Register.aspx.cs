using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace CottageWars
{
    public partial class Register : System.Web.UI.Page
    {
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }

        protected void submitButton_Click1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string command = "SELECT COUNT(*) from Users where Email like '" + emailText.Text + "';";
                cmd = new SqlCommand(command, conn);
                int userCount = (int)cmd.ExecuteScalar();
                if(userCount > 0)
                {
                    displayPopUpMessage("User already exists.");
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string checkCurrentAmount = "SELECT COUNT(Id) FROM Users";
    

                    cmd = new SqlCommand(checkCurrentAmount, conn);
                    Int32 count = (Int32)cmd.ExecuteScalar();
                    count++;

                    string buildUnits = "Insert INTO Units(Infatry, Gladiator, Brute) VALUES ('0','0','0')";
                    
                    string buildBuildings = "Insert INTO Buildings(clayAmount, woodAmount, ironAmount, Barrack_id, Clay_id, Iron_id, Wood_id, Storage_id, Townhall_id) VALUES ('100','100','100','1','1','1','1','1','1')";
                    command = "INSERT INTO Users (Username, Email, Password, LastVisited, Building_id, Unit_id ) VALUES (" + "'" + nameText.Text + "','" + emailText.Text + "','" + passwordText.Text + "','" + DateTime.Now.ToString() + "','" + count + "','" + count + "')";
                    
                    cmd = new SqlCommand(buildBuildings, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(buildUnits, conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    //displayPopUpMessage(count.ToString());


                    //cmd = new SqlCommand(command, conn);
                    //cmd.ExecuteNonQuery();
                    //write in db

                }
                conn.Close();
                Response.Redirect("Login.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void displayPopUpMessage(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}