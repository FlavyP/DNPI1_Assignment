﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CottageWars.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="LoggedInContext" runat="server" ViewStateMode="Disabled">
    <LoggedInTemplate runat="server">
    <div id="divCenter" runat="server" class="divhead"></div>
    <div class="jumbotron" runat="server">
      <div class="board" runat="server">
          <div class="col-lg-6">
            <div class="hex-row" runat="server">
                <div class="hex" runat="server"><div class="left"></div><div runat="server" ID="woodH" data-toggle="popover" data-placement="left"  data-original-title="Wood" data-content="Wood is a very important resource for your town that will allow you to expand and build an army. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('woodBtn')[0].click()&quot;>More information</button>" class="middle wood-img"></div><div class="right"></div></div>
                <div class="hex even" runat="server"><div class="left"></div><div runat="server" id="townhallH" data-toggle="popover" data-placement="top" data-original-title="Townhall" data-content="The main building of your village, which dictates how many troups you can have. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('townhallBtn')[0].click()&quot;>More information</button>" class="middle townhall-img"></div><div class="right"></div></div>
                <div class="hex" runat="server"><div class="left"></div><div runat="server" id="barracksH" data-toggle="popover" data-placement="right" data-original-title="Barracks" data-content="Train troops to fight with your enemies and steal their resources. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('barracksBtn')[0].click()&quot;>More information</button>" class="middle barracks-img"></div><div class="right"></div></div>
            </div>
            <div class="hex-row">
                <div class="hex" runat="server"><div class="left"></div><div runat="server" id="ironH" data-toggle="popover" data-placement="left" data-original-title="Iron" data-content="Another important resource for your ascension in the fight with your enemies. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('ironBtn')[0].click()&quot;>More information</button>" class="middle iron-img"></div><div class="right"></div></div>
                <div class="hex even" runat="server"><div class="left"></div><div runat="server" id="clayH" data-toggle="popover" data-placement="bottom" data-original-title="Clay" data-content="Without clay you can't build anything or train any troops. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('clayBtn')[0].click()&quot;>More information</button>" class="middle clay-img"></div><div class="right"></div></div>
                <div class="hex" runat="server"><div class="left"></div><div runat="server" id="storageH" data-toggle="popover" data-placement="right" data-original-title="Storage" data-content="In order to store more resources you need to increase your storage facility. <button class=&quot;btn btn-default btn-sm&quot; onclick=&quot;document.getElementsByClassName('storageBtn')[0].click()&quot;>More information</button>" class="middle storage-img"></div><div class="right"></div></div>
            </div>
          </div>
          <div class="col-lg-6">
            <div class="panel panel-primary" ID="buildingPanel" runat="server">
                <div class="panel-heading" ID="panelInformation" runat="server">
                    <h3 class="panel-title" ID="panelTitle" runat="server">Building information</h3>
                </div>
                <div class="panel-body" runat="server">
                    <ul class="list-group" runat="server">
                      <li class="list-group-item" runat="server">
                        <span class="badge" ID="levelBadge" runat="server"></span>
                        Level
                      </li>
                      <li class="list-group-item" runat="server">
                        <span class="badge" ID="costBadge" runat="server"></span>
                        Cost
                      </li>
                      <li class="list-group-item" ID="productionGroup" runat="server">
                        <span class="badge" ID="productionBadge" runat="server"></span>
                        Production
                      </li>
                        <li class="list-group-item" ID="maxResourceGroup" runat="server">
                        <span class="badge" ID="maxResourceBadge" runat="server"></span>
                        Storage limit
                      </li>
                        <li class="list-group-item" ID="townPopulationGroup" runat="server">
                        <span class="badge" ID="townPopulationBadge" runat="server"></span>
                        Population limit
                      </li>
                      </li>
                        <li class="list-group-item" ID="unitLimitGroup" runat="server">
                        <span class="badge" ID="unitLimitBadge" runat="server"></span>
                        Unit limit
                      </li>
                      </li>
                        <li class="list-group-item" ID="unitCostGroup" runat="server">
                        <span class="badge" ID="unitCostBadge" runat="server"></span>
                        Unit cost
                      </li>
                    
                    <div class="text-center" runat="server">
                        <asp:button class="btn btn-primary" ID="upgadeWoodBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeWood_OnClick" Text="Upgrade wood"></asp:button>
                        <asp:button class="btn btn-primary" ID="upgradeIronBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeIron_OnClick" Text="Upgrade iron"></asp:button>
                        <asp:button class="btn btn-primary" ID="upgradeClayBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeClay_OnClick" Text="Upgrade clay"></asp:button>
                        <asp:button class="btn btn-primary" ID="upgradeTownhallBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeTownhall_OnClick" Text="Upgrade townhall"></asp:button>
                        <asp:button class="btn btn-primary" ID="upgrageBarracksBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeBarracks_OnClick" Text="Upgrade barracks"></asp:button>
                        <asp:button class="btn btn-primary" ID="upgradeStorageBtn" runat="server" style="margin-top: 5px;" OnClick="UpgradeStorage_OnClick" Text="Upgrade storage"></asp:button>    
                        <div class=" text-center" style="margin-top: 5px;" ID="trainTroopsGroup" runat="server">
                            <asp:button class="btn btn-primary" ID="trainInfantryBtn" runat="server" OnClick="TrainInfantry_OnClick" Text="Train infantry" />
                            <asp:button class="btn btn-primary" ID="trainGladiatorBtn" runat="server" OnClick="TrainGladitoare_OnClick" Text="Train gladiator" />
                            <asp:button class="btn btn-primary" ID="trainBruteBtn" runat="server" OnClick="TrainBrute_OnClick" Text="Train brute" />
                        </div>

                    </div>
                 </ul>
                </div>
            </div>
        </div>                        
       </div>
    </div>
        <asp:button class="woodBtn" runat="server" style="display: none" OnClick="InfoWood_OnClick" />
        <asp:button class="townhallBtn" runat="server" style="display: none" OnClick="InfoTownhall_OnClick" />
        <asp:button class="barracksBtn" runat="server" style="display: none" OnClick="InfoBarracks_OnClick" />
        <asp:button class="ironBtn" runat="server" style="display: none" OnClick="InfoIron_OnClick" />
        <asp:button class="clayBtn" runat="server" style="display: none" OnClick="InfoClay_OnClick" />
        <asp:button class="storageBtn" runat="server" style="display: none" OnClick="InfoStorage_OnClick" />

    </LoggedInTemplate>
    <AnonymousTemplate>
        <div class="jumbotron">
        <!--Remove --user-- when session stuff are done. -->
        <h1>Welcome to Cottage Wars.</h1>
        <p class="lead">The pefect place to build a cottage and annihilate your enemies!</p>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h2>You can construct buildings!</h2>
            <p>
                In order to construct the ultimate cottage annihilator you need to build the core AKA buildings. Each building is unique in it's own way. Some of them produce you matherials, others give you different functionalities.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Train troops!</h2>
            <p>
                Ah yes, your garrison. What's a leader without his trusty followers ? Build different units. Some are tall, some are short but all of them share one thing, that they can aid you in your conquest plans. 
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Make alliances!</h2>
            <p>
                Let's say not every other cottage is a pest. You might even want to communicate to it. We got you covered for that as well. Send messages and receive ones. We guarantee a 9/11 messengers not killed in the process.</p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    
        </AnonymousTemplate>
    </asp:LoginView>

</asp:Content>
