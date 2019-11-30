<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAccess.aspx.cs" Inherits="OwlsEat.NoAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; margin-top: 10px; font-size: 18px;">
			<h1>You do not have access to this page. Please login or contact an adminstrator.</h1>
        

		
    	<asp:Button ID="btnGoToLogin"  runat="server" Text="Click Here to Login" OnClick="btnGoToLogin_Click" />
    </div>
		
    </form>
</body>
</html>
