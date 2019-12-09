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

        </ul>
    </div>
    <!-- End vertical navbar -->


    <!-- Page content holder -->
    <div class="page-content p-5" id="content">


        <h2 class="display-4 text-white">Restaurant Manage Orders Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="View Orders" visible="false" runat="server" id="ViewOrders" style="    
    border: 5px solid black;
    text-align: center;
    margin-top: 10px;
    margin-bottom: 10px;
    font-weight: bold;
    color: white;">


            <div class="gvDiv" align="center"> 
            <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>

            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound">
                <Columns>
                   
                    <asp:BoundField DataField="OrderId" HeaderText="OrderId" />
                    <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
                    <asp:BoundField DataField="PurchasedItems" HeaderText="Items Purchased" />
                    <asp:BoundField DataField="Total" DataFormatString="${0:###,###,###.00}" HeaderText="Total" />
                   
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' Visible="false" />
                            <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("OrderID") %>' Visible="false" />

                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                <asp:ListItem disabled="disabled">Update Status Here</asp:ListItem>
                                <asp:ListItem value="Submitted" >Submitted</asp:ListItem>
                                <asp:ListItem value="Processing" >Processing</asp:ListItem>
                                <asp:ListItem value="Finished" >Finished</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</div>


</asp:Content>
