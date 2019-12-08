<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantManageOrders.aspx.cs" Inherits="OwlsEat.RestaurantManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"
        integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo="
        crossorigin="anonymous"> </script>
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
                    <asp:LinkButton ID="lnkBtnViewCurrentOrders" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewCurrentOrders_Click">View & Update Current Orders</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnChangePassword" CssClass="buttonClass" runat="server" >Change Password</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-cubes mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnChangeSecurityQuestion" CssClass="buttonClass" runat="server" >Update Security Question</asp:LinkButton>
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


            <table>



                <asp:Repeater ID="rptOrders" runat="server" OnItemCommand="rptOrders_ItemCommand">
                    <HeaderTemplate>
                        <table border="0" cellpadding="5" cellspacing="0" width="100%" style="border-spacing: 0px;">
                            <tr style="color: #143fe9;">
                                <th scope="col">OrderID</th>
                                <th scope="col">CustomerName</th>
                                <th scope="col">PurchasedItems</th>
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
                               <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                   <asp:ListItem disabled="disabled">Update Status Here</asp:ListItem>
                                    <asp:ListItem Value="Submitted">Submitted</asp:ListItem>
                                    <asp:ListItem Value="Processing">Processing</asp:ListItem>
                                    <asp:ListItem Value="Finished">Finished</asp:ListItem>
                                </asp:DropDownList>
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
</div>


</asp:Content>
