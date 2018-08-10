<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="KokoTalk.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%; width: 100%">
        <div style="background-color: black; padding: 15px; color: white">
            &nbsp;<strong>KokoTalk -
            <asp:Label ID="name1" runat="server" Text="Label"></asp:Label>
&nbsp;<spam style="float: right">Log Out</spam></strong>
        </div>
        <div style="background-color: cornflowerblue; padding: 10px; color: white">
            <spam><strong><center>
                <asp:Label ID="name2" runat="server" Text="Name"></asp:Label>
            </center></strong></spam>
        </div>
        <div id="profile" style="background-color: #e6ecff; padding: 10px;">
            <div id="main_profile" style="background-color:white; padding: 10px;">
                <div style="width: 50%; border-radius: 35%"><img src="..."></div>
                <div style="width: 65%">
                    <ul>
                        <li>
                            <asp:Label ID="name" runat="server" Text="Label"></asp:Label>
                        </li>
                        <li>Status</li>
                        <li>Job</li>
                        <li>Location</li>
                        <li>School</li>
                        <li>Background</li>
                    </ul>
                </div>
            </div>
            <br>
            <asp:TextBox ID="TextBox1" runat="server" style="width: 90%; padding: 10px"></asp:TextBox>
            <br>
            <asp:Button ID="Button1" runat="server" Text="Post" style="float: right; background-color: cornflowerblue; color: white" OnClick="Button1_Click" />
            <br>
            <br>

            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
