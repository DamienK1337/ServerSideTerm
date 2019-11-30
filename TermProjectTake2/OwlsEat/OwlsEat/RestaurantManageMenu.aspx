<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantManageMenu.aspx.cs" Inherits="OwlsEat.RestaurantManageMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

            <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/jumbotron/" />

    <!-- Bootstrap core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->

    <link href="CustomStyleSheet/UserStyleSheet.css" rel="stylesheet" />
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
                    <asp:LinkButton ID="lnkBtnChangeSecurityQuestion" CssClass="buttonClass" runat="server" OnClick="lnkBtnChangeSecurityQuestion_Click">Update Security Question</asp:LinkButton>
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


        <div class="Create Items" visible="false" runat="server" id="CreateItems">

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
                <asp:TextBox runat="server" ID="txtItemPrice" OnTextChanged="txtItemPrice_TextChanged"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnCreateItem" runat="server" Text="Create Item" OnClick="btnCreateItem_Click" />

            <br />



        </div>

        <div class="Create Menu" visible="false" runat="server" id="CreateMenu">

            <div id="MenuDetails" runat="server">
                <asp:Label runat="server" Text="Title*" ID="lblMenuTitle"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuTitle"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Menu Description" ID="lblMenuDescription"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuDescription"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblMenuImage"></asp:Label>
                <asp:TextBox runat="server" ID="txtMenuImage"></asp:TextBox>
                <br />
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnCreateMenu" runat="server" Text="Create Menu" OnClick="btnCreateMenu_Click" />

            <br />



        </div>

        <div class="Securtiy Questions" visible="false" runat="server" id="ChangeSecurtiyQuestions">

            <div id="SubmitQuestions" runat="server">
                <asp:Label runat="server" Text="Please Submit Current Password" ID="lblCurrentPassword1"></asp:Label>
                <asp:TextBox runat="server" ID="txtCurrentPassword1"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="" ID="lblConfirmPw"></asp:Label>
                <br />
                <asp:Label runat="server" Text="Enter Security Question" ID="lblSecurityQuestion"></asp:Label>
                <asp:TextBox runat="server" ID="txtSecurityQuestion"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Enter Answer" ID="lblAnswer"></asp:Label>
                <asp:TextBox runat="server" ID="txtAnswer"></asp:TextBox>
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnSubmitQuestion" runat="server" Text="Update Security" OnClick="btnSubmitQuestion_Click" />

            <br />



        </div>


    </div>
</asp:Content>
