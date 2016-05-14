using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
                    //display user exists message
                }
                else
                {
                    command = "INSERT INTO Users (Username, Email, Password) VALUES (" + "'" + nameText.Text + "','" + emailText.Text + "','" + passwordText.Text + "')";
                    cmd = new SqlCommand(command, conn);
                    cmd.ExecuteNonQuery();
                    //write in db
                }
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}