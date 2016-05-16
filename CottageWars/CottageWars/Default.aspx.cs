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
        private HtmlControl buildingControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                buildingControl = (HtmlControl)LoggedInContext.FindControl("buildingPanel") as HtmlControl;
                buildingControl.Visible = false;
                //control.Attributes["data-original-title"] = "this is a dynamic tooltip";
            }
        }

        protected void InfoWood_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Wood");
            setPanelTitle("Wood");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "100");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            buildingControl.Visible = true;
        }
        protected void InfoTownhall_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Townhall");
            setPanelTitle("Townhall");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "150");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", true);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            buildingControl.Visible = true;
        }
        protected void InfoBarracks_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Barracks");
            setPanelTitle("Barracks");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "200");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", false);
            setComponentVisibility("unitLimitGroup", true);
            setComponentVisibility("unitCostGroup", true);
            buildingControl.Visible = true;
        }
        protected void InfoIron_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Iron");
            setPanelTitle("Iron");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "250");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            buildingControl.Visible = true;
        }
        protected void InfoClay_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Clay");
            setPanelTitle("Clay");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "300");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            buildingControl.Visible = true;
        }
        protected void InfoStorage_OnClick(object Source, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            //displayPopUpMessage("Storage");
            setPanelTitle("Storage");
            setComponentValue("levelBadge", "1");
            setComponentValue("costBadge", "350");
            setComponentVisibility("maxResourceGroup", true);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", false);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            buildingControl.Visible = true;
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

        public void setPanelTitle(string title)
        {
            HtmlGenericControl panelInfo = (HtmlGenericControl)LoggedInContext.FindControl("panelTitle") as HtmlGenericControl;
            panelInfo.InnerHtml += " - " + title;
        }

        public void setComponentValue(string compName, string value)
        {
            HtmlGenericControl htmlEl = (HtmlGenericControl)LoggedInContext.FindControl(compName) as HtmlGenericControl;
            htmlEl.InnerHtml = value;
        }

        public void setComponentVisibility(string compName, bool state)
        {
            HtmlGenericControl htmlEl = (HtmlGenericControl)LoggedInContext.FindControl(compName) as HtmlGenericControl;
            htmlEl.Visible = state;
        }
    }
}