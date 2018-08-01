<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="KokoTalk.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
    <style>
        body {
    background-color: azure;
    font-family: 'Roboto', sans-serif;
    font-size: 16px;
    font-weight: 300;
    line-height: 1.625;
    text-align: center;
}
        .time{
            font-style:italic;
            font-size:8px;
        }
        .name{
   
            font-size:20px;
            font-weight:bold;
            text-align: center;
        }
        .speech-bubble {
            padding:10px;
            width: 500px;
            margin-top: 5px;
            text-align: left;
            background: #00aabb;
            border-radius: .4em;
            
        }

            

        .speech-bubble2 {
            padding:10px;
            width: 500px;
            margin-top: 5px;
            text-align: right;
            background: green;
            border-radius: .4em;
           
        }

        #input {
            width:100%;
            bottom: 10px;
            
        }
        #UpdatePanel1{
            margin-left:33%;
        }
    </style>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
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
