<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="KokoTalk.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Document</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous">
    <link rel="stylesheet" href="css/contact.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
</head>
<body>

    <div id="main">
        <div id="nav">
            <span id="app-title">KokoTalk</span>
            <asp:Literal ID="Literal2" runat="server">
            </asp:Literal>
            <span id="logout"><a href="Default.aspx">Log Out</a></span>
        </div>
                    <form id="form1" runat="server">

        <div class="contacts">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Timer ID="Timer1" runat="server" Interval="2000" OnTick="Timer1_Tick"></asp:Timer>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="new-contact">
                <asp:TextBox ID="new_contact_txtbox" runat="server" placeholder="Add New Contact" autocomplete="off"></asp:TextBox>
                <asp:Button ID="add_contact_btn" runat="server" Text="Add" OnClick="add_contact_btn_Click" />
            
        </div>
        </form>

    </div>

</body>
</html>

