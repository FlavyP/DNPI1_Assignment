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
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HtmlControl control = (HtmlControl)LoggedInContext.FindControl("woodH") as HtmlControl;
                //control.Attributes["data-original-title"] = "this is a dynamic tooltip";
                string btn = "<button runat=\"server\" class=\"btn btn-default btn-sm\" ID=\"moreInfoWood\" OnServerClick=\"InfoWood_OnClick\">More information</button";

                control.Attributes["data-content"] += btn;
            }
        }

        protected void InfoWood_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("hello");
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