<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/StudentNoneNotice.Master" AutoEventWireup="true" CodeBehind="FullAnnouncements.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.FullAnnouncements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="C#" runat="server">
        void ArticleLinkButtonCommand(Object sender, CommandEventArgs e)
        {
            Session["ArticleID"] = Convert.ToInt32((string)e.CommandArgument);
            Session["FullAnnouncementList"] = true;
            Response.Redirect("./StudentNewsPage.aspx");
        }
   </script>
    <style type="text/css">
        #mainContent
        {
            margin-left: 9px;
            margin-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id = "mainContent">
    <asp:ListView ID="announcement" runat="server" onitemdatabound="OnAnnouncementDataBound" >
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <h2>No Data Available</h2>
                </EmptyDataTemplate>
                <ItemTemplate>
                <%
                    System.Collections.Generic.List<bool> lsb = (System.Collections.Generic.List<bool>)Session["FullBoolList"];
                  if (!lsb[index])
                  {
                      if (index % 2 == 0)
                      {
                      %>
                        <li style="background-color:#CCFFFF"> An announcement <asp:LinkButton    id="ArticleLinkButton"
                                                                Text= '<%# Eval("Title") %>'
                                                                CommandName="Article" 
                                                                CommandArgument='<%# Eval("AnnouncementID") %>'
                                                                OnCommand="ArticleLinkButtonCommand" 
                                                                runat="server"/> 
                            has been released by Prof. <%# Eval("Publisher")%></li>
                     <%}
                      else
                      {%>
                         <li style="background-color:#CCCCCC"> An announcement <asp:LinkButton    id="LinkButton1"
                                                                Text= '<%# Eval("Title") %>'
                                                                CommandName="Article" 
                                                                CommandArgument='<%# Eval("AnnouncementID") %>'
                                                                OnCommand="ArticleLinkButtonCommand" 
                                                                runat="server"/> 
                            has been released by Prof. <%# Eval("Publisher")%></li>
                     <%} %>

               <%
                  }
                  else
                  {
                      if (index % 2 == 0)
                      {%>
                        <li style="background-color:#CCFFFF""> Prof <%# Eval("Publisher")%> <%# Eval("Title") %> your profile modification request </li>
                        <%}
                      else
                      {%>
                        <li style="background-color:#CCCCCC"> Prof <%# Eval("Publisher")%> <%# Eval("Title") %> your profile modification request </li>
                      <%} %>
               <%
                  }
                  index++; %>
                </ItemTemplate>
            </asp:ListView>
    </div>
</asp:Content>

