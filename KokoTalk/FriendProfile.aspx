<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendProfile.aspx.cs" Inherits="KokoTalk.FriendProfile" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KokoTalk</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="stylesheet" href="css/profile.css" />
</head>
<body>
    <form id="form1" runat="server" style="padding-left:4%; width: 92%">
         <div style="background-color: black; padding: 15px; color: white">
            &nbsp;<b>KokoTalk -
            <asp:Label ID="name1" runat="server" Text="Label"></asp:Label>
            <spam style="float: right"><a style="text-decoration: none; color: #ffffff;" href="Default.aspx">Log Out</a></spam>
            <spam style="float: right"><a style="text-decoration: none; color: #ffffff;" href="Contacts.aspx">Contacts</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</spam></b>
        </div>
        <div style="background-color:#405E99; padding: 10px; color: black">
            <spam><strong><center style="color:white">
                <asp:Label ID="name2" runat="server" Text="Name"></asp:Label>
            </center></strong></spam>
        </div>
        <div id="profile" style="background-color: #cccccc; padding: 10px;">
            <div id="main_profile" style="background-color:white; padding-left:40px; padding-top:20px;">
                <div style="display:inline-block; padding-left:2%">
                    <asp:Image ID="Image1" runat="server" Height="170px" Width="170px" style="border-radius: 50%"/>
                </div>
                <div style=" padding-left:2%; padding-right:2%; margin:0; width:23%; display:inline-block;">
                        <h1><asp:Label ID="name" runat="server" Text="Full Name"></asp:Label>,&nbsp;<asp:Label ID="age" runat="server" Text="Age"></asp:Label></h1>
                        <h2><asp:Label ID="status" runat="server" Text="Status"></asp:Label></h2>
                        <h3><asp:Label ID="email" runat="server" Text="Email Address"></asp:Label></h3>
                </div>
                <div style="width:40%; display:inline-block;">
                        <b><asp:Label ID="job" runat="server" Text="Jod Title"></asp:Label><b/><br/>
                        <b>Works at<asp:Label ID="work" runat="server" Text="Company Name"></asp:Label></b><br/>
                        <b>Lives in <asp:Label ID="city" runat="server" Text="City"></asp:Label> <asp:Label ID="province" runat="server" Text="Province"></asp:Label></b><br/>
                        <b>Studied at <asp:Label ID="school" runat="server" Text="School"></asp:Label></b><br/>
                        <b>Sex: <asp:Label ID="sex" runat="server" Text="Sex"></asp:Label></b><br/>
                        <b>Number of friends:  <asp:Label ID="friends" runat="server" Text="0"></asp:Label></b><br/>
                </div>
            </div>
            <br/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
