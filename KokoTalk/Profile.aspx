<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="KokoTalk.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%; width: 100%">
        <div style="background-color: black; padding: 15px; color: white">
            <strong>KokoTalk - Name <spam style="float: right">Log Out</spam></strong>
        </div>
        <div style="background-color: cornflowerblue; padding: 10px; color: white">
            <spam><strong><center>Name</center></strong></spam>
        </div>
        <div id="profile" style="background-color: #e6ecff; padding: 10px;">
            <div id="main_profile" style="background-color:white; padding: 10px;">
                <div style="width: 50%; border-radius: 35%"><img src="..."></div>
                <div style="width: 65%">
                    <ul>
                        <li>Name, Age</li>
                        <li>Status</li>
                        <li>Job</li>
                        <li>Location</li>
                        <li>School</li>
                        <li>Background</li>
                    </ul>
                </div>
            </div>
            <br>
            <asp:TextBox ID="TextBox1" runat="server" style="width: 100%; padding: 10px"></asp:TextBox>
            <br>
            <asp:Button ID="Button1" runat="server" Text="Button" style="float: right; background-color: cornflowerblue; color: white" />
            <br>
            <br>
            <div id="posts">
                <div style="background-color:white; padding: 10px;">
                    Hello Dennis! What's going on!
                    <p style="float: right">Time, date</p>
                    <br><br>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
