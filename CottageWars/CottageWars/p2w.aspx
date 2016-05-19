<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="p2w.aspx.cs" Inherits="CottageWars.p2w" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
         <asp:LoginView ID="ResourceView" runat="server" ViewStateMode="Disabled">
                <LoggedInTemplate>
                    <div class="row" runat="server">
                        <div class="col-lg-12" runat="server">
                            <div class="panel panel-info text-center" runat="server">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Pay to win, winning of the future.</h3>
                                </div>
                                <div class="panel-body text-center" runat="server">
                                  <div class="form-group">
                                    <label for="inputName" class="col-lg-2 control-label">Credit / Debit card number</label>
                                         <div class="col-lg-10">
                                            <asp:TextBox class="form-control" placeholder="Name" ID="nameText" runat="server"></asp:TextBox>
                                        </div>
                                  </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </LoggedInTemplate>

         </asp:LoginView>
    
</asp:Content>
