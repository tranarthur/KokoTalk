<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="KokoTalk.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>

<body>

    <form id="form1" runat="server">
        <div style="height: 937px">
            <table >
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                        &nbsp;<br />
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter your name"></asp:RequiredFieldValidator>
                        <td ></td>
                </tr>
                <br />
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                        <br />
                        <asp:DropDownList ID="GenderDropDown" runat="server">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Age"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <br />

                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Province"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtProv" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter a password"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                
                <tr>
                    <td>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfPassword" ErrorMessage="Please enter the same password"></asp:CompareValidator>
                        <br />

                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtConfPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfPassword" ErrorMessage="Please enter confirm your password"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                <br />
                <br />
                <tr>
                    <td>
                        <asp:Button ID="btn_SignUp" runat="server" OnClick="btn_SignUp_Click" Text="Signup!" />
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Output"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>

</body>
</html>
