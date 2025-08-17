<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewEmpDetlReport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.ViewEmpDetlReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
					 <table border="0" cellspacing="3" width="100%" height="30" cellpadding="0" style="margin-left:0px; margin-top:20px;" align="center">
                        <tr>
                          <td height="50">
                            <div align="center"><strong><font size="+1">
                                <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                               </font></strong>
                               <font size="-1"><strong>
                             <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font></div>
                         
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
