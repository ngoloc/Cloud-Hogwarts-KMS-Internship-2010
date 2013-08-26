<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="StaffProfile.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffHome.StaffProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Image ID="Image4" ImageUrl="~/Images/Folder.png" runat="server" />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">View student&#39;s requests</asp:LinkButton>
    </p>
    <p>
        <asp:Image ID="Image3" ImageUrl="~/Images/Picture.png"  runat="server" />
        <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click">Upload pictures</asp:LinkButton>
    </p>
    <p>
        <asp:Image ID="Image2" ImageUrl="~/Images/newspaper_48.png" runat="server" />
        <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">Post an announcement</asp:LinkButton>
    </p>
    <p>
           <asp:Image ID="Image5" ImageUrl="~/Images/table_48.png" runat="server" />            
           <asp:HyperLink ID="HyperLink2" runat="server" 
            NavigateUrl="~/StaffWorks/StaffHome/StaffAnnouncements.aspx">List of announcements</asp:HyperLink>
    </p>
</asp:Content>
