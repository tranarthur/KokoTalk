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
                <div style="width: 50%; border-radius: 35%"><img id="image" src="..." /></div>
                <div style="width: 65%">
                    <ul>
                        <li><b><asp:Label ID="name" runat="server" Text="Full Name"></asp:Label></b>, 
                        <asp:Label ID="age" runat="server" Text="Age"></asp:Label> <b> &nbsp;<asp:Label ID="sex" runat="server" Text="Sex"></asp:Label></b> 
                        </li>
                        <li><asp:Label ID="status" runat="server" Text="Status"></asp:Label>
                        </li>
                        <li><asp:Label ID="email" runat="server" Text="Email Address"></asp:Label>
                        </li>
                        <li><asp:Label ID="job" runat="server" Text="Jod Title"></asp:Label>
                        </li>
                        <li><b>Works</b> at <asp:Label ID="work" runat="server" Text="Company Name"></asp:Label>
                        </li>
                        <li>Lives in <asp:Label ID="city" runat="server" Text="City"></asp:Label> <asp:Label ID="province" runat="server" Text="Province"></asp:Label>
                        </li>
                        <li>Studied at <asp:Label ID="school" runat="server" Text="School"></asp:Label>
                        </li>
                        <li><b>Friends # </b><asp:Label ID="friends" runat="server" Text="0"></asp:Label>
                        </li>
                    </ul>
                </div>
            </div>
            <br>
            <asp:TextBox ID="post" runat="server" style="width: 90%; padding: 10px"></asp:TextBox>
            <br>
            <asp:Button ID="Button1" runat="server" Text="Post" style="float: right; background-color: cornflowerblue; color: white" OnClick="Button1_Click" />
            <br>
            <br>

            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
