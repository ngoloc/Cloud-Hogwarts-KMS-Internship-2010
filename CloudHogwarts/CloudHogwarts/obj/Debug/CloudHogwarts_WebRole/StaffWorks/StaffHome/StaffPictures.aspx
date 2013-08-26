<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Staff.Master" AutoEventWireup="true" CodeBehind="StaffPictures.aspx.cs" Inherits="CloudHogwarts_WebRole.StaffWorks.StaffHome.StaffPictures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hogwarts Blob Storage</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <style type="text/css">
        body { font-family: Verdana; font-size: 12px; }
        h1 { font-size:x-large; font-weight:bold; }
        h2 { font-size:large; font-weight:bold; }

        li { list-style: none;
            height: 30px;
        }
        ul { padding:1em; }
        
        
        .form 
        {   
        	width:58.2em;
            height: 233px;
        }
        .form li span {width:30%; float:left; font-weight:bold; }
        .form li input { width:70%; float:left;
            margin-left: 0px;
        }
        .form input { float:right;
            margin-top: 0px;
        }
        
        #container
        {
              width:758px;
              margin:0 0px 0 auto;
              padding:5px;
              text-align: left;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1><%=ViewState["title"]%>&#39;s Images</h1>
        <div class="form">
        <br/>
        <br/>
            <p class="header"> Name <asp:TextBox ID="imageName" runat="server"  Width="500px"/></p>
            <p class="header"> Description<asp:TextBox ID="imageDescription" runat="server" 
                    Width="500px"/></p>
            <p class="header"> Filename<asp:FileUpload ID="imageFile"  Width="506px" runat="server"/></p>
            <p class="button">
                <asp:Button ID="upload" runat="server" onclick="upload_Click" 
                Text="Upload Image" Width="96px" /></p>
        </div>
        <div style=" float:left;">
        Status: <asp:Label ID="status" runat="server" />
        </div>
        
        <br />
        <br />

        <div id ="container">
            <asp:ListView ID="images" runat="server" onitemdatabound="OnBlobDataBound"  >
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </LayoutTemplate>
                <EmptyDataTemplate>
                    <h2>No Data Available</h2>
                </EmptyDataTemplate>            
                <ItemTemplate>            
                    <div id="inside" style= "height:300px" >
                        <div style="height: 300px; width: 400px; margin-bottom: -300px;">
                            <asp:Repeater ID="blobMetadata" runat="server">
                            <ItemTemplate>
                               <p>
                                    <asp:Label runat="server" Width="90px" Text='<%# Eval("Name") %>' BorderColor="White" BorderStyle="None" BorderWidth="0" Font-Bold="True" ForeColor="#003399" BackColor="White">:&nbsp;&nbsp;</asp:Label>
                                    <asp:TextBox runat="server" Width="250px" Text='<%# Eval("Value") %>' ReadOnly="true"></asp:TextBox>
                               </p>
                            </ItemTemplate>
                            </asp:Repeater>
                                <li>
                                <asp:LinkButton ID="deleteBlob" 
                                        OnClientClick="return confirm('Delete image?');"
                                        CommandName="Delete" 
                                        CommandArgument='<%# Eval("Uri")%>'
                                        runat="server" Text="Delete" Font-Size="Small"  ForeColor="Red" oncommand="OnDeleteImage" />
                                </li>
                        </div>
                        <div style="height: 300px; width: 320px; margin-left: 400px;">
                            <img src="<%# Eval("Uri") %>" alt="<%# Eval("Uri") %>"  height ="240" width ="320" style="float:left;"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
</asp:Content>
