<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReport.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.Report.ViewReport" %>
<%@ Import Namespace="SwiftHrManagement.web.Library" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%
        if (GetStatic.ReadQueryString("mode", "") == "")
        {
    %>
    <script src="../../js/functions.js" type="text/javascript"> </script>
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />
    <% }%>

 <style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
     <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left:20px;">
  <tr>
    <td>  
	<div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
    </div> 
							
	<div align="center">
                                        <strong><span class="style10">&nbsp;Branch : 
                                        <asp:Label ID="lblbranch" runat="server"></asp:Label>
                                        </span><br />
                                         <strong><span class="style10">&nbsp;Departmant : 
                                        <asp:Label ID="lbldepartmant" runat="server"></asp:Label>
                                        </span><br />
                                        <span class="style10"> Employee Name :
                                       	 <asp:Label ID="lblEmployeeName"  runat="server"></asp:Label>
                                        </span> <br />
                                        <asp:Label ID="Lbldatetype" runat="server"></asp:Label> Requested From Date: <asp:Label ID="DateFrom"   runat="server">
										</asp:Label>  To Date: 
                                         <asp:Label ID="DateTo"  runat="server"></asp:Label>
                                         
                                         </div><br />
                                         <div id="exportDiv" runat="server" class="noprint" style="padding-top: 10px">
                <div style="float: left; margin-left: 10px; vertical-align: top">
                    <img alt="Print" border="0" onclick=" javascript:PrintWindow(); " src="../../images/printer.png"
                        style="cursor: pointer; width: 14px; height: 14px" title="Print" />
                </div>
                <div id="export" runat="server" style="float: left; margin-left: 10px; vertical-align: top">
                    <img alt="Export to Excel" border="0" onclick=" javascript:downloadInNewWindow('<% =Request.Url.AbsoluteUri + "&mode=download"%>');"
                        src="../../images/excel.gif" style="cursor: pointer" title="Export to Excel" />
                </div>
            </div>
		</td>
  </tr>
  <tr>
    <td><div id="rptDiv" runat="server"><font size="+2"> </font> </div> </td>
  </tr>
</table>
</asp:Content>
