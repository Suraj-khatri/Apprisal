<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="WorkHistoryReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeMovements.WorkHistoryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <style type="text/css">

        .style10
        {
            text-align: left;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top">
		<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
		  <tr> 
			<td valign="top">
				<table width="100%" height="30" border="0" cellspacing="0" cellpadding="0">
					<tr>
					  <td valign="top">
					  <table border="0" cellspacing="3" width="100%" height="30" cellpadding="0" style="margin-top:20px;" align="center">
                        <tr>
                          <td height="50">
                            <div align="center">
                                <asp:HiddenField ID="Hdnflag" runat="server" />
                                <strong><font size="+1">
                                <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                               </font></strong>
                               <font size="-1"><strong>
                             <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font></div>
                         
                         </td>
                         </tr>
                        <tr>
                          <td>
                              <div style="text-align:center; margin-top:-5px;">
                               <font size="-1"><strong>
                             <asp:Label ID="lbldesc0"  Text="Employee Work History Report" runat="server"></asp:Label></strong></font>
                              </div>
                         
                         </td>
                         </tr>
                         <tr>
                          <td>
<div align="center">                           
<table border="0">
        <tr>
            <td>
                <asp:Table ID="tblMain" runat="server" CellPadding="0" CellSpacing="0">
                </asp:Table>
            </td>
        </tr>     
        <tr>
            <td>
                <div id="rptDiv" runat="server">
                </div>
            </td>
        </tr>
</table>
</div>
                        </td>
                        </tr>
                      </table>
				      </td>
					</tr>
				</table>
			</td>
		  </tr>
	</table>	
	</td>
  </tr>
</table>
</asp:Content>
