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
            //connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            //conn = new SqlConnection(connectionString);
        }

        /*
         * 
         * 
         * 
         * 
         * 
         */

        protected void submitButton_Click1(object sender, EventArgs e)
        {
            try
            {
                DatabaseServiceReference.DatabaseManagerServiceSoapClient service = new DatabaseServiceReference.DatabaseManagerServiceSoapClient();
                if(service.checkForUserE(emailText.Text))
                {
                    displayPopUpMessage("User already exists.");
                }
                else
                {
                    service.registerUser(nameText.Text, passwordText.Text, emailText.Text);
                    displayPopUpMessage("User Registered.");

                    //displayPopUpMessage(count.ToString());


                    //cmd = new SqlCommand(command, conn);
                    //cmd.ExecuteNonQuery();
                    //write in db

                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * 
         * 
         */

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