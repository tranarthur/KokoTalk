﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="KokoTalk.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.4.min.js"></script>
    <link href="" rel="stylesheet" />
    <style>
       #header {
			box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.0), 0 3px 10px 0 rgba(0, 0, 0, 0.19);
			padding: 20px;
		}

		.speech {
			clear: both;
			overflow: hidden;
			padding: 5px 30px;
		}

		#content {

			display: inline-block;
			width: 50%;
			background-color: white;
			box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.0), 0 3px 10px 0 rgba(0, 0, 0, 0.19);
			height: 100vh;
			position: relative;

		}

		body {
			background-color: gainsboro;
			font-family: 'Roboto', sans-serif;
			font-size: 16px;
			font-weight: 300;
			line-height: 1.625;
			text-align: center;
			margin: 0;
		}

		.time {
			font-style: italic;
			font-size: 8px;
		}

		.name {
			font-size: 20px;
			font-weight: bold;
			text-align: center;
		}

		.speech-bubble {
			padding: 10px;
			display: inline-block;
			margin-top: 5px;
			float: left;
			text-align: left;
			background: #E6E5EA;
			border-radius: .5em;
			max-width: 50%;

		}

		.speech-bubble2 {
			padding: 10px;
			margin-top: 5px;
			display: inline-block;
			float: right;
			text-align: right;
			background: #157EFB;
			border-radius: .5em;
			color: white;
			max-width: 50%;

		}

		#input {
			position: absolute;
			bottom: 0;
			width: 100%;
			box-shadow: 0 2px 4px 0 rgba(0, 0, 0, 0.0), 0 3px 10px 0 rgba(0, 0, 0, 0.19);



		}

		input[type="text"] {
			border: none;
			background-color: white;
			padding: 20px 10px;
			font-size: 20px;
			width: 80%;
			outline: none;

		}

		#UpdatePanel1 {
			margin: 30px auto;
			overflow-y: auto;
		}

		#Button1 {
			display: inline;
			border: none;
			font-size: 20px;
			color: grey;
		}
    </style>
    <title></title>

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
