<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Singup.aspx.cs" Inherits="KokoTalk.Singup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KokoTalks Signup</title>
    <link rel="stylesheet" href="css/signup.css" />
    <style>
        .val{
            text-align:right;
        }
    </style>
</head>
<body>

    <div id="main">
        <div id="nav">
            <span id="app-title">KokoTalk Signup</span>
        </div>
        <div id="content">
            <form id="form1" runat="server">
                <table>
                    <tr>

                        <td>
                            <asp:Label ID="Label1" runat="server" Style="text-align: center;" Text="Name"></asp:Label>
                            &nbsp;<br />
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Label ID="Label11" runat="server" Text="School"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSchool" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter your name" Display="Dynamic"></asp:RequiredFieldValidator></td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                            <br />
                        </td>
                        <td>
                            <asp:DropDownList ID="GenderDropDown" runat="server">
                                <asp:ListItem>M</asp:ListItem>
                                <asp:ListItem>F</asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <td>

                            <asp:Label ID="Label12" runat="server" Text="Profile Image"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtImg" runat="server"></asp:TextBox>

                        </td>

                    </tr>


                    <tr>

                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Age"></asp:Label>
                            <br />
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownAge" runat="server">
                            </asp:DropDownList>
                        </td>

                        <td>

                            <asp:Label ID="Label13" runat="server" Text="Profile Status"></asp:Label>
                        </td>
                        <td>
                            <textarea id="txtStatus" runat="server" name="S1" rows="2"></textarea>

                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                        </td>
                        <td>

                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

                        </td>




                    </tr>
                    <tr>
                        <td class="val" colspan="4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter email" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please use '@' symbol" ValidationExpression="[A-z-_\d]+@[A-z]+\.[A-z]+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Province"></asp:Label>
                        </td>

                        <td>
                            <asp:TextBox ID="txtProv" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td class="val" colspan="4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Label ID="Label9" runat="server" Text="Job"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtJob" runat="server"></asp:TextBox>

                        </td>
                        <td>


                            <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>



                        </td>

                    </tr>
                    <tr>
                        <td class="val" colspan="4">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfPassword" ErrorMessage="Passwords must match!" Display="Dynamic"></asp:CompareValidator></td>
                    </tr>

                    <tr>
                        <td>

                            <asp:Label ID="Label10" runat="server" Text="Company"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComp" runat="server"></asp:TextBox>

                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Output" Visible="False"></asp:Label>
                        </td>
                    </tr>




                    <tr>
                        <td>
                            <asp:Button ID="btn_SignUp" runat="server" OnClick="btn_SignUp_Click" Text="Signup!" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>

</body>
</html>
