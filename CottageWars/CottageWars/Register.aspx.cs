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

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /*
         * OnClick button for the submit, when the user has already inputed the values
         * A service variable is created that checks if a user with the inputed email address already exists in the database
         * If the service returns true, it means there is a user with that email and we just pop-up a message saying this
         * If there is no user with that e-mail address, we call the service to register it in the database and display a message
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
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * A method that is just building a javascript method to display the inputed message as an alert
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