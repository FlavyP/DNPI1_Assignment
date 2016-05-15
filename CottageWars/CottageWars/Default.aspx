<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CottageWars.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="LoggedInContext" runat="server" ViewStateMode="Disabled">
    <LoggedInTemplate runat="server">
    <div id="divCenter" runat="server" class="divhead"></div>
    <div class="jumbotron" runat="server">
        <!--Remove --user-- when session stuff are done. -->
        <h1><%Response.Write(HttpContext.Current.User.Identity.Name); %>'s Village</h1>
        <p class="lead">Maybe reduce the height of this one or make a table insight it with building spaces of the city.</p>
    </div>
    <div class="jumbotron" runat="server">
      <div class="board" runat="server">
        <div class="hex-row" runat="server">
            <div class="hex" runat="server"><div class="left"></div><div runat="server" ID="woodH" data-toggle="popover" data-placement="left"  data-original-title="Wood" data-content="Wood is a very important resource for your town that will allow you to expand and build an army. <button onclick=&quot;document.getElementById('asdf').click()&quot;>click this</code> attribute." class="middle wood-img"></div><div class="right"></div></div>
            <div class="hex even" runat="server"><div class="left"></div><div runat="server" id="townhallH" data-toggle="popover" data-placement="top" data-original-title="Townhall" data-content="The main building of your village, which dictates how many troups you can have." class="middle townhall-img"></div><div class="right"></div></div>
            <div class="hex" runat="server"><div class="left"></div><div runat="server" id="barracksH" data-toggle="popover" data-placement="right" data-original-title="Barracks" data-content="Train troops to fight with your enemies and steal their resources." class="middle barracks-img"></div><div class="right"></div></div>
        </div>
        <div class="hex-row">
            <div class="hex" runat="server"><div class="left"></div><div runat="server" id="ironH" data-toggle="popover" data-placement="left" data-original-title="Iron" data-content="Another important resource for your ascension in the fight with your enemies." class="middle iron-img"></div><div class="right"></div></div>
            <div class="hex even" runat="server"><div class="left"></div><div runat="server" id="clayH" data-toggle="popover" data-placement="bottom" data-original-title="Clay" data-content="Without clay you can't build anything or train any troops." class="middle clay-img"></div><div class="right"></div></div>
            <div class="hex" runat="server"><div class="left"></div><div runat="server" id="storageH" data-toggle="popover" data-placement="right" data-original-title="Storage" data-content="In order to store more resources you need to increase your storage facility." class="middle storage-img"></div><div class="right"></div></div>
        </div>                         
       </div>
    </div>
        <asp:button runat="server" style="display: none" id="asdf" OnClick="InfoWood_OnClick" />
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
