<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KokoTalk.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KokoTalk Login</title>
    <link rel="stylesheet" href="css/login.css"/>
</head>
<body>
    <form id="form1" runat="server">

        <div id="main">
            <div id="nav">
                <span id="app-title">KokoTalk</span>
                <span id="noaccount">No Account?</span>
            </div>
            <div id="content">
                <table id="login">
                    <tr>
                        <td>
                            <asp:TextBox ID="loginTxtBox" runat="server" placeholder="Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox id="passwordTxtBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center">
                        <asp:Button id="submit" runat="server" Text="Continue" OnClick="submit_Click" />

                    </tr>
                </table>
            </div>
        </div>
    </form>
    
</body>
</html>
