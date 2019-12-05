<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerManageVirtualWallet.aspx.cs" Inherits="OwlsEat.CustomerManageVirtualWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	<script src = "https://code.jquery.com/jquery-3.4.1.min.js"
            integrity = "sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
            crossorigin = "anonymous"> </script>
        <script src="JS/bootstrap.js"></script>
        <script src="JS/bootstrap.bundle.min.js"></script>
        <link href="CSS/bootstrap.min.css" rel="stylesheet" />
        <!-- Custom styles for this template -->
        <link href="CustomStyleSheet/UserStyleSheet.css" rel="stylesheet" />
           <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/jumbotron/">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="vertical-nav bg-white" id="sidebar">
        <div class="py-4 px-2 mb-8 bg-dark">
            <div class="media d-flex align-items-center">
                <img runat="server" id="imgAvatar" width="65" class="mr-3 rounded-circle img-thumbnail shadow-sm" />
                <div class="media-body">
                    <p class="font-weight-light text-muted mb-0">Restaurant Manager</p>
                </div>
            </div>
        </div>

        <p class="text-gray font-weight-bold text-uppercase px-3 small pb-4 mb-0">Main</p>

        <ul class="nav flex-column bg-white mb-0">
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic ">
                    <i class="fa fa-th-large mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnGetBalance" CssClass="buttonClass" runat="server" OnClick="lnkBtnGetBalance_Click">Get Virtual Wallet Balance</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnFundAccount" CssClass="buttonClass" runat="server" OnClick="lnkBtnFundAccount_Click">Fund Account</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnUpdatePaymentAccount" CssClass="buttonClass" runat="server" OnClick="lnkBtnUpdatePaymentAccount_Click">Update Payment Account</asp:LinkButton>
                </a>
            </li>

			   <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnViewTransactions" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewTransactions_Click">View Transactions</asp:LinkButton>
                </a>
            </li>

        </ul>
    </div>
    <div class="page-content p-5" id="content">


        <h2 class="display-4 text-white">Manage Virtual Wallet Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="Get balance" visible="false" runat="server" id="GetBalance">

            <div id="Balance" runat="server">
                <asp:Label runat="server" Text="Virtual Wallet Balance" ID="lblBalance"></asp:Label>
                <asp:TextBox runat="server" ID="txtVirtualWalletBalance" ReadOnly="True"></asp:TextBox>
            </div>
            <br />



        </div>

        <div class="Fund Account" visible="false" runat="server" id="FundAccount">


            <div id="FundTheAccount" runat="server">
                <asp:Label runat="server" Text="Amount to Fund" ID="lblFund"></asp:Label>
                <asp:TextBox runat="server" ID="txtAmountToFund"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnFund" runat="server" Text="Fund" OnClick="btnFund_Click" />

            <br />

        </div>

        <div class="Update Virtual Wallet" visible="false" runat="server" id="UpdateVirtualWallet">




            <div id="AmountToFund" runat="server">
                <asp:Label runat="server" Text="Title*" ID="lblItemTitle1"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemTitle1" OnTextChanged="txtItemTitle1_TextChanged"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Description" ID="lblItemDescription"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemDescription"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblItemImgUrl1"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemImgUrl1"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Price*" ID="lblItemPrice1"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemPrice1"></asp:TextBox>
                 <br />
                <asp:TextBox runat="server" ID="txtItemID" Visible="False"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnEditItem" runat="server" Text="Edit Item" />

            <asp:GridView ID="gvTransactions" runat="server">
			</asp:GridView>

            <br />



        </div>


    </div>


</asp:Content>
