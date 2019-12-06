<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="OwlsEat.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Owls Eat Registration</title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
    <div class="container">
		<div class="row">
			<div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
				<div class="card card-signin my-5">
                    <div class="card-body">
                        <h5 class="card-title text-center">Register Account</h5>
                        <form id="form1" runat="server" class="form-signin">
                            <div class="form-label-group">

                                <div id="RegisterUserDetails" runat="server">
                                    <asp:DropDownList ID="ddlUserTypeID" CssClass="form-control" required="" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserTypeID_SelectedIndexChanged">
                                          <asp:ListItem disabled="disabled" Value="None">Please Select a User Type</asp:ListItem>
                                        <asp:ListItem Value="Customer">Customer</asp:ListItem>
                                        <asp:ListItem Value="Restaurant">Restaurant</asp:ListItem>
                                    </asp:DropDownList>
                             </br>
                             </br>
                                    <div id="RestaurantDetails" runat="server">
                                         <asp:DropDownList ID="ddlCuisine" CssClass="form-control" required="" runat="server"  AppendDataBoundItems="True" Visible="True">
                                            <Items>
                                                <asp:ListItem disabled="disabled">Please Select a Cuisine Type</asp:ListItem>
                                                <asp:ListItem Value="Spanish">Spanish</asp:ListItem>
                                                <asp:ListItem Value="Indian">Indian</asp:ListItem>
                                                <asp:ListItem Value="Japanese">Japanese</asp:ListItem>
                                                <asp:ListItem Value="Thai">Thai</asp:ListItem>
                                                <asp:ListItem Value="Italian">Italian</asp:ListItem>
                                                <asp:ListItem Value="Mexican">Mexican</asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                        <asp:Label runat="server" Text="RestaurantName*" ID="lblRestaurant"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtRestuarantName"></asp:TextBox>
                                        <br />
                                       
                                        <asp:Label runat="server" Text="Please place Image Url" ID="lblImgUrl"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtImgUrl"></asp:TextBox>
                                        <br />
                                    </div>
                                    <div id="SimilarDetails" runat="server">
                                        <asp:Label runat="server" Text="First Name*" ID="lblFirstName"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                                        <br />
                                        <asp:Label runat="server" Text="Last Name*" ID="lblLastName"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
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
                                        <asp:Label runat="server" Text="Email*" ID="lblEmail"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                                        <br />
                                        <asp:Label runat="server" Text="Password*" ID="lblPassword"></asp:Label>
                                        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
                                        <br />
										<asp:Label runat="server" Text="Confirm Password*" ID="lblCPassword"></asp:Label>
										<asp:TextBox runat="server" TextMode="Password" ID="txtCPassword"></asp:TextBox>
										<br />
										<br />
										<asp:Label runat="server" Text="Security Question: " ID="lblSecurityQuestion"></asp:Label>
										<asp:TextBox runat="server" ID="txtSecurityQuestion" placeholder="What is your mother's Maiden name?"></asp:TextBox>
										<br />
										<asp:Label runat="server" Text="Answer: " ID="lblAnswer"></asp:Label>
										<asp:TextBox runat="server" ID="txtAnswer" placeholder="Stewart"></asp:TextBox>
										<br />
									</div>

									<div id="ChkBoxSameAddressDiv" runat="server">
										<asp:CheckBox ID="chkSameAddress" runat="server" AutoPostBack="False" Text="Billing Address Same As Delivery Address" OnCheckedChanged="chkSameAddress_CheckedChanged" />
									</div>

									<div id="CustomerDetails" runat="server">
										
										<asp:Label runat="server" Text="BillingAddress*" ID="lblBilling"></asp:Label>
										<asp:Label runat="server" Text="Street*" ID="lblBillingStreet"></asp:Label>
										<asp:TextBox runat="server" ID="txtBillingStreet"></asp:TextBox>
										<br />
										<asp:Label runat="server" Text="City*" ID="lblBillingCity"></asp:Label>
										<asp:TextBox runat="server" ID="txtBillingCity"></asp:TextBox>
										<br />
										<asp:Label runat="server" Text="State*" ID="lblBillingState"></asp:Label>
										<asp:TextBox runat="server" ID="txtBillingState"></asp:TextBox>
										<br />
										<asp:Label runat="server" Text="Zip*" ID="lblBillingZip"></asp:Label>
										<asp:TextBox runat="server" ID="txtBillingZip"></asp:TextBox>
										
									</div>
									<div id="RegisterButtonDiv" runat="server">
										<asp:Button CssClass="btn-outline-primary" Text="Register" ID="RegisterUserButton" runat="server" OnClick="RegisterUserButton_Click" />
									</div>
								</div>

                                <div id="PreferencesDiv" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Preferences & Payment Method" ID="lblPreferences"></asp:Label>
                                    <br />
                                    <div id="PaymentMethod" runat="server">
                                        <asp:Label runat="server" Text="Payment Method Name" ID="lblTitle"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtPaymentMethodName"></asp:TextBox>
                                        <br />
                                        <asp:Label runat="server" Text="Account Type" ID="lblAccountType"></asp:Label>
                                        <asp:DropDownList ID="ddlAccountType" CssClass="form-control" required="" runat="server" AutoPostBack="True" AppendDataBoundItems="True">
                                            <Items>
                                                <asp:ListItem disabled="disabled">Select Item</asp:ListItem>
                                                <asp:ListItem>Savings</asp:ListItem>
                                                <asp:ListItem>Checking</asp:ListItem>
                                                <asp:ListItem>Credit</asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                        <asp:Label runat="server" Text="Account Number" ID="lblAccountNumber"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtAccountNumber"></asp:TextBox>
                                        <br />
                                        <asp:Label runat="server" Text="Intitial Balance" ID="lblInitialBalance"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtInitialBalance"></asp:TextBox>
                                        <br />
                                        <br />
                                    </div>
                                    <br />
                                    <br />
                                    <asp:Label runat="server" Text="Login Preference: " ID="lblLoginPreference" />
                                    <asp:DropDownList ID="LoginPreferenceDropDown" runat="server">
                                        <asp:ListItem Text="None" Selected="True" Value="NONE"></asp:ListItem>
                                        <asp:ListItem Text="Auto-Login" Value="Auto-Login"></asp:ListItem>
                                      <%--  <asp:ListItem Text="Fast-Login" Value="Fast-Login"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Button Text="Submit" ID="SubmitPreferencesButton" runat="server" OnClick="SubmitPreferencesButton_Click" />
                                </div>
                            </div>
                            <asp:Label ID="lblLabel" runat="server">  </asp:Label>

                            <asp:Label ID="lblText" runat="server">  </asp:Label>

                        </form>
                    </div>
                </div>
			</div>
		</div>
	</div>
	
</body>
</html>
