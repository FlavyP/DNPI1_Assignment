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
                Label  woodCurrent = (Label)ResourceView.FindControl("woodCurrent") as Label;
                woodCurrent.Text = "Insert something here, Flavy.";
                //HtmlGenericControl clayCurrent = (HtmlGenericControl)LoggedInContext.FindControl("clayCurrent") as HtmlGenericControl;
                //HtmlGenericControl ironCurrent = (HtmlGenericControl)LoggedInContext.FindControl("ironCurrent") as HtmlGenericControl;
            }

        }
    }
}