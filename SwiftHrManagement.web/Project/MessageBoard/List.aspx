<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.List" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">

<table width="80%" align="center" border="0" cellpadding="0" cellspacing="0">
    <tbody>

      <tr>
        <td colspan="2"><img src="http://localhost:4466/images/transparent.gif" width="1" height="1" /></td>
      </tr>
      <tr>
              
        <td valign="top" style="border:1px solid #8DB0E2;"> 
        
        <iframe src="discussionForum.aspx" name="MainFrame" id="MainFrame" style="width: 800px; height: 500px;" frameborder="0">
        </iframe>
        
        </td>
    </tr> 

    </tbody>
  </table>
</asp:Content>





