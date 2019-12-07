<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantOrdersPage.aspx.cs" Inherits="OwlsEat.RestaurantOrdersPage" %>
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
                    <asp:LinkButton ID="lnkBtnViewOrders" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewOrders_Click" >View Orders</asp:LinkButton>
                </a>
            </li>
        </ul>
    </div>
    <!-- End vertical navbar -->


    <!-- Page content holder -->
    <div class="page-content p-5" id="content">


        <h2 class="display-4 text-white">Restaurant Manage Orders Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="View Orders" visible="false" runat="server" id="ViewOrders">
              <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>

        <br /><br />
 <table>

            <tr style="color: #CC3300;">
                <th>OrderID</th>
                 <th>CustomerName</th>
                <th>PurchasedItems</th>
                <th>Total</th>
                <th>Date</th>
                <th>Status</th>
            </tr>

            <asp:Repeater ID="rptOrders" runat="server" OnItemCommand="rptOrders_ItemCommand">

                <ItemTemplate>
                    <tr>
                         <td>
                            <asp:Label ID="lblOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerName") %>'></asp:Label>
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
                        <td>
                            <asp:Button ID="btnSelect" CssClass="btn-outline-primary" Text="Select Product" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>

 </table>
</div>
</asp:Content>
