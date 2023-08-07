<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="ContactWeb1.Update" %>
<%@ Register Src="~/PersonalDetails.ascx" TagPrefix="abc" TagName="Person" %>  
 <%@ Register Src="~/ContactDetails.ascx" TagPrefix="abc" TagName="Contact" %>  
 <%@ Register Src="~/Address.ascx" TagPrefix="abc" TagName="Address" %> 
 <%@ Register Src="~/UserId.ascx" TagPrefix="abc" TagName="Id" %>  



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="outSideBox">
    
       <div class="center">
           <asp:TextBox ID="TextBox15" class="inputbox" placeholder="Enter User ID (or) Name" runat="server"></asp:TextBox><br><br>
                      <asp:Button ID="Button1" Class="btnstyle"  runat="server" icon-class="icon-camera-retro" Text="Search" onclick="Check_Data" />
                      <asp:Button ID="Button3" class="btnstyle"  runat="server"  Text="Delete" onclick="Delete_btn" />
        </div>
  <br><h3 class="headLine">Personal Details : </h3><br>
      <table class="table1">
          <abc:Person ID="Person" runat="server" ></abc:Person>
      </table><br>
      <abc:Contact ID="Contact" runat="server" ></abc:Contact>
      <abc:Address ID="Address" runat="server" ></abc:Address>
      <div class="center">
          <br><br><br><asp:Button ID="Button2" class="btnstyle"  runat="server"  Text="Update" onclick="Update_btn" />
      </div>
</div>
</asp:Content>
