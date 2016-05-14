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
    public partial class Login : System.Web.UI.Page
    {
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string command = "SELECT COUNT(*) from Users where Username like '" + nameText.Text + "' AND Password like '" + passwordText.Text + "';";
                cmd = new SqlCommand(command, conn);
                int userCount = (int)cmd.ExecuteScalar();
                if (userCount > 0)
                {
                    displayPopUpMessage("Logged in");
                    //User logs in, redirect to main page or smth
                }
                else
                {
                    Response.Redirect("Register.aspx");
                    //display message, redirect to register or smth
                }
                conn.Close();
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