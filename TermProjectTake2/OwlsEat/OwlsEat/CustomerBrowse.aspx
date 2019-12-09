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
               <img runat="server" src="~/CustomStyleSheet/logo.png"   id="imgAvatar" width="65"  class="mr-3 rounded-circle img-thumbnail shadow-sm"/>
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
                    <asp:LinkButton ID="lnkBtnPurchase" CssClass="buttonClass" runat="server" OnClick="lnkBtnPurchase_Click">View Cart</asp:LinkButton>
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
			<asp:Label ID="LblSearchError" runat="server" Text=""></asp:Label>
			<br />
				<asp:Label ID="LblCuisine" runat="server" Text="Please Select a Cuisine"></asp:Label>

            <asp:DropDownList ID="ddlCuisine" runat="server" OnSelectedIndexChanged="ddlCuisine_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                <asp:ListItem disabled="disabled">Select Restaurant</asp:ListItem>
				 <asp:ListItem Value= "SearchByName" >Search by Restaurant Name</asp:ListItem>
            </asp:DropDownList>


			<div id="divSearch" runat="server">
				
				<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
				<br />
				<asp:Button ID="btnSearch" runat="server" Text="Search for Restaurant" OnClick="btnSearch_Click" />
			</div>



			<div id="divCenterGvRestaurant" runat="server" style="margin-left:250px" >
            <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" GridLines="Horizontal" BorderColor="Blue" BorderStyle="None" CellPadding="10" CellSpacing="5" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chbxRestaurant" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" >
                    <HeaderStyle ForeColor="White" HorizontalAlign="Right" VerticalAlign="Top" />
                    <ItemStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Transparent" BorderWidth="30px" Width="50px" Font-Size="Medium" />
					</asp:BoundField>
                    <asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="ImgUrl">
                        <ControlStyle Height="150px" Width="150px" />
                    	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="Transparent" BorderWidth="30px" Width="50px" />
                    </asp:ImageField>
                </Columns>
    			<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
    </asp:GridView>

				  

				  <asp:Button ID="btnSelectRestaurant" runat="server" Text="Select Restaurant" OnClick="btnSelectRestaurant_Click" />
				
			</div>


            <br />

            <br />
          

            <asp:Label ID="lbltest" runat="server" Text=""></asp:Label>



			<div id="divMenuSlect" runat="server">

            <asp:DropDownList ID="ddlMenu" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem disabled="disabled">Select Menu Item</asp:ListItem>
                </Items>
            </asp:DropDownList>
				</div>
			<br />
			<div id ="divGVMenuItems" runat="server">
				<asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False" BorderStyle="None" style="margin-left:250px" BorderColor="Blue" CellPadding="5" CellSpacing="10" ForeColor="White" GridLines="Horizontal">
					<Columns>
						<asp:TemplateField>
                 <ItemTemplate>
                       <asp:CheckBox ID="chbxMenuItems" runat="server" />
                 </ItemTemplate>
               </asp:TemplateField>
							<asp:BoundField DataField="ItemId" HeaderText="ItemID"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"  >
<HeaderStyle CssClass="hiddencol" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
						</asp:BoundField>
                        <asp:BoundField DataField="RestaurantId" HeaderText="ResaurantID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
<HeaderStyle CssClass="hiddencol" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

<ItemStyle CssClass="hiddencol"></ItemStyle>
						</asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="Title" >
                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" VerticalAlign="Top" />
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:BoundField>
                        <asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="Image">
                            <ControlStyle Height="60px" Width="80px" />
                        </asp:ImageField>

                        <asp:BoundField DataField="Description" HeaderText="Description" >
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:BoundField>
                        <asp:BoundField DataField="Price" DataFormatString="${0:###,###,###.00}" HeaderText="Price" >

                    	<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:BoundField>

                    </Columns>
                	<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
				  <asp:Button ID="btnAddToCart" runat="server" Text="Add Item(s) to Cart" OnClick="btnAddToCart_Click"  />
				</div>

          

			

			</div>

		<div id="divCart" runat="server">
			<asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" ShowFooter="True" BorderColor="Blue" ForeColor="White" GridLines="Horizontal" >
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox ID="chbxDeleteCartItem" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="ItemId" HeaderText="ItemID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
						<HeaderStyle CssClass="hiddencol"></HeaderStyle>

						<ItemStyle CssClass="hiddencol"></ItemStyle>
					</asp:BoundField>
					<asp:BoundField DataField="RestaurantId" HeaderText="ResaurantID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">

						<HeaderStyle CssClass="hiddencol"></HeaderStyle>

						<ItemStyle CssClass="hiddencol"></ItemStyle>
					</asp:BoundField>

					<asp:BoundField DataField="Title" HeaderText="Title" />
					<asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="ImgUrl">
						<ControlStyle Height="60px" Width="80px" />
					</asp:ImageField>

					<asp:BoundField DataField="Description" HeaderText="Description" />
					<asp:BoundField DataField="Price" DataFormatString="${0:###,###,###.00}" HeaderText="Price" />
				</Columns>

				<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />

			</asp:GridView>



			<asp:Label ID="LblCartTest" runat="server" Text=""></asp:Label>
			<asp:Label ID="LblOrderTotal" runat="server" Text=""></asp:Label>
			<div id="divCartControls" runat="server">

			
			<asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
			<asp:Button ID="btnRemoveITems" runat="server" Text="Remove Item(s)" OnClick="btnRemoveITems_Click" />
			<asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
			</div>
		</div>


		<div id="divOrders" runat="server">

            <table>

                <asp:Repeater ID="rptOrders" runat="server">
                    <HeaderTemplate>
                        <table border="0" cellpadding="5" cellspacing="0" width="100%" style="border-spacing: 0px;">
                            <tr style="color: #143fe9;">
                                <th scope="col">Order ID</th>
                                <th scope="col">Restaurant Name</th>
                                <th scope="col">Purchased Items</th>
                                <th scope="col">Total</th>
                                <th scope="col">Date</th>
                                <th scope="col">Status</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                         <td>
                            <asp:Label ID="lblOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RestaurantName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPurchasedItems" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PurchasedItems") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total", "{0:c}") %>'></asp:Label>
                        </td>

                        <td>
                            <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Date") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>

                <SeparatorTemplate>
                    <tr>
                        <td colspan="6">
                            <hr />
                        </td>
                    </tr>
                </SeparatorTemplate>

            </asp:Repeater>

            </table>
		</div>

		<br />
    </div>
      

</asp:Content>
