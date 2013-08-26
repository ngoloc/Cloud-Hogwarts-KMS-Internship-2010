<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.StudentProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        #StudentName 
        {
            margin-top:20px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 235px">
    <p id="StudentName">
        <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True" 
            Font-Size="X-Large" ForeColor="#0066CC"></asp:Label>
    </p>
    <h3>Department: <asp:LinkButton ID="LinkButton1" runat="server"
            onclick="LinkButton1_Click"><%=CloudHogwarts_WebRole.Classes.HogwartsDataAccess.GetDepartment(Context.User.Identity.Name).Name%></asp:LinkButton> </h3>
        
    <p><asp:Image ID="Image1" runat="server" Height="48px" 
            ImageUrl="~/Images/CalendarIcon.jpg" Width="48px" />
        <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">View class schedule</asp:LinkButton>
    </p>
    <p><asp:Image ID="Image2" runat="server" Height="48px" 
            ImageUrl="~/Images/icon_media_manuscript.gif" Width="48px" />
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">View transcript</asp:LinkButton>
    </p>
</div>
</asp:Content>
