<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StudentNoneNotice.Master" AutoEventWireup="true" CodeBehind="DepartmentInfo.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.DepartmentInfo" %>
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
<div id = "CourseGeDiv">
<h2 id="title" runat="server"></h2>
<div id="content" runat="server">
</div>
</div>
</asp:Content>

