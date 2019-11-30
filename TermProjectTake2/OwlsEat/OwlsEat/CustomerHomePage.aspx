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
