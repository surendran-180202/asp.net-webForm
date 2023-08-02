<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddMore.aspx.cs" Inherits="ContactWeb1.AddMore" %>
<%@ Register Src="~/ContactDetails.ascx" TagPrefix="abc" TagName="Contact" %>  
 <%@ Register Src="~/Address.ascx" TagPrefix="abc" TagName="Address" %> 


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="outSideBox">
               <abc:Contact ID="Contact" runat="server" ></abc:Contact><br>
               <abc:Address ID="Address" runat="server" ></abc:Address>
       <div class="center">
    <br> <br> <asp:Button ID="Button1" CssClass="btnstyle"  runat="server"  Text="Register" onclick="Save_data" />
           </div>
    </div>
       </asp:Content>

