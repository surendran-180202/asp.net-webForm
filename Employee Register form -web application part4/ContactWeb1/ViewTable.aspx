<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTable.aspx.cs" Inherits="ContactWeb1.ViewTable" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridView1"  runat="server" CellPadding="2" CellSpacing="2" GridLines ="Both" CssClass="mydatagrid" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BorderColor="#EFE6F7" ForeColor="#003399"  Width="100%"  Font-Size="Small" BorderStyle="Solid" BorderWidth="1px" ShowFooter="true" ShowHeader="true" >
<HeaderStyle BackColor="#FFE5B4" Font-Size="15PX" />
      
            
        <AlternatingRowStyle BackColor="#FBF6D9" />
<Columns>
           <asp:BoundField  DataField="PERSONID"    HeaderText=" ID" />
           <asp:BoundField  DataField="FIRSTNAME"   HeaderText="FIRSTNAME" />
           <asp:BoundField  DataField="LASTNAME"    HeaderText="LASTNAME" />
           <asp:BoundField   DataField="GENDER"      HeaderText="GENDER" />
           <asp:BoundField  DataField="DOB"         HeaderText="DOB" />
    <asp:TemplateField HeaderText="Contact">
        <ItemTemplate>
            <asp:GridView ID="GridView2" GridLines="None" runat="server"  AutoGenerateColumns="False" CellPadding="6" CellSpacing="6" DataSource='<%# Bind("contact") %>'>
                <HeaderStyle Font-Size="10px" />
                <Columns>
                        <asp:BoundField  DataField="CONTACTTYPE" HeaderText="CONTACYTYPE" />
                        <asp:BoundField  DataField="EMAIL"       HeaderText=" EMAIL"  />
                        <asp:BoundField  DataField="MOBILE"      HeaderText=" MOBILE"  />
                        <asp:BoundField  DataField="PHONE"       HeaderText=" PHONE" />
                </Columns>
            </asp:GridView>
        </ItemTemplate>
    </asp:TemplateField>
  <asp:TemplateField HeaderText="Address">
      <ItemTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="6" CellSpacing="6" GridLines ="None" DataSource='<%# Bind("address") %>'>
                <HeaderStyle Font-Size="10px" />
                <Columns>        
                     <asp:BoundField DataField="ADDRESSTYPE"  HeaderText="ADDRESSTYPE"/>
                     <asp:BoundField DataField="DOORNO"       HeaderText="DOORNO" />
                     <asp:BoundField DataField="STREET"       HeaderText="STREET" />
                     <asp:BoundField DataField="CITY"         HeaderText="CITY" />
                     <asp:BoundField DataField="DISTRICT"     HeaderText="DISTRICT" />
                     <asp:BoundField DataField="STATE"        HeaderText="STATE" />
                     <asp:BoundField DataField="COUNTRY"      HeaderText="COUNTRY" />
                     <asp:BoundField DataField="PINCODE"      HeaderText="PINCODE" />
                  </Columns>
            </asp:GridView>
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
</asp:GridView>
</asp:Content>
