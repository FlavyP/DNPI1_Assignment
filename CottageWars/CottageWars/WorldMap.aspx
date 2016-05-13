<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorldMap.aspx.cs" Inherits="CottageWars.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <!--Remove --user-- when session stuff are done. -->
        <h1><%: Context.User.Identity.GetUserName()  %> --User-- 's Village</h1>
        <p class="lead">Maybe have one giant grid which you can scroll around and select cities and stuff.ll</p>
    </div>
</asp:Content>
