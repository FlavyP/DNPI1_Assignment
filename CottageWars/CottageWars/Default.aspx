<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CottageWars.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView runat="server" ViewStateMode="Disabled">
    <LoggedInTemplate>
    <div class="jumbotron">
        <!--Remove --user-- when session stuff are done. -->
        <h1><%Response.Write(HttpContext.Current.User.Identity.Name); %>'s Village</h1>
        <p class="lead">Maybe reduce the height of this one or make a table insight it with building spaces of the city.</p>
    </div>
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
