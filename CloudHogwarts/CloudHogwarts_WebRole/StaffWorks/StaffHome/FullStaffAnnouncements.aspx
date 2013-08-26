<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="FullStaffAnnouncements.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffHome.FullStaffAnnouncements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    #mainContent
    {
        margin-left: 10px;
        margin-right: 6px;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContent">
    
<asp:ListView ID="announcement" runat="server">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <h2>No Data Available</h2>
                </EmptyDataTemplate>
                <ItemTemplate>
                <% 
                    if (index % 2 == 0)
                    {
                %>
                        <li style="background-color:#CCFFFF"> <%# Eval("text")%></li>
                <%  }
                    else
                    {  %>
                        <li style="background-color:#CCCCCC"> <%# Eval("text")%></li>
                <%  }
                    index++; %>
                </ItemTemplate>
            </asp:ListView>
  </div>
</asp:Content>
