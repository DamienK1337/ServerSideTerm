﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBrowse.aspx.cs" Inherits="OwlsEat.CustomerBrowse" %>
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
	 <div class="vertical-nav bg-white" id="sidebar">
        <div class="py-4 px-2 mb-8 bg-dark">
            <div class="media d-flex align-items-center">
               <img runat="server" id="imgAvatar" width="65"  class="mr-3 rounded-circle img-thumbnail shadow-sm"/>
                <div class="media-body">
                    <p class="font-weight-light text-muted mb-0">Customer</p>
                </div>
            </div>
        </div>

        <p class="text-gray font-weight-bold text-uppercase px-3 small pb-4 mb-0">Main</p>

			<ul class="nav flex-column bg-white mb-0">

				<li class="nav-item">
					<a href="#" class="nav-link text-dark font-italic">
						<i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
						
							<asp:DropDownList ID="ddlCuisine" runat="server" OnSelectedIndexChanged="ddlCuisine_SelectedIndexChanged" AutoPostBack="True">
							</asp:DropDownList>
						
					</a>
				</li>


			</ul>
    </div>


	<%--Start Content --%>

	<div class="page-content p-5" id="content">

		  <h2 class="display-4 text-white">Customer Account Settings Page</h2>
        <div class="separator">
        </div>


		<div id="divGvRestaurant" runat="server">
       <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnRowCommand="gvRestaurant_RowCommand">
        <Columns>
			<asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
			<asp:BoundField DataField="ImgURL" HeaderText="ImgURL" />
			
					<asp:ButtonField  runat="server" Text="Button" CommandName="ViewMenu"/>
			
		</Columns>
    </asp:GridView>



		<asp:Label ID="lblRestaurantID" runat="server" Text="Label"></asp:Label>
			<br />
			<asp:Label ID="lblMenu" runat="server" Text="Label"></asp:Label>
		
			<br />
		<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
			</div>
    	  <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False" OnRowCommand="gvMenu_RowCommand">
			  <Columns>
				  <asp:BoundField DataField="MenuName" HeaderText="Menu Name" />
				  <asp:ButtonField  runat="server" Text="Button" CommandName="ViewItems"/>
			  </Columns>
		  </asp:GridView>
    	  <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False">
			  <Columns>
				  <asp:BoundField DataField="Title" HeaderText="Item Name" />
				  <asp:BoundField DataField="Description" HeaderText="Description" />
				  <asp:BoundField DataField="Price" HeaderText="Price" />
				    <asp:ButtonField  runat="server" Text="AddToCart" CommandName="AddToCart"/>
			  </Columns>
		  </asp:GridView>
		<br />
    </div>







	
    


		







	
    


		<asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField DataField="ItemId" HeaderText="Item Id" />
			</Columns>
		</asp:GridView>







	
    
</asp:Content>
