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
                <img runat="server" src="~/CustomStyleSheet/logo.png" id="imgAvatar" width="65" class="mr-3 rounded-circle img-thumbnail shadow-sm" />
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

     <!-- End vertical navbar -->


    <!-- Page content holder -->
   <div class="page-content p-5" id="content">


        <h2 class="display-4 text-white">Manage Virtual Wallet Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="Get balance" visible="false" runat="server" id="GetBalance" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">

            <div id="Balance" runat="server">
                <asp:Label runat="server" Text="Virtual Wallet Balance" ID="lblBalance"></asp:Label>
                <asp:TextBox runat="server" ID="txtVirtualWalletBalance" ReadOnly="True"></asp:TextBox>
            </div>
            <br />



        </div>

        <div class="Fund Account" visible="false" runat="server" id="FundAccount" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">


            <div id="FundTheAccount" runat="server">
                <asp:Label runat="server" Text="Amount to Fund" ID="lblFund"></asp:Label>
                <asp:TextBox runat="server" ID="txtAmountToFund"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnFund" runat="server" Text="Fund" OnClick="btnFund_Click" />

            <br />

        </div>

       <div class="Update Virtual Wallet" visible="false" runat="server" id="UpdateVirtualWallet" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">


           <div id="PaymentMethod" runat="server">
               <asp:Label runat="server" Text="Payment Method Name" ID="lblTitle"></asp:Label>
               <asp:TextBox runat="server" ID="txtPaymentMethodName"></asp:TextBox>
               <br />
               <asp:Label runat="server" Text="Account Type" ID="lblAccountType"></asp:Label>
               <asp:DropDownList ID="ddlAccountType" CssClass="form-control" required="" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                   <Items>
                       <asp:ListItem disabled="disabled">Select Item</asp:ListItem>
                       <asp:ListItem>Savings</asp:ListItem>
                       <asp:ListItem>Checking</asp:ListItem>
                       <asp:ListItem>Credit</asp:ListItem>
                   </Items>
               </asp:DropDownList>
               <asp:Label runat="server" Text="Account Number" ID="lblAccountNumber"></asp:Label>
               <asp:TextBox runat="server" ID="txtAccountNumber"></asp:TextBox>
               <br />
               <asp:Label runat="server" Text="Intitial Balance" ID="lblInitialBalance"></asp:Label>
               <asp:TextBox runat="server" ID="txtInitialBalance"></asp:TextBox>
               <br />
               <br />
           </div>


           <asp:Button CssClass="btn-outline-primary" ID="btnUpdateInfo" runat="server" Text="Update Info" OnClick="btnUpdateInfo_Click" />

           <br />



       </div>

       <div id="divViewTrans" runat="server">
           <div class="gvDiv" align="center" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">
               <asp:GridView ID="gvTransactions" runat="server">
               </asp:GridView>
           </div>
       </div>

   </div>

</asp:Content>
