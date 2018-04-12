<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ex1.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 58%;
    }
    .auto-style2 {
        width: 328px;
        font-size: large;
        text-align: justify;
    }
    .auto-style3 {
        width: 328px;
        height: 31px;
        font-size: large;
        text-align: justify;
    }
    .auto-style4 {
        height: 31px;
    }
    .auto-style5 {
        width: 328px;
        font-size: large;
        text-align: justify;
        height: 39px;
    }
    .auto-style6 {
        height: 39px;
        width: 84px;
    }
    .auto-style8 {
        height: 31px;
        width: 736px;
    }
    .auto-style9 {
        height: 39px;
        width: 736px;
    }
    .auto-style14 {
        height: 39px;
        width: 358px;
    }
    .auto-style23 {
        width: 84px;
    }
    .auto-style24 {
            width: 736px;
        }
    .auto-style28 {
            width: 358px;
        }
        #Reset1 {
            height: 49px;
            width: 92px;
        }
        .auto-style29 {
            font-size: xx-large;
        }
        .auto-style30 {
            font-size: large;
        }
        .auto-style31 {
            width: 736px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">








    <p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style31"><strong><span class="auto-style30">Welcome to the registration page</span><br class="auto-style29" />
                </strong></td>
            <td class="auto-style28">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"><strong>Username</strong></td>
            <td class="auto-style8">
                <asp:TextBox ID="txtusername" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="Username required" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style28"></td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"><strong>Password</strong></td>
            <td class="auto-style9">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpassword" ErrorMessage="Password required" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style14"></td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Role</strong></td>
            <td class="auto-style24">
                <asp:TextBox ID="txtrole" runat="server" Width="336px">user</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrole" ErrorMessage="Please enter user role" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style28">
                &nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Email</strong></td>
            <td class="auto-style24">
                <asp:TextBox ID="txtemail" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtemail" ErrorMessage="Email required" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style28">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Must enter valid email" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" style="font-weight: 700"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Security Question</strong></td>
            <td class="auto-style24">
                <asp:TextBox ID="txtsq" runat="server" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtsq" ErrorMessage="Secret question required" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style28">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Secret Anwser</strong></td>
            <td class="auto-style24">
                <asp:TextBox ID="txta" runat="server" TextMode="Password" Width="336px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txta" ErrorMessage="Secret anwser required" ForeColor="Red" style="font-weight: 700"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style28">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style24">&nbsp;</td>
            <td class="auto-style28">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <input id="Reset1" type="reset" value="reset" /></td>
            <td class="auto-style24">
                <asp:Button ID="btnregister" runat="server" BackColor="Silver" BorderStyle="Groove" OnClick="btnregister_Click" style="text-align: center" Text="Register" Height="56px" Width="142px" />
            </td>
            <td class="auto-style28">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
        </tr>
    </table>
    <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/forgotpassword.aspx">Forgot password</asp:HyperLink>
</p>
<p>
</p>








</asp:Content>
