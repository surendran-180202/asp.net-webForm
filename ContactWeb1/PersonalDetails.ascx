<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonalDetails.ascx.cs" Inherits="ContactWeb1.PersonalDetails" %>


                <tr>
                    <th><asp:Label ID="Label1" class="Label" runat="server" Text="FirstName :"></asp:Label></th>
                    <td><asp:TextBox ID="TextBox1" class="inputbox" placeholder="enter your first name" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
           	        <th><asp:Label ID="Label2" class="Label" runat="server" Text="LastName :"></asp:Label></th>
                    <td><asp:TextBox ID="TextBox2" class="inputbox" placeholder="enter your last name" runat="server"></asp:TextBox></td>
                </tr> 
                <tr>
                    <th><asp:Label ID="Label3"  class="Label" runat="server" Text="Gender :"></asp:Label></th>
                    
                  <td>  <asp:RadioButtonList ID="RadioButtonList_New" class="RadioBtn"  RepeatDirection="Horizontal" AutoPostBack ="true" runat="server">
            <asp:ListItem Value="1">Male</asp:ListItem>
             <asp:ListItem Value="2">Female</asp:ListItem>
                      <asp:ListItem Value="3">Other</asp:ListItem>
          </asp:RadioButtonList><td>
                    
                   <%-- <td><asp:TextBox ID="TextBox3" class="inputbox" runat="server"></asp:TextBox></td>--%>
                </tr>
                <tr>
                    <th><asp:Label ID="Label4"  class="Label" runat="server" Text="DOB :"></asp:Label></th>
                    <td><asp:TextBox ID="TextBox4" class="inputbox" type="date" runat="server"></asp:TextBox></td>
                </tr>
        
