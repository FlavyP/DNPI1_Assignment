using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CottageWars
{
    public partial class p2w : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Check's if the fields are not empty and displaying the winning message
         */
        protected void PayToWin_Click1(object sender, EventArgs e)
        {
            TextBox ownerName = (TextBox)ResourceView.FindControl("ownerName");
            TextBox CreditCardNumber = (TextBox)ResourceView.FindControl("CreditCardNumber");
            TextBox VCSNumber = (TextBox)ResourceView.FindControl("VCSNumber");
            TextBox expirationDate = (TextBox)ResourceView.FindControl("expirationDate");

            if(ownerName.Text.Length != 0 && CreditCardNumber.Text.Length != 0 && VCSNumber.Text.Length != 0 && expirationDate.Text.Length != 0)
            {
                displayPopUpMessage("Now you win. Was it that hard, " + ownerName.Text + "?");
            }
            else
            {
                displayPopUpMessage("It's not that easy. Just complete the form.");
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