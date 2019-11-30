<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.aspx.cs" Inherits="OwlsEat.PasswordRecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Recovery</title>
    	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div id="recoveryContainer">
            <asp:Label ID="lblPasswordRecovery" CssClass="lblPasswordRecovery" runat="server" Text="Password Recovery"></asp:Label>
            <br />
           
			<asp:Label ID="lblAccountType" runat="server" Text="Choose Your Account Type"></asp:Label>
			<asp:DropDownList ID="ddlUserTypeID" CssClass="form-control" required="" runat="server" OnSelectedIndexChanged="ddlUserTypeID_SelectedIndexChanged" AutoPostBack="True">
				<asp:ListItem Selected="True" Value="None"></asp:ListItem>
				<asp:ListItem Value="Customer">Customer</asp:ListItem>
				<asp:ListItem Value="Restaurant">Restaurant</asp:ListItem>
			</asp:DropDownList>
            <br />
			</div>
			<div id="Main" runat="server">
			<asp:Label ID="lblPrompt" runat="server" Text="Please enter your email below and click get questions to retrieve your security questions:"></asp:Label>
			<br />
            <asp:Label ID="lblEmail" runat="server" Text="Email Address:"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmail" CssClass="txtPasswordRecovery" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGetUser" CssClass="btnPasswordRecovery" runat="server" Text="Get Questions" OnClick="btnGetUser_Click" />
            <br />
            <br />
            <div id="securityQuestions">
                <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question: "></asp:Label>
                <br />
                <asp:TextBox ID="txtAnswer" CssClass="txtPasswordRecovery" runat="server"></asp:TextBox>
				<br />
				<br />
				<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
				<br />
				<br />
                <asp:Button ID="btnSubmitQuestions" CssClass="btnPasswordRecovery" runat="server" Text="Submit Questions" OnClick="btnSubmitQuestions_Click" />
                <asp:Button ID="btnBackToLogin" CssClass="btnPasswordRecovery" runat="server" Text="Back to Login" OnClick="btnBackToLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
