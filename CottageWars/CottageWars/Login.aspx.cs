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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
            //conn = new SqlConnection(connectionString);
        }
        /*
         * 
         * Using the webservices it checks if a user with this username and password exists in the database.If yes it redirects to the main page with a user status Logged in and user information loaded
         * 
         * 
         * 
         */

        protected void Button1_Click(object sender, EventArgs e)
        {
            DatabaseServiceReference.DatabaseManagerServiceSoapClient service = new DatabaseServiceReference.DatabaseManagerServiceSoapClient();

            if (service.checkForUserUP(nameText.Text, passwordText.Text))
            { 
                FormsAuthentication.RedirectFromLoginPage(nameText.Text, false);
            }
        }

    }

}