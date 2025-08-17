<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveSummaryRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveSummaryRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
							
	<div align="center"><b>
                                        
                                        Leave Year: <asp:Label ID="lblYear"  runat="server" CssClass="txtlbl"></asp:Label></b>
                                        
                                         </div><br />
		</td>
  </tr>
  <tr>
    <td> <div id="rptDiv" runat="server"></div>  </td>
  </tr>
</table>
</asp:Content>
