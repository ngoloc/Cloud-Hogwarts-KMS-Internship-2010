<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="Transcript.aspx.cs" Inherits="CloudHogwarts_WebRole.StudentWorks.StudentHome.Transcript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .GradeClass
        {
            margin-top: 0px;
            margin-bottom: 0px;    
        }
        .TranscriptTableClass
        {
            padding-top:10px;
        }
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
<div id = "CourseGeDiv" style="font-size: small">   
    <h3 align="center" 
        style="margin-left:-20px; width:730px; font-weight: bold; font-size: large; color: #000080;" ><%= (string)Session["StudentName"] %>'s Transcript</h3>
    <h4>choose semester</h4>
    <p>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    </p>
<p><asp:Button ID="Button2" runat="server" Text="View" onclick="Button2_Click" 
        style="height: 26px" /></p>
<%
    if (ViewState["count"] != null)
    {
        int count = (int)ViewState["count"];
        if (count == 0)
        {
    %>
        <div id="NoData" style="font-size: large; color: #FF0000; font-weight: bold;"> 
            NO DATA AVAILABLE</div>
      <%}
        else
        {
            for (int i = 0; i < count; i++)
            {
                GridView1.DataSource = Session[Convert.ToString(i)];
                GridView1.DataBind();
                string index = i.ToString();
                Label1.Text = "Semester Credits: " + (string)ViewState["Semester Credits " + index];
                Label2.Text = "Semester GPA: " + (string)ViewState["Semester GPA " + index];
    %>
        <p class="TranscriptTableClass">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                EnableModelValidation="True">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:GridView>
        </p>
        <p class="GradeClass"><asp:Label ID="Label1" runat="server" Font-Bold="True" 
            ForeColor="Navy"></asp:Label></p>
        <p class="GradeClass"><asp:Label ID="Label2" runat="server" Font-Bold="True" 
            ForeColor="Navy"></asp:Label></p>
          <%}
              if ((bool)ViewState["AllSemester"])
              {
                  Label3.Text = "Total Credits: " + TotalCredits.ToString();
                  Label4.Text = "Total GPA: " + TotalGPA.ToString();
              }
      %>
            <p style="margin-top: 30px"><asp:Label ID="Label3" runat="server" Font-Bold="True" 
            ForeColor="Green" Font-Size="Medium"></asp:Label></p>
            <p style="margin-top: -10px"><asp:Label ID="Label4" runat="server" Font-Bold="True" 
            ForeColor="Green" Font-Size="Medium" ></asp:Label></p>
      <%
        }
    } %>
</div>
</asp:Content>
