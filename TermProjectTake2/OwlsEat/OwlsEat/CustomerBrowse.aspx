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
       <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
			<asp:TemplateField>
                 <ItemTemplate>
                       <asp:CheckBox ID="chbxRestaurant" runat="server" />
                 </ItemTemplate>
               </asp:TemplateField>
			<asp:BoundField DataField="RestaurantId" HeaderText="RestaurantId" />
			<asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
			<asp:BoundField DataField="ImgURL" HeaderText="ImgURL" />
			
					
			
		</Columns>
    </asp:GridView>



			<br />
		
			<br />
				<asp:Button ID="btnSelectRestaurant" runat="server" Text="Select Restaurant" OnClick="btnSelectRestaurant_Click" />

			<asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label>
			<asp:TextBox ID="txtRestaurantID" runat="server"> </asp:TextBox>
			</div>

		<br />
    </div>







	
    


		







	
    


		</asp:Content>
