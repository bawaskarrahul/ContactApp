<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCoontact.aspx.cs" Inherits="ContactWebApp.Contacts.AddCoontact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #txtUserName0
        {
            width: 273px;
        }
        #txtUserName
        {
            width: 274px;
        }
        #txtUserName1
        {
            width: 174px;
        }
        #txtFName
        {
            width: 325px;
        }
        #txtLName
        {
            width: 188px;
        }
        #txtContactNumber
        {
            width: 186px;
        }
        #txtContactNumber0
        {
            width: 186px;
        }
        .style1
        {
            width: 118px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<asp:ValidationSummary ID="FormValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="FormValidationSummary"/>
<div class="accountInfo">
<table width="900" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
      <td class="style1">&nbsp;</td>
      <td><strong> 
          <asp:Label ID="lblTitle" runat="server" Text="Contact Form"></asp:Label></strong> </td>
    </tr>
     <tr>
      <td class="style1">&nbsp;</td>
      <td>&nbsp;</td>
    </tr>
     <tr>
          <td class="style1">First Name</td>
          <td>
              <input type="text" id="txtFName" runat="server" maxlength="50" /><asp:RequiredFieldValidator 
                  ID="LastRequired0" runat="server" ControlToValidate="txtFName" 
                             CssClass="failureNotification" 
                  ErrorMessage="First Name is required." ToolTip="User Name is required." 
                             ValidationGroup="FormValidationSummary">*</asp:RequiredFieldValidator>
           </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>
       <tr>
          <td class="style1">Last Name</td>
          <td><input type="text" id="txtLName" runat="server" /> 
           <asp:RequiredFieldValidator ID="LastRequired" runat="server" ControlToValidate="txtLName" 
                             CssClass="failureNotification" 
                  ErrorMessage="Last Name is required." ToolTip="User Name is required." 
                             ValidationGroup="FormValidationSummary">*</asp:RequiredFieldValidator>
           </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>
       <tr>
          <td class="style1">Contact Number</td>
          <td><input type="text" id="txtContactNumber" runat="server" maxlength="15" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" /><asp:RequiredFieldValidator 
                  ID="LastRequired1" runat="server" ControlToValidate="txtContactNumber" 
                             CssClass="failureNotification" 
                  ErrorMessage="Contact number is required." ToolTip="Contact Number is required." 
                             ValidationGroup="FormValidationSummary">*</asp:RequiredFieldValidator>
           </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>
      <tr>
          <td class="style1">Email</td>
          <td> 
              <input type="text" id="txtEmail" runat="server" maxlength="15" /><asp:RequiredFieldValidator 
                  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" 
                             CssClass="failureNotification" 
                  ErrorMessage="Email is required." ToolTip="Email is required." 
                             ValidationGroup="FormValidationSummary">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                  ControlToValidate="txtEmail" CssClass="Err" ErrorMessage="Invalid Email Format" 
                  ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
           </td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
      </tr>
       <tr>
      <td class="style1">Status</td>
      <td>
          <asp:DropDownList ID="cboStatus" runat="server">
              <asp:ListItem Value="1">True</asp:ListItem>
              <asp:ListItem Value="0">False</asp:ListItem>
          </asp:DropDownList>
           </td>
    </tr>
     <tr>
      <td class="style1">&nbsp;</td>
      <td>
          <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
         </td>
    </tr>
    <tr>
      <td class="style1">
          &nbsp;</td>
      <td> <asp:Button ID="btnSubmit" runat="server" CommandName="Submit" Text="Submit" 
                       ValidationGroup="FormValidationSummary" onclick="btnSubmit_Click" 
                        style="height: 26px"/></td>
    </tr>
</table>
</div>
</asp:Content>
