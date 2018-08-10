<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="KokoTalk.Chat" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
    <link href="chat.css" rel="stylesheet" />
    <title>Conversation with <!--Put Name Here--></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br />              
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick">
                    </asp:Timer>
                </ContentTemplate>              
            </asp:UpdatePanel>
            <div id="input">
                        <asp:TextBox ID="TextBox1" runat="server" Width="30%"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" />
                    </div>
        </div>
    </form>
</body>
</html>
