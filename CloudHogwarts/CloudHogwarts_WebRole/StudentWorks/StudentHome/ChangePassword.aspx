<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        New password<asp:TextBox ID="TextBox1" TextMode = "Password" runat="server" Width="125px" 
            style="margin-left: 60px" ></asp:TextBox>
        <br />
        <br />
        Type password again<asp:TextBox ID="TextBox2" runat="server" Width="125px" 
            style="margin-left: 22px" TextMode="Password"></asp:TextBox>
       
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
       
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Commit" />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="48px" 
            ImageUrl="~/Images/arrow_left_green_48.png" onclick="ImageButton1_Click" 
            style="margin-top: 4px" Width="48px" />
        <br />
    </div>
    </asp:Content>
