<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addressbook.aspx.cs" Inherits="coursework4mailapp.addressbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <p>
        <asp:Label ID="lblInfo" runat="server"></asp:Label> <button onclick="$('#dialog input:text').val(''); $('#dialog').dialog({open: function(type,data) {$(this).parent().appendTo('form');}}); return false;">Add Contact</button>
    </p>
    <p>
        <asp:GridView ID="grdEmails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="154px" Width="400px" AutoGenerateColumns="False" 
            OnRowEditing="grdEmails_OnRowEditing" OnRowCancelingEdit="grdEmails_OnRowCancelingEdit" OnRowDeleting="grdEmails_OnRowDeleting" OnRowUpdating="grdEmails_OnRowUpdating">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href="/compose.aspx?To=<%#Eval("EmailID") %>"><%#Eval("EmailID") %></a>
                        <asp:HiddenField runat="server" ID="hdEmailID" Value='<%#Eval("EmailID") %>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="txtEmailID" Text='<%#Bind("EmailID") %>'></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hdEmailID" Value='<%#Eval("EmailID") %>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True"  />
            </Columns>
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
    <div id="dialog" title="Add Contact" style="display: none;">
        <asp:TextBox runat="server" ID="txtFirst" placeholder="First Name"></asp:TextBox><br/>
        <asp:TextBox runat="server" ID="txtLast" placeholder="Last Name"></asp:TextBox><br/>
        <asp:TextBox runat="server" ID="txtEmail" placeholder="Email"></asp:TextBox><br/>
        <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_OnClick" UseSubmitBehavior="False"/>
    </div>
</asp:Content>
