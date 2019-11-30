<%@ Page Title="" Language="C#" MasterPageFile="~/RestaurantMaster.Master" AutoEventWireup="true" CodeBehind="RestaurantSettings.aspx.cs" Inherits="OwlsEat.RestaurantSettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <script src = "https://code.jquery.com/jquery-3.4.1.min.js" integrity = "sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin = "anonymous"> </script>
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
                    <asp:LinkButton ID="lnkBtnViewAccountInformation" CssClass="buttonClass" runat="server" OnClick="lnkBtnViewAccountInformation_Click">View & Update Account Information</asp:LinkButton>
                </a>
            </li>
            <li class="nav-item">
                <a href="#" class="nav-link text-dark font-italic">
                    <i class="fa fa-address-card mr-3 text-primary fa-fw"></i>
                    <asp:LinkButton ID="lnkBtnChangePassword" CssClass="buttonClass" runat="server" OnClick="lnkBtnChangePassword_Click">Change Password</asp:LinkButton>
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


        <h2 class="display-4 text-white">Restaurant Account Settings Page</h2>
        <div class="separator">
        </div>


        <asp:Label runat="server" Text="" ID="lblConfirm" Visible="False"></asp:Label>


        <div class="View Account Information" visible="false" runat="server" id="ViewAccountInformation">

            <div id="RestaurantDetails" runat="server">
                <asp:Label runat="server" Text="Restaurant Name*" ID="lblRestaurant"></asp:Label>
                <asp:TextBox runat="server" ID="txtRestaurantName"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Cuisine" ID="lblCuisine"></asp:Label>
                <asp:TextBox runat="server" ID="txtCuisine"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Please place Image Url" ID="lblImgUrl"></asp:Label>
                <asp:TextBox runat="server" ID="txtImgUrl"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="First Name*" ID="lblFirstName"></asp:Label>
                <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Last Name*" ID="lblLastName"></asp:Label>
                <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                <br />

                <asp:Label runat="server" Text="Current Location:" ID="lblCurrentLocation"></asp:Label><asp:Label runat="server" Text="Location" ID="lblLocation"></asp:Label>
                <br />

                <asp:Label runat="server" Text="Street*" ID="lblStreet"></asp:Label>
                <asp:TextBox runat="server" ID="txtStreet"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="City*" ID="lblCity"></asp:Label>
                <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="State*" ID="lblState"></asp:Label>
                <asp:TextBox runat="server" ID="txtState"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Zip*" ID="lblZip"></asp:Label>
                <asp:TextBox runat="server" ID="txtZip"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Phone Number*" ID="lblPhoneNumber"></asp:Label>
                <asp:TextBox runat="server" ID="txtPhoneNumber"></asp:TextBox>
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnUpdateInfo" runat="server" Text="Update Info" OnClick="btnUpdateInfo_Click" />

            <br />



        </div>

        <div class="Change Password" visible="false" runat="server" id="ChangePassword">

            <div id="SubmitPassword" runat="server">
                <asp:Label runat="server" Text="Please Submit Current Password" ID="lblCurrentPassword"></asp:Label>
                <asp:TextBox runat="server" ID="txtCurrentPassword"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="" ID="lblPwMsg"></asp:Label>
                <br />
                <asp:Label runat="server" Text="Password*" ID="lblPassword"></asp:Label>
                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
                <br />
                <asp:Label runat="server" Text="Confirm Password*" ID="lblCPassword"></asp:Label>
                <asp:TextBox runat="server" TextMode="Password" ID="txtCPassword"></asp:TextBox>
                <br />
            </div>


            <asp:Button CssClass="btn-outline-primary" ID="btnSubmitPassword" runat="server" Text="Change Password" OnClick="btnSubmitPassword_Click" />

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
