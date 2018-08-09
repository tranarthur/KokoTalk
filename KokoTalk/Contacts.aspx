<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="KokoTalk.Contacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Document</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <link rel="stylesheet" href="css/contact.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
</head>
<body>

    <div id="main">
        <div id="nav">
            <span id="app-title">KokoTalk</span>
            <span id="current-user">Arthur</span>
            <span id="logout">Log Out</span>
        </div>
        <div id="contacts">
            <div class="contact">
                <div class="contact-pic">
                    <img src="images/profile/dennis-profile-pic.jpg" alt="" />
                </div>

                <div class="contact-info unread">
                    <div class="contact-upper">
                        <span class="contact-name">Dennis</span>
                        <span class="last-message-time">11:00 PM</span>
                    </div>
                    <div class="contact-lower">
                        <span class="last-message">Hey Arthur!</span>
                        <!--					<span class="message-status"></span>-->
                    </div>
                </div>
            </div>
            <div class="contact">
                <div class="contact-pic">
                    <img src="images/profile/henrique-profile-pic.jpg" alt="" />
                </div>

                <div class="contact-info">
                    <div class="contact-upper">
                        <span class="contact-name">Henrique</span>
                        <span class="last-message-time">8:20 PM</span>
                    </div>
                    <div class="contact-lower">
                        <span class="last-message">You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow? You guys wanna meet up tomorrow?</span>
                        <!--					<span class="message-status"></span>-->
                    </div>
                </div>
            </div>
            <div class="contact">
                <div class="contact-pic">
                    <img src="images/profile/richard-profile-pic.jpg" alt="" />
                </div>

                <div class="contact-info">
                    <div class="contact-upper">
                        <span class="contact-name">Richard</span>
                        <span class="last-message-time">6:45  PM</span>
                    </div>
                    <div class="contact-lower">
                        <span class="last-message">Thanks for stopping by!</span>
                        <!--					<span class="message-status"></span>-->
                    </div>
                </div>
            </div>
            <div class="contact">
                <div class="contact-pic">
                    <img src="images/profile/arthur-profile-pic.jpeg" alt="" />
                </div>

                <div class="contact-info">
                    <div class="contact-upper">
                        <span class="contact-name">Koko</span>
                        <span class="last-message-time">1:00 AM</span>
                    </div>
                    <div class="contact-lower">
                        <span class="last-message">Meet you downstairs in 15 min.</span>
                        <!--					<span class="message-status"></span>-->
                    </div>
                </div>
            </div>
        </div>
        <div id="new-contact">
            <form id="form1" runat="server">
                <input id="new-contact-txtbox" type="text" placeholder="Add New Contact" />
                <button id="add-contact-btn">Add</button>
                </form>
        </div>
        
    </div>

</body>
</html>
