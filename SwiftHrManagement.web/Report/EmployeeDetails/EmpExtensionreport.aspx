<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="EmpExtensionreport.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeDetails.EmpExtensionreport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
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
                             <asp:Label ID="lbldesc"  Text="Employee Extension List" runat="server"></asp:Label></strong></font></div>
                         
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
    </form>
</body>
</html>
</asp:Content>