<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="InputGrade.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.CourseManagement.InputGrade" %>
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
    <h3 align="center" style="margin-left:-20px; width:730px; font-weight: bold;" >input 
        grade</h3>
    <h4 id="SemH" runat="server"></h4>
    <h4 id="DeptH" runat="server"></h4>
    <h4 id="CourseH" runat="server"></h4>
    <h4 id="InstructorH" runat="server"></h4>
    <p><asp:Label ID="Label1" runat="server" 
            ForeColor="Red"></asp:Label></p>
    <asp:GridView ID="GridView1" runat="server" Font-Size="Small" 
        AutoGenerateColumns="False" EnableModelValidation="True" CellPadding="4" 
        ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="StudentID" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:TemplateField HeaderText="Grade">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>N/A</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>C+</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    </asp:GridView>
    <p><asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" /></p>
    
    <p><asp:ImageButton ID="ImageButton1" runat="server" Height="48px" 
            ImageUrl="~/Images/arrow_left_green_48.png" onclick="ImageButton1_Click" 
            style="margin-top: 4px" Width="48px" /></p>
</div>
</asp:Content>

