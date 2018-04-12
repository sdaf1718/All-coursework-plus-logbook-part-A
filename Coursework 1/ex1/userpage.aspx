<%@ Page Title="User Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userpage.aspx.cs" Inherits="ex1.userpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="lblwelcome" runat="server" Text="Welcome"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-bottom: 30px" Text="Logout" />
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/changepassword.aspx">Change Password</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
