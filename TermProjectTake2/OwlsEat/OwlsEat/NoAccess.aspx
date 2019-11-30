<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAccess.aspx.cs" Inherits="OwlsEat.NoAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<h1>Please Sign in to use OwlEats</h1>
        </div>

		
    	<asp:Button ID="btnGoToLogin" runat="server" Text="ClickHere to Login" OnClick="btnGoToLogin_Click" />

		
    </form>
</body>
</html>
