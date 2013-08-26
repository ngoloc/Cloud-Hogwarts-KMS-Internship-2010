<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StaffNoneNotice.Master" AutoEventWireup="true" CodeBehind="ComposeAnnouncements.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffHome.ComposeAnnouncements" ValidateRequest ="false" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
    #TitleP
    {
        width:770px;
        margin-bottom:-10px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="TitleP" style="font-weight: bold">Title<asp:TextBox ID="TextBox1" 
            runat="server" style="margin-left: 20px" Width="600px"></asp:TextBox>
    </p>
    <p style="margin-bottom:-10px"><asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label></p>
    <div style="margin-top:30px">
        <FTB:FreeTextBox ID="FreeTextBox1" runat="server" EnableHtmlMode="True" 
            Height="400px" Width="770px" AllowHtmlMode="True" ButtonSet="OfficeXP">
        </FTB:FreeTextBox>
    </div>
     <p>
            <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
     </p>
     <p>
           <asp:Image ID="Image3" ImageUrl="~/Images/Picture.png" AlternateText="Picture Icon" runat="server" />
           <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Upload an image</asp:LinkButton>
     </p>

     </asp:Content>
