<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantHomePage.aspx.cs" Inherits="OwlsEat.RestaurantHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/jumbotron/" />

    <!-- Bootstrap core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom styles for this template -->
    <link href="jumbotron.css" rel="stylesheet" />
    <link href="CustomStyleSheet/UserStyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="DivBrowsebyCusine" runat="server">
        <asp:DropDownList ID="ddlCuisine" runat="server" OnSelectedIndexChanged="ddlCuisine_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    </div>
    <asp:GridView ID="gvRestaurant" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="RestaurantName" HeaderText="Restaurant Name" />
            <asp:BoundField DataField="ImgURL" HeaderText="ImgURL" />
        </Columns>
    </asp:GridView>
</asp:Content>
