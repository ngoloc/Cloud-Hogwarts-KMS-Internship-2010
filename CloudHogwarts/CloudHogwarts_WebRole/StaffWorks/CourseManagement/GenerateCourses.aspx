<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="GenerateCourses.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.CourseManagement.GenerateCourses" %>
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
    <div id = "CourseGeDiv" style="font-size: small" >   
    <h3 align="center" style="margin-left:-20px; width:730px; font-weight: bold;" >auto course generation</h3>
    <h4>choose a semester</h4>
    <p>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </p>
    <h4>choose department</h4>
    <p>
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ChangeDept">
    </asp:DropDownList>
    </p>
    <h4>choose discipline</h4>
    <p>
    <asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList>
    </p>
    <h4>course number</h4>
    <asp:RadioButtonList ID="RadioButtonList1"
            runat="server" Width="42px">
        <asp:ListItem Selected="True">1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        </asp:RadioButtonList>
    <h4>choose teacher</h4>
    <p>
    <asp:DropDownList ID="DropDownList4" runat="server">
    </asp:DropDownList>
    </p>
    <p><asp:Button ID="Button1" runat="server" Text="Generate Course" 
            onclick="Button1_Click" /></p>
    <p><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></p>
    
    <h4 id="CourseGeH" runat="server">new generated courses</h4>
    <asp:GridView ID="GridView1" runat="server" Font-Size="Small" 
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
    <h4 id="SessionGeH" runat="server">new generated sessions</h4>
    <asp:GridView ID="GridView2" runat="server" Font-Size="Small" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" EnableModelValidation="True">
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
    </asp:GridView>
<p><asp:Button ID="Button2" runat="server" Text="Commit" onclick="Button2_Click" /></p>
</div>
</asp:Content>
