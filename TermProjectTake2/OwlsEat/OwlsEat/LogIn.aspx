<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="OwlsEat.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Owls Eat LogIn</title>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
</head>
<body>
  <div class="container">
		<div class="row">
			<div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
				<div class="card card-signin my-5">
					<div class="card-body">
						<h5 class="card-title text-center">Log Into Owls Eat</h5>
						<form id="form1" runat="server" class="form-signin">
							<div class="form-label-group">

								<asp:DropDownList ID="ddlUserTypeID" CssClass="form-control"  required="" runat="server">
									<asp:ListItem Selected="True" Value="Customer">Customer</asp:ListItem>
									<asp:ListItem Value="Restaurant">Restaurant</asp:ListItem>
								</asp:DropDownList>

								<br />
								<label >Email:</label>
									<br />
								<asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>

									
									<br />
								<label id="lblPassword">Password:</label>
									<br />
								<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>


								<br />

								<asp:Button CssClass="btn-outline-primary" ID="btnSignUp" runat="server" Text="Log In" OnClick="btnSignUp_Click"  />

                                <br />

                                <asp:Button CssClass="btn-outline-primary" ID="btnRegister" runat="server" Text="Create Account" OnClick="btnRegister_Click" />
                                <br />
                                <asp:HyperLink ID="hLinkForgotPassword" NavigateUrl="PasswordRecovery.aspx" Text="Forgot your password?" runat="server"></asp:HyperLink>
                                <br />
                                <asp:Label ID="lblLoginMode" runat="server" Text="Login Mode"></asp:Label>
                                <br />
                                <asp:RadioButton ID="rdoNormalLogin" GroupName="loginMode" Text="Normal" runat="server" />
                                <asp:RadioButton ID="rdoAutoLogin" GroupName="loginMode" Text="Auto Login" runat="server" />

							</div>

                            <asp:Label ID="lblMessage" runat="server">  </asp:Label>

							<asp:Label ID="lblText" runat="server">  </asp:Label>

						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
