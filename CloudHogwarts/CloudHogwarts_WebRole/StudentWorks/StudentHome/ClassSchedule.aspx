<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="ClassSchedule.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.ClassSchedule" %>
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
<div id = "CourseGeDiv" style="font-size: small">   
    <h3 align="center" 
        style="margin-left:-20px; width:730px; font-weight: bold; font-size: large; color: #000080;" ><%= (string)Session["StudentName"] %>'s 
        class schedule</h3>
    <h4>choose semester</h4>
    <p>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </p>
<p><asp:Button ID="Button2" runat="server" Text="View" onclick="Button2_Click" /></p>
    <p style="padding-top: 15px"><asp:Label ID="Label1" runat="server"  style="color: #FF0000;" Font-Bold="True" 
            Font-Size="Large"></asp:Label></p>
    <p>
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" BorderColor="Red" ForeColor="#000066" 
                HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" 
            Font-Size="Medium" ForeColor="Navy"></asp:Label>
    </p>
</div>
</asp:Content>
