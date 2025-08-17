<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListForum.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.ListForum" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%@ Page Title="Swift HRM" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ListForum.aspx.cs" Inherits="SwiftHrManagement.web.Project.MessageBoard.ListForum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%">
                        <tr>
                            <td align="left" class="wellcome" valign="bottom">
                                <img src="../../Images/big_bullit.gif" />&nbsp;&nbsp;Discussion Details
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#999999" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                 <div>
                                        <div id="tblResult" runat="server"></div>                               
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
</asp:Content>

