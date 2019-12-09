<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerHomePage.aspx.cs" Inherits="OwlsEat.CustomerHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src = "https://code.jquery.com/jquery-3.4.1.min.js"
            integrity = "sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
            crossorigin = "anonymous" </script>
        <script src="JS/bootstrap.js"></script>
        <script src="JS/bootstrap.bundle.min.js"></script>
        <link href="CSS/bootstrap.min.css" rel="stylesheet" />
        <!-- Custom styles for this template -->
        <link href="CustomStyleSheet/UserStyleSheet.css" rel="stylesheet" />
           <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/jumbotron/">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




  <div class="page-content text-center ml-5" id="content">
	  <br />
	
	  <br />
		  <h2 class="display-4 text-white text-center">Welcome To OwlEats!</h2>
	    <div class="separator">
        </div>
	  <h2 class="display-4 text-white text-center">If you've just created your account please add funds to your Virtual Wallet using the Manage Virtual Wallet Tab</h2>
       <div id="divImage" runat="server" class="display-3 text-white text-center">
		 <image src="https://www.logolynx.com/images/logolynx/7c/7c5086d757222dc16838a9bba7542938.png" /> 
			 </div>

	  </div>
	
</asp:Content>
