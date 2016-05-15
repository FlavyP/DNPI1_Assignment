using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CottageWars
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (HttpContext.Current.User.Identity.IsAuthenticated){ 
            HtmlControl control = (HtmlControl)LoggedInContext.FindControl("hex") as HtmlControl;
            //control.Visible = false;
            control.Attributes["data-original-title"] = "this is a dynamic tooltip";
            }
        }
    }
}