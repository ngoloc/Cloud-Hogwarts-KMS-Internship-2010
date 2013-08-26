<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.StudentEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 437px">
        <br />
        First Name<asp:TextBox ID="TextBox1" runat="server" Width="190px" 
            style="margin-left: 95px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Last name<asp:TextBox ID="TextBox2" runat="server" Width="190px" 
            style="margin-left: 98px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Nationality<asp:TextBox ID="TextBox3" runat="server" Width="190px" 
            style="margin-left: 95px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        Magical Mail Address<asp:TextBox ID="TextBox4" runat="server" Width="190px" 
            style="margin-left: 29px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        House of Student<asp:DropDownList 
            ID="DropDownList1" runat="server" 
            Height="25px" Width="190px" style="margin-left: 56px">
        </asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Commit" />
        </p>
        <p>
            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Change password</asp:LinkButton>
        </p>
        <p>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="48px" 
            ImageUrl="~/Images/arrow_left_green_48.png" onclick="ImageButton1_Click" 
            style="margin-top: 4px" Width="48px" />
        </p>
    </div>
</asp:Content>
