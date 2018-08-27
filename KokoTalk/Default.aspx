<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KokoTalk.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KokoTalk Login</title>
    <link rel="stylesheet" href="css/login.css" />
</head>
<body>


    <div id="main">
        <div id="nav">
            <span id="app-title">KokoTalk</span>
            <span id="noaccount"><a href="Singup.aspx">No Account?</a></span>
        </div>
        <div id="content">
            <form id="form1" runat="server">
                <table id="login">
                    <tr>
                        <td>
                            <asp:TextBox ID="loginTxtBox" runat="server" placeholder="Email" autocomplete="off"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter an email" ControlToValidate="loginTxtBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="No matching email found" ControlToValidate="loginTxtBox" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="passwordTxtBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter a password" ControlToValidate="passwordTxtBox" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Incorrect password" ControlToValidate="passwordTxtBox" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                        </td>
                    </tr>

                    <tr>
                        <td align="center">
                            <asp:Button ID="submit" runat="server" Text="Continue" OnClick="submit_Click" />
                    </tr>
                </table>
            </form>
        </div>
    </div>


</body>
</html>