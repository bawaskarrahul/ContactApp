<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageContacts.aspx.cs" Inherits="ContactWebApp.Contacts.ManageContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <asp:Button ID="bntAddNew" runat="server" Text="Add New Contact" 
        onclick="bntAddNew_Click" />
</p>
<p>
   <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="false" AllowPaging="false"  DataKeyNames="ContactID" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" PageSize="20" Width="100%">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
        <Columns>
        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Left" >
        <ItemTemplate>
                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ContactID") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
                <asp:Label ID="lblFName" runat="server" Text='<%#Eval("FirstName") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
                <asp:Label ID="lblLName" runat="server" Text='<%#Eval("LastName") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
                <asp:Label ID="lblEmial" runat="server" Text='<%#Eval("Email") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Phone Number" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
                <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("PhoneNumber") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Left">
        <ItemTemplate>
                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>' CssClass="L ALIGNL"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:ImageButton ID="ImgEdit" ToolTip ="Edit" runat="server" ImageUrl ="~/Img/view.png" OnClick="ImgEdit_Click" />                                        
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" Width="50" />
            <ItemStyle HorizontalAlign="Center" Width="50" />
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
 </asp:Content>
