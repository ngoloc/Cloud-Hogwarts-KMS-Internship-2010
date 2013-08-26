<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="RegisterCourses.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.CourseRegistration.RegisterCourses" %>
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
    <h3 align="center" style="margin-left:-20px; width:730px; font-weight: bold;" >register courses</h3>
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
    <p>
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Images/arrow_right_green_48.png" 
            onclick="ImageButton1_Click" />
    </p>
</div>
    
</asp:Content>

