<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBrowse.aspx.cs" Inherits="OwlsEat.CustomerBrowse" %>
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
	<script type="text/javascript" language="javascript">
    function uncheckOthers(id)
    {        
        var elm = document.getElementsByTagName('input');        
        for(var i = 0; i < elm.length; i++)
        {            
            if(elm.item(i).type == "checkbox" && elm.item(i)!=id)
                elm.item(i).checked = false;
        }
    }
    </script>
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


						
					</a>
				</li>
                  <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic ">
                    <i class="fa fa-th-large mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnBrowse" CssClass="buttonClass" runat="server" OnClick="lnkBtnBrowse_Click" >Browse Restaurants</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnPurchase" CssClass="buttonClass" runat="server" OnClick="lnkBtnPurchase_Click">Purchase Items In Cart</asp:LinkButton>
                </a>
            </li>
                <li class="nav-item">
                    <a href="#" class="nav-link text-dark font-italic">
                        <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                        <asp:LinkButton ID="lnkBtnManageOrder" CssClass="buttonClass" runat="server" OnClick="lnkBtnManageOrder_Click">Manage Orders</asp:LinkButton>
                    </a>
                </li>

            </ul>
    </div>


	<!--Start Content -->

	<div class="page-content p-5" id="content">

		  <h2 class="display-4 text-white">Browse & Manage Purchases Page</h2>
        <div class="separator">
        </div>


        <div id="divGvRestaurant" runat="server">

            <asp:DropDownList ID="ddlCuisine" runat="server" OnSelectedIndexChanged="ddlCuisine_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                <asp:ListItem disabled="disabled">Select Restaurant</asp:ListItem>
            </asp:DropDownList>

            <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chbxRestaurant" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="ImgURL" HeaderText="ImgURL" />



                </Columns>
    </asp:GridView>



            <br />

            <br />
            <asp:Button ID="btnSelectRestaurant" runat="server" Text="Select Restaurant" OnClick="btnSelectRestaurant_Click" />

            <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>





            <asp:DropDownList ID="ddlMenu" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem disabled="disabled">Select Menu Item</asp:ListItem>
                </Items>
            </asp:DropDownList>
            <br />

            <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chbxMenuItems" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Image" HeaderText="Image" />

                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" DataFormatString="${0:###,###,###.00}" HeaderText="Price" />

                </Columns>
            </asp:GridView>

            <asp:Button ID="btnAddToCart" runat="server" Text="Add Item(s) to Cart" OnClick="btnAddToCart_Click" />
        </div>

        <br />
    </div>

</asp:Content>
