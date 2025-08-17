<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discussionForum.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.discussionForum" %>--%>
<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="discussionForum.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.discussionForum" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" widht="100%">
                                 <div>
                                        <div id="tblResult" runat="server"></div>                               
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
</asp:Content>

