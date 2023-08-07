<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Address.ascx.cs" Inherits="ContactWeb1.Address" %>


<h3 class="headLine"> Address Details : </h3><br>

<table class="table1">
     <tr>
     <th><asp:Label ID="Label1" class="Label" runat="server" Text="AddressType:"></asp:Label></th>
     <td><asp:RadioButtonList ID="RadioButtonList_New" class="RadioBtn" onselectedindexchanged="RadioBtnChange_Event" RepeatDirection="Horizontal" AutoPostBack ="true" runat="server">
            <asp:ListItem Value="1">Permanent</asp:ListItem>
            <asp:ListItem Value="2">Residential</asp:ListItem>
          </asp:RadioButtonList></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label8" class="Label" runat="server" Text="DoorNo:"></asp:Label></th>
          <td><asp:TextBox ID="TextBox8" class="inputbox" TextMode="Number"  runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label9" class="Label" runat="server" Text="Street :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox9" class="inputbox" placeholder="enter your Street" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label10" class="Label" runat="server" Text="City :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox10" class="inputbox" placeholder="enter your City" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label11" class="Label" runat="server" Text="District :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox11" class="inputbox" placeholder="enter your District" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label12" class="Label" runat="server" Text="State :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox12" class="inputbox" placeholder="enter your state" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label13" class="Label" runat="server" Text="Country :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox13" class="inputbox" placeholder="enter your country" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <th><asp:Label ID="Label14" class="Label" runat="server" Text="Pincode :"></asp:Label></th>
          <td><asp:TextBox ID="TextBox14" class="inputbox" TextMode="Number"  AutoPostBack ="true" OnTextChanged="TextBox2_TextChanged" runat="server"></asp:TextBox></td>
      </tr>
</table>
 