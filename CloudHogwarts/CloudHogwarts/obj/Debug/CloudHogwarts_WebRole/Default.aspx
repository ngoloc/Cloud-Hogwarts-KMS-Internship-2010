<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CloudHogwarts_WebRole.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .first
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border: thin inset #808080; width: 250px; margin-left: 450px; padding-bottom: 20px; margin-top: 30px; margin-bottom: 16px;" 
        align="center">
        <h3 align="center" style="font-weight: bold; width: 252px; margin-top: 10px;">SIGN 
            IN TO HOGWARTS</h3>
        <p class="first" id="error" visible="false" runat="server" 
            style="font-size: small; color: #FF0000"> Invalid user name or password. Please try again!</p>
        <p class="first" align="left">Username</p>
                    <asp:TextBox ID="UsernameTextBox" runat="server" 
                 Width="200px"></asp:TextBox>
        <p class="first" align="left">Password</p>
                    <asp:TextBox ID="PasswordTextBox" runat="server" 
                Width="200px" TextMode="Password"></asp:TextBox>
        
        <br />
        <asp:Button ID="Button2" runat="server" Text="Sign In" 
            style="height: 25px; margin-top: 15px;" 
            onclick="Button1_Click" />
    </div>
    
</asp:Content>
