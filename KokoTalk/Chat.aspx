<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="KokoTalk.Chat" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
    <link href="css/chat.css" rel="stylesheet" />
    <title>Conversation with
        <!--Put Name Here-->
    </title>


</head>
<body>
    <div id="main">
        <div id="nav">
            <span id="app-title">KokoTalk</span>
            <asp:Literal ID="Literal2" runat="server">
            </asp:Literal>
            <span id="logout"><a href="Default.aspx">Log Out</a></span>
            <span id="contacts"><a href="Contacts.aspx">Contacts</a></span>
        </div>


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
            </div>

            <div id="input">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" autocomplete="off"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" OnClientClick="moveVerticalScroll();" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>


    </div>


</body>
<script>
    $(document).ready(function () {
        $('#UpdatePanel1').scrollTop($('#UpdatePanel1')[0].scrollHeight);
    });

    function moveVerticalScroll() {
        $('#UpdatePanel1').scrollTop($('#UpdatePanel1')[0].scrollHeight);
    }

    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    if (prm != null) {
                            prm.add_endRequest(function (sender, e) {
                                    if (sender._postBackSettings.panelsToUpdate != null) {
                $('#UpdatePanel1').scrollTop($('#UpdatePanel1')[0].scrollHeight);
                                    }
                            });
                    };
</script>
</html>
