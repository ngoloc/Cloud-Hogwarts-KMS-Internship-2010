<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.StudentInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        #StudentName 
        {
            margin-top:20px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p id="StudentName">
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="True" 
                Font-Size="X-Large" ForeColor="#0066CC"></asp:Label>
        </p>
        <p>
        Nationality:
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
        Magical Email Address:
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
        House of student:
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
        Username:
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Edit your profile</asp:LinkButton>
        </p>
    </div>
</asp:Content>
