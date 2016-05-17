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
            conn.Open();
            // string command = "SELECT COUNT(*) from Users where Username like '" + nameText.Text + "' AND Password like '" + passwordText.Text + "';";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Label  woodCurrentLabel = (Label)ResourceView.FindControl("woodCurrentLabel") as Label;
                Label clayCurrentLabel = (Label)ResourceView.FindControl("clayCurrentLabel") as Label;
                Label ironCurrentLabel = (Label)ResourceView.FindControl("ironCurrentLabel") as Label;
                Label infantryCurrentLabel = (Label)ResourceView.FindControl("infantryCurrentLabel") as Label;
                Label bruteCurrentLabel = (Label)ResourceView.FindControl("bruteCurrentLabel") as Label;
                Label gladiatorCurrentLabel = (Label)ResourceView.FindControl("gladiatorCurrentLabel") as Label;

                woodCurrentLabel.Text = "Insert something here, Flavy.";
                clayCurrentLabel.Text = "1";
                ironCurrentLabel.Text = "2";
                infantryCurrentLabel.Text = "3";
                bruteCurrentLabel.Text = "4";
                gladiatorCurrentLabel.Text = "5";

            }

        }
    }
}