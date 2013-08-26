<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="ProcessStudentRequests.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffHome.ProcessStudentRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        #CourseGeDiv 
        {
          width:690px;
          border: medium ridge #800000; 
          padding-left:20px;
          padding-right:20px;
          padding-bottom:30px;
          margin-left:20px; 
          margin-top:30px;
          margin-right: 30px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id = "CourseGeDiv" style="font-size: small" >
    <h3 align="center" style="margin-left:-20px; width:730px; font-weight: bold;" >
        student requests</h3>
    <h4>student id</h4>
    <p>
    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px">
    </asp:DropDownList>
    </p>
    <p><asp:Button ID="Button1" runat="server" Text="View" 
            onclick="Button1_Click" Height="26px" />
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
            BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CellSpacing="2" EnableModelValidation="True">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="GridView2" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            EnableModelValidation="True">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>
    </p>
    <p align="center">
        <asp:Button ID="Button2" runat="server"
            Text="Approve" onclick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" OnClientClick="return confirm('Are you sure you want to reject?');" onclick="Button3_Click" 
            Text="Reject" />
    </p>
</div>
</asp:Content>
