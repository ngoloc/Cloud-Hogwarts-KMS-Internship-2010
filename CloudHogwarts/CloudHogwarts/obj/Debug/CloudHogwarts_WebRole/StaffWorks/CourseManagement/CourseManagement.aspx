<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="CourseManagement.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.CourseManagement.CourseManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/table_48.png" 
        Height="48px" Width="48px" />&nbsp; <asp:LinkButton ID="LinkButton1"  
        runat="server" onclick="LinkButton1_Click">View opened courses</asp:LinkButton></p>
        <p>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/app_48.png" 
        Height="48px" Width="48px" />&nbsp; <asp:LinkButton ID="LinkButton2"  
            runat="server" onclick="LinkButton2_Click">Generate new courses</asp:LinkButton></p>
</asp:Content>

