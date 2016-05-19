<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="p2w.aspx.cs" Inherits="CottageWars.p2w" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:LoginView ID="ResourceView" runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <div class="row" runat="server">
                <div class="col-lg-12" runat="server">
                    <div class="panel panel-info text-center" runat="server">
                        <div class="panel-heading" runat="server">
                            <h3 class="panel-title">Pay to win, winning of the future.</h3>
                        </div>
                        <div class="panel-body text-center" runat="server">
                            <div class="form-horizontal" runat="server">
                                <div class="form-group top" runat="server">
                                    <label for="inputName" class="col-lg-2 control-label" runat="server">Owner's name</label>
                                    <div class="col-lg-10" runat="server">
                                        <asp:TextBox class="form-control" placeholder="Name" ID="ownerName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group top" runat="server">
                                    <label for="inputCreditCardNumber" class="col-lg-2 control-label" runat="server">Debit card number</label>
                                    <div class="col-lg-10" runat="server">
                                        <asp:TextBox class="form-control" placeholder="Credit Card Number" ID="CreditCardNumber" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group top" runat="server">
                                    <label for="inputVCSNumber" class="col-lg-2 control-label" runat="server">VCS Number</label>
                                    <div class="col-lg-10" runat="server">
                                        <asp:TextBox class="form-control" placeholder="VCS" ID="VCSNumber" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group top" runat="server">
                                    <label for="inputExpirationDate" class="col-lg-2 control-label" runat="server">Expiration Date</label>
                                    <div class="col-lg-10">
                                        <asp:TextBox class="form-control" placeholder="Expiration Date" ID="expirationDate" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group top" runat="server">
                                    <asp:Button type="submit" class="btn btn-primary btn-top" ID="paytoWinButton" runat="server" Text="Submit" OnClick="PayToWin_Click1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </LoggedInTemplate>

    </asp:LoginView>

</asp:Content>
