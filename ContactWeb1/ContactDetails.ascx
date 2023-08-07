<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactDetails.ascx.cs" Inherits="ContactWeb1.ContactDetails" %>

<h3 class="headLine">Contact Details : </h3><br>

<table class="table1">
    <tr>
    <th><asp:Label ID="Label1" class="Label" runat="server" Text="ContactType :"></asp:Label></th>
    
    <td><asp:RadioButtonList ID="RadioButtonList_New1" class="RadioBtn"  onselectedindexchanged="RadioBtnChange_Event" RepeatDirection="Horizontal" AutoPostBack ="true" runat="server">
            <asp:ListItem Value="1">Personal</asp:ListItem>
             <asp:ListItem Value="2">Office</asp:ListItem>
          </asp:RadioButtonList></td>
</tr>
    
<tr>
    <th><asp:Label ID="Label5" class="Label" runat="server" Text="Email :"></asp:Label></th>
    <td><asp:TextBox ID="TextBox5" class="inputbox" textMode="Email" placeholder="example@hotmail.com" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <th><asp:Label ID="Label6"  class="Label" runat="server"  Text="Mobile :"></asp:Label></th>
    <td><asp:TextBox ID="TextBox6"  class="inputbox"  TextMode="Number" runat="server"></asp:TextBox></td>
</tr>
<tr>
    <th><asp:Label ID="Label7" class="Label" runat="server" Text="Phone :"></asp:Label></th>
    <td><asp:TextBox ID="TextBox7" class="inputbox" TextMode="Number" runat="server"></asp:TextBox></td>
</tr>
</table>   
     