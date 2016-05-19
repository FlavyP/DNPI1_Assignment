using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace CottageWars
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private string user;

        protected void Page_Load(object sender, EventArgs e)
        {
           loadResources();
        }
        /*
         * The first step of this method is to check if the user is logged in.
         * After this, we get the user's name and we make a reference to the webservice
         * We then call the GetResources method passing along the user's name
         * Everything is then returned in a short array, but to make it more easier, we are first of all saving it as a var, and the using the ToArray
         * method, we are making everything as a Int16 array
         * From there one we just make a reference for each label, all 3 resources and troops
         * We set the values from the webservices to the labels
         * We then continue and call the getUnits method from the webservice by passing along the user's name and we repeat the above steps
         * In the end we update the labels for the troops with the values from the service
         */

        private void loadResources()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                user = HttpContext.Current.User.Identity.Name;
                DatabaseServiceReference.DatabaseManagerServiceSoapClient service = new DatabaseServiceReference.DatabaseManagerServiceSoapClient();
                var values = service.getResources(user);
                Int16[] arrayValues = values.ToArray();
                Label  woodCurrentLabel = (Label)ResourceView.FindControl("woodCurrentLabel") as Label;
                Label clayCurrentLabel = (Label)ResourceView.FindControl("clayCurrentLabel") as Label;
                Label ironCurrentLabel = (Label)ResourceView.FindControl("ironCurrentLabel") as Label;
                Label infantryCurrentLabel = (Label)ResourceView.FindControl("infantryCurrentLabel") as Label;
                Label bruteCurrentLabel = (Label)ResourceView.FindControl("bruteCurrentLabel") as Label;
                Label gladiatorCurrentLabel = (Label)ResourceView.FindControl("gladiatorCurrentLabel") as Label;

                clayCurrentLabel.Text = "" + arrayValues[0];
                woodCurrentLabel.Text = "" + arrayValues[1];
                ironCurrentLabel.Text = "" + arrayValues[2];
                gladiatorCurrentLabel.Text = "" + user;

                values = service.getUnits(user);
                arrayValues = values.ToArray();
                bruteCurrentLabel.Text = "" + arrayValues[0];
                infantryCurrentLabel.Text = "" + arrayValues[1];
                gladiatorCurrentLabel.Text = "" + arrayValues[2];

            }

        }
    }
}