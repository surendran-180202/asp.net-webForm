<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ContactWeb1._Default" %>
<%@ Register Src="~/PersonalDetails.ascx" TagPrefix="abc" TagName="Person" %>  
<%@ Register Src="~/ContactDetails.ascx" TagPrefix="abc" TagName="Contact" %>  
<%@ Register Src="~/Address.ascx" TagPrefix="abc" TagName="Address" %> 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Contact Book Registration</h2>
    <div class="outSideBox">
        <br><h3 class="headLine">Personal Details : </h3><br>
        <table class="table1">
            	<abc:Person ID="Person1" runat="server" ></abc:Person>
        </table><br>
        <abc:Contact ID="Contact" runat="server" ></abc:Contact><br>
        <abc:Address ID="Address" runat="server" ></abc:Address>
        <div class="center">
             <br> <br> <asp:Button ID="Button1" class="btnstyle"  runat="server"  Text="Register" onclick="Save_data" />
             <asp:Button ID="Button2" runat="server" Text="Add More" OnClick="AddMore" CssClass="btnstyle" />
       </div>
     </div>
<br>
</asp:Content>
