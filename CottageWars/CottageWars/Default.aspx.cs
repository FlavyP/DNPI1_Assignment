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

        /*
         * When the page loads,and if the user is logged in, we make sure that first of all the building panel, where all the information is represented
         * is not visible. This will change with the correct information for each building when a certain button is pressed.
         * We also make a reference for the webservice and store the user's name to mention it to the service
         */

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

        /*
         * When this button is clicked, the first thing we are doing is to call the webservice sending the name of the user and the name of the building
         * We get the values as DataTable, then we extract the values for each column and set it using the set methods that are explained below.
         * Also, we make sure that only this building's fields are visible and the other's are not
         * This explanation applies to all the OnClick methods for the Info + NameOfBuilding.
         */

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


            buildingControl.Visible = true;
        }

        /*
         * As explained in the InfoWood_OnClick
         */

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

        /*
         * As explained in the InfoWood_OnClick
         */
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

        /*
         * As explained in the InfoWood_OnClick
         */
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

        /*
         * As explained in the InfoWood_OnClick
         */

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

        /*
         * As explained in the InfoWood_OnClick
         */

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
        /*
         * To be implemented
         */
        protected void TrainInfantry_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Infantry");
        }
        /*
         * To be implemented
         */

        protected void TrainGladitoare_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Gladiator");
        }

        /*
          * To be implemented
          */

        protected void TrainBrute_OnClick(object Source, EventArgs e)
        {
            displayPopUpMessage("Brute");
        }

        /*
         * Upgrading the wood's level
         */

        protected void UpgradeWood_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Wood_Id");
        }

        /*
         * Upgrading the iron's level
         */
        protected void UpgradeIron_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Iron_Id");
        }

        /*
         * Upgrading the clay's level
         */
        protected void UpgradeClay_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Clay_Id");
        }

        /*
         * Upgrading the townhall's level
         */
        protected void UpgradeTownhall_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Townhall_Id");
        }

        /*
         * Upgrading the barrack's level
         */
        protected void UpgradeBarracks_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Barrack_Id");
        }

        /*
         * Upgrading the storage's level
         */
        protected void UpgradeStorage_OnClick(object Source, EventArgs e)
        {
            webService.updateBuilding(username, "Storage_Id");
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

        /*
         * string title - the title of each building
         * Since there is only one panel title, we just change the name everytime we want to see more information for a certain building
         * 
         * 
         */

        public void setPanelTitle(string title)
        {
            HtmlGenericControl panelInfo = (HtmlGenericControl)LoggedInContext.FindControl("panelTitle") as HtmlGenericControl;
            panelInfo.InnerHtml = title;
        }
        /*
         * string compName - get's the component we want to change value
         * string value - the value we want to assign to the component
         * Has been used to set the values for each building. We are getting the information from the webservice and setting them using this method
         * 
         */

        public void setComponentValue(string compName, string value)
        {
            HtmlGenericControl htmlEl = (HtmlGenericControl)LoggedInContext.FindControl(compName) as HtmlGenericControl;
            htmlEl.InnerHtml = value;
        }
        /*
         * string compName - get's the component we want to change visibility's name
         * bool state - true means we want to make it visible, false means we want to make it unvisible
         * This method has been used to show the information for each building while hiding the information for the other buildings
         * Since the field for a Townhall are different from the fields for the Barracks, we had to make a method that was making certain stuff
         * visible or invisible, to display it nicely and for the change to be done easier
         */

        public void setComponentVisibility(string compName, bool state)
        {
            HtmlGenericControl htmlEl = (HtmlGenericControl)LoggedInContext.FindControl(compName) as HtmlGenericControl;
            htmlEl.Visible = state;
        }

        /*
         * string compName - get's the component we want to change visibility name
         * bool state - true means we want to make it visible, false means we want to make it unvisible
         * This method is mostly use when we press a button to get wood information, we only want to show the "Upgade wood" button
         */

        public void setButtonVisibility(string compName, bool state)
        {
            Button htmlEl = (Button)LoggedInContext.FindControl(compName) as Button;
            htmlEl.Visible = state;
        }
    }
}