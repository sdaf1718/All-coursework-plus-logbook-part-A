<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="inbox.aspx.cs" Inherits="coursework4mailapp.inbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <p>
        Please sign in with email and Password to access your Gmail account Please do not change the settings or the system will crash.</p>
    <p>
        Server&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtServer" runat="server" Text="pop.gmail.com" Enabled="False"></asp:TextBox>
    </p>
    <p>
        Email ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </p>
    <p>
        Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox TextMode="Password" ID="txtpwd" runat="server"></asp:TextBox>
    </p>
    <p>
        Port&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPort" runat="server" Text="995" Enabled="False"></asp:TextBox>
    </p>
    <p>
        SSL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkSSL" runat="server" Checked="True" Enabled="False" />
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ReadEmails" runat="server" OnClick="ReadEmails_Click" Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
       

        <asp:GridView ID="GvEmails" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField  DataField="Messageorder" HeaderText="Messageorder" SortExpression="Messageorder"/>
                <asp:BoundField  DataField="From" HeaderText="From" SortExpression="From"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="javascript:;" onclick="$('#dialog p').html($(this).next('input:hidden').val()); $('#dialog').dialog({width: 800});"><%#Eval("Subject") %></a>
                        <asp:HiddenField runat="server" ID="hdMessageBody" Value='<%#Bind("Body") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField  DataField="Datesent" HeaderText="Date Sent" SortExpression="DateSent"/>
               
            </Columns>
        </asp:GridView>

    </p>
    <div id="dialog" title="Body" style="display: none;">
        <p>This is the default dialog which is useful for displaying information. The dialog window can be moved, resized and closed with the 'x' icon.</p>
    </div>
    
</asp:Content>