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
        private DatabaseServiceReference.DatabaseManagerServiceSoapClient webService;
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                buildingControl = (HtmlControl)LoggedInContext.FindControl("buildingPanel") as HtmlControl;
                buildingControl.Visible = false;
                webService = new DatabaseServiceReference.DatabaseManagerServiceSoapClient();
                username = HttpContext.Current.User.Identity.Name;
            }
        }

        protected void InfoWood_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Wood_Id");

            System.Data.DataRow rows = info.Rows[0];

            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("productionBadge", rows["PPH"].ToString());

            setPanelTitle("Wood");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            setComponentVisibility("trainTroopsGroup", false);

            setButtonVisibility("upgadeWoodBtn", true);
            setButtonVisibility("upgradeIronBtn", false);
            setButtonVisibility("upgradeClayBtn", false);
            setButtonVisibility("upgradeTownhallBtn", false);
            setButtonVisibility("upgrageBarracksBtn", false);
            setButtonVisibility("upgradeStorageBtn", false);

            /*foreach (System.Data.DataRow row in info.Rows)
            {
                string level = row["level"].ToString();
                displayPopUpMessage(level);
            }*/


            buildingControl.Visible = true;
        }
        protected void InfoTownhall_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Townhall_Id");

            System.Data.DataRow rows = info.Rows[0];

            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("productionBadge", rows["PPH"].ToString());
            setComponentValue("townPopulationBadge", rows["population"].ToString());

            setPanelTitle("Townhall");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", true);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            setComponentVisibility("trainTroopsGroup", false);

            setButtonVisibility("upgadeWoodBtn", false);
            setButtonVisibility("upgradeIronBtn", false);
            setButtonVisibility("upgradeClayBtn", false);
            setButtonVisibility("upgradeTownhallBtn", true);
            setButtonVisibility("upgrageBarracksBtn", false);
            setButtonVisibility("upgradeStorageBtn", false);

            buildingControl.Visible = true;
        }
        protected void InfoBarracks_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Barrack_Id");

            System.Data.DataRow rows = info.Rows[0];

            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("unitLimitBadge", rows["maxUnits"].ToString());
            setComponentValue("unitCostBadge", rows["unitCost"].ToString());

            setPanelTitle("Barracks");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", false);
            setComponentVisibility("unitLimitGroup", true);
            setComponentVisibility("unitCostGroup", true);

            setButtonVisibility("upgadeWoodBtn", false);
            setButtonVisibility("upgradeIronBtn", false);
            setButtonVisibility("upgradeClayBtn", false);
            setButtonVisibility("upgradeTownhallBtn", false);
            setButtonVisibility("upgrageBarracksBtn", true);
            setButtonVisibility("upgradeStorageBtn", false);
            buildingControl.Visible = true;
        }
        protected void InfoIron_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Iron_Id");

            System.Data.DataRow rows = info.Rows[0];
            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("productionBadge", rows["PPH"].ToString());

            setPanelTitle("Iron");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            setComponentVisibility("trainTroopsGroup", false);

            setButtonVisibility("upgadeWoodBtn", false);
            setButtonVisibility("upgradeIronBtn", true);
            setButtonVisibility("upgradeClayBtn", false);
            setButtonVisibility("upgradeTownhallBtn", false);
            setButtonVisibility("upgrageBarracksBtn", false);
            setButtonVisibility("upgradeStorageBtn", false);
            buildingControl.Visible = true;
        }
        protected void InfoClay_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Clay_Id");

            System.Data.DataRow rows = info.Rows[0];
            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("productionBadge", rows["PPH"].ToString());

            setPanelTitle("Clay");
            setComponentVisibility("maxResourceGroup", false);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", true);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            setComponentVisibility("trainTroopsGroup", false);

            setButtonVisibility("upgadeWoodBtn", false);
            setButtonVisibility("upgradeIronBtn", false);
            setButtonVisibility("upgradeClayBtn", true);
            setButtonVisibility("upgradeTownhallBtn", false);
            setButtonVisibility("upgrageBarracksBtn", false);
            setButtonVisibility("upgradeStorageBtn", false);
            buildingControl.Visible = true;
        }
        protected void InfoStorage_OnClick(object Source, EventArgs e)
        {
            System.Data.DataTable info = new System.Data.DataTable();
            info = webService.getBuilding(username, "Storage_Id");

            System.Data.DataRow rows = info.Rows[0];

            setComponentValue("levelBadge", rows["level"].ToString());
            setComponentValue("costBadge", rows["cost"].ToString());
            setComponentValue("maxResourceBadge", rows["maxResource"].ToString());

            setPanelTitle("Storage");

            setComponentVisibility("maxResourceGroup", true);
            setComponentVisibility("townPopulationGroup", false);
            setComponentVisibility("productionGroup", false);
            setComponentVisibility("unitLimitGroup", false);
            setComponentVisibility("unitCostGroup", false);
            setComponentVisibility("trainTroopsGroup", false);

            setButtonVisibility("upgadeWoodBtn", false);
            setButtonVisibility("upgradeIronBtn", false);
            setButtonVisibility("upgradeClayBtn", false);
            setButtonVisibility("upgradeTownhallBtn", false);
            setButtonVisibility("upgrageBarracksBtn", false);
            setButtonVisibility("upgradeStorageBtn", true);
            buildingControl.Visible = true;
        }

        protected void TrainInfantry_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Infantry");
        }

        protected void TrainGladitoare_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Gladiator");
        }

        protected void TrainBrute_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Brute");
        }

        protected void UpgradeWood_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Wood_Id");
        }

        protected void UpgradeIron_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Iron_Id");
        }

        protected void UpgradeClay_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Clay_Id");
        }

        protected void UpgradeTownhall_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Townhall_Id");
        }

        protected void UpgradeBarracks_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Barrack_Id");
        }

        protected void UpgradeStorage_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Storage_Id");
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
            panelInfo.InnerHtml = title;
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

        public void setButtonVisibility(string compName, bool state)
        {
            Button htmlEl = (Button)LoggedInContext.FindControl(compName) as Button;
            htmlEl.Visible = state;
        }
    }
}