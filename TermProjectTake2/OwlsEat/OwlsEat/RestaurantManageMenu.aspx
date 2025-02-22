﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantManageMenu.aspx.cs" Inherits="OwlsEat.RestaurantManageMenu" %>
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
                    <asp:LinkButton ID="lnkBtnCreateItems" CssClass="buttonClass" runat="server" OnClick="lnkBtnCreateItems_Click">Create Items</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnCreateMenu" CssClass="buttonClass" runat="server" OnClick="lnkBtnCreateMenu_Click">Create Menu</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnViewItems" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewItems_Click">View & Edit Items</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnViewMenus" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewMenus_Click">View & Edit Menus</asp:LinkButton>
                </a>
            </li>

        </ul>
    </div>

    <!-- End vertical navbar -->


    <!-- Page content holder -->
    <div class="page-content p-5" id="content">


        <h2 class="display-4 text-white">Restaurant Manage Menu Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="Create Items" visible="false" runat="server" id="CreateItems" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">

            <div id="ItemDetails" runat="server">
                <asp:Label runat="server" Text="Title*" ID="lblItemTitle"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemTitle"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Description" ID="lblDescription"></asp:Label>
                <asp:TextBox runat="server" ID="txtDescription"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblItemImgUrl"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemImgUrl"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Price*" ID="lblItemPrice"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemPrice"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnCreateItem" runat="server" Text="Create Item" OnClick="btnCreateItem_Click" />

            <br />



        </div>

        <div class="Create Menu" visible="false" runat="server" id="CreateMenu" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">


            <div id="MenuDetails" runat="server">
                 <asp:Label runat="server" Text="" ID="lblConfirm1" Visible="False"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuID" Visible="False"></asp:TextBox>
                   <br />
                <asp:Label runat="server" Text="Menu Name*" ID="lblMenuTitle"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuTitle"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Menu Description" ID="lblMenuDescription"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuDescription"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblMenuImage"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuImage"></asp:TextBox>
                <br />
                <br />
         <asp:Button CssClass="btn-outline-primary" ID="btnCreateMenu" runat="server" Text="Create Menu" OnClick="btnCreateMenu_Click" />

            </div>

              <div id="AddItemsToMenu" runat="server" align="center" >

            <asp:GridView ID="gvItems" runat="server"  AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select Item">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemID" HeaderText="Item ID" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="Image">
                        <ControlStyle Height="60px" Width="80px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                </Columns>
            </asp:GridView>

                  <asp:Button CssClass="btn-outline-primary" ID="btnAddItemstoMenu" runat="server" Text="Add Items To Menu" OnClick="btnAddItemstoMenu_Click" />

              </div>

            <br />

        </div>

        <div class="View And Edit Items" visible="false" runat="server" id="ViewAndEditItems" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">

            <asp:DropDownList ID="ddlItemID" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemID_SelectedIndexChanged" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem  disabled="disabled">Select Item</asp:ListItem>
                </Items>
            </asp:DropDownList>


            <div id="EditItems" runat="server">
                <asp:Label runat="server" Text="Title*" ID="lblItemTitle1"></asp:Label>
                <asp:TextBox runat="server" ID="txtItemTitle1"></asp:TextBox>
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


            <asp:Button CssClass="btn-outline-primary" ID="btnEditItem" runat="server" Text="Edit Item" OnClick="btnEditItem_Click" />

            <br />



        </div>

        <div class="View And Edit Menu" visible="false" runat="server" id="ViewAndEditMenu" style="border: 5px solid black; text-align: center; margin-top: 10px; margin-bottom: 10px; font-weight: bold; color: white;">

            <asp:DropDownList ID="ddlEditMenus" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEditMenus_SelectedIndexChanged" AppendDataBoundItems="True">
                <Items>
                    <asp:ListItem  disabled="disabled">Select Menu</asp:ListItem>
                </Items>
            </asp:DropDownList>


            <div id="EditMenus" runat="server">

                <asp:Label runat="server" Text="Menu Name*" ID="lblMenuName"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuName1"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Menu Description" ID="lblMenuDescription1"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuDescription1"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblMenuImgUrl"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuImgUrl"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnEditMenus" runat="server" Text="Edit Menu" OnClick="btnEditMenus_Click" />

            <br />

            <asp:DropDownList ID="ddlAddOrRemove" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAddOrRemove_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False">
                <Items>
                    <asp:ListItem disabled="disabled">How do you want to edit Menus?</asp:ListItem>
                    <asp:ListItem Value="Add">Add Items To Current Menu</asp:ListItem>
                    <asp:ListItem Value="Remove">Remove Items From Current Menu</asp:ListItem>
                </Items>
            </asp:DropDownList>

            <div id="divAdd" runat="server">

            <asp:GridView ID="gvAddMenuItems" runat="server"  AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select Item">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemID" HeaderText="Item ID" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="Image">
                        <ControlStyle Height="60px" Width="80px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                </Columns>
            </asp:GridView>
        
                <asp:Button CssClass="btn-outline-primary" ID="btnAdd" runat="server" Text="Add To Menu" OnClick="btnAdd_Click" />

            </div>

            <div id="divRemove" runat="server">

            <asp:GridView ID="gvRemoveMenuItems" runat="server"  AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Select Item">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect2" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ItemID" HeaderText="Item ID" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:ImageField ControlStyle-Height="100" ControlStyle-Width="100" DataImageUrlField="Image">
                        <ControlStyle Height="60px" Width="80px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Price" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                </Columns>
            </asp:GridView>

                <asp:Button CssClass="btn-outline-primary" ID="btnRemove" runat="server" Text="Remove from Menu" OnClick="btnRemove_Click" />

            </div>


        </div>


    </div>
</asp:Content>
