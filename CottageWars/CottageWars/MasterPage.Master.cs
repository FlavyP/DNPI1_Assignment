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
        private string connectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private string user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CottageWarsDB;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                loadResources();
            }
        }
        private void loadResources()
        {
            // string command = "SELECT COUNT(*) from Users where Username like '" + nameText.Text + "' AND Password like '" + passwordText.Text + "';";
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