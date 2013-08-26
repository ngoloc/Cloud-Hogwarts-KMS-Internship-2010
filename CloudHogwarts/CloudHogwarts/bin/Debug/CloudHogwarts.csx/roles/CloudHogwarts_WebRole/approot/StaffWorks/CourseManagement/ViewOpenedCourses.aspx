<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="ViewOpenedCourses.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.CourseManagement.ViewOpenedCourses" %>
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
    <h3 align="center" style="margin-left:-20px; width:730px; font-weight: bold;" >opened courses</h3>
    <h4>choose a semester</h4>
    <p>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </p>
    <h4>choose department</h4>
    <p>
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    </p>
    <p><asp:Button ID="Button1" runat="server" Text="View" 
            onclick="Button1_Click" /></p>
    <p><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></p>
    
    <h4 id="CourseGeH" runat="server">courses</h4>
    <asp:GridView ID="GridView1" runat="server" Font-Size="Small" 
        AutoGenerateColumns="False" EnableModelValidation="True" 
        onrowupdating="GidView1_RowUpdating" AllowPaging="True" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="CourseID" />
            <asp:BoundField DataField="Time" HeaderText="Semester" />
            <asp:BoundField DataField="Department" HeaderText="Department" />
            <asp:BoundField DataField="Discipline" HeaderText="Discipline" />
            <asp:BoundField DataField="Teacher" HeaderText="Teacher" />
            <asp:BoundField DataField="AttendeeNumber" HeaderText="Attendee#" />
            <asp:BoundField DataField="MaxCapacity" HeaderText="MaxCapacity" />
            <asp:ButtonField CommandName="update" HeaderText="Grade" Text="Update" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <h4 id="SessionGeH" runat="server">sessions</h4>
    <asp:GridView ID="GridView2" runat="server" Font-Size="Small" 
        AllowPaging="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" EnableModelValidation="True" 
        onpageindexchanging="GridView2_PageIndexChanging">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    </asp:GridView>
</div>
</asp:Content>

