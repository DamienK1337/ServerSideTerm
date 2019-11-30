<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpMerchant.aspx.cs" Inherits="TermProject.SignUpMerchant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
</head>
<body>
 <div class="container">
		<div class="row">
			<div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
				<div class="card card-signin my-5">
					<div class="card-body" >
						<h5 class="card-title text-center">Create Merchant Account</h5>
						<form id="form1" runat="server" class="form-signin">
                            <div class="form-label-group" id="RegisterMerchantDetails" runat="server">


                                <br />

                                <label for="lblFirstName">First Name</label>

                                <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />

                                <label for="lblLastName">Last Name</label>

                                <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />

                                <label for="lblCompanyName">Company Name</label>

                                <asp:TextBox ID="txtCompanyName" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <label for="lblEmail">E-mail Address</label>

                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />

                                <label for="lblPassword">Password</label>

                                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>

                                <label for="lblConfirmation">Password</label>

                                <asp:TextBox ID="txtCPassword" CssClass="form-control" runat="server"></asp:TextBox>


                                <br />

                                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up!" OnClick="btnSignUp_Click" />
                            </div>

                            <asp:Label ID="lblLabel" runat="server">  </asp:Label>

                            <asp:Label ID="lblText" runat="server">  </asp:Label>

                            <div id="BankAccount" runat="server" visible="false">

                                <asp:Label runat="server" Text="Bank Account Information" ID="lblBankAccount"></asp:Label>
                                <br />
                                <label for="lblBankCompany">Bank Company</label>

                                <asp:TextBox ID="txtBankCompany" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />

                                <asp:Label runat="server" Text="Account Type " ID="lblAccountType" />
                                <asp:DropDownList ID="ddlAccountType" runat="server">
                                    <asp:ListItem Text="Checking Account" Selected="True" Value="Checking"></asp:ListItem>
                                    <asp:ListItem Text="Savings Account" Value="Savings"></asp:ListItem>
                                    <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <label for="lblAccountNumber">Account Number</label>

                                <asp:TextBox ID="txtAccountNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button Text="Submit" ID="btnSubmitBankInformation" runat="server" OnClick="btnSubmitBankInformation_Click" />
                            </div>
                            <div id="SubmitConfirmation" runat="server" visible="false">

                                <asp:Label runat="server" Text="Thank you for Submitting!" ID="lblSubmitConfirmation"></asp:Label>
                                <br />
                            </div>
                        </form>
                    </div>

                </div>
            </div>
        </div>
	</div>
	
</body>
</html>
