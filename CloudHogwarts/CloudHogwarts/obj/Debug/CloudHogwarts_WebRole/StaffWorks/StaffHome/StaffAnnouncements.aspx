<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="StaffAnnouncements.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffWorks.StaffHome.StaffAnnouncements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
            onrowcommand="GridView1_RowCommand" Width="542px" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" AllowPaging="True" 
            onpageindexchanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:ButtonField Text="remove" CommandName="remove" />
                <asp:ButtonField Text="view" CommandName="view"/>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </p>
    </asp:Content>
