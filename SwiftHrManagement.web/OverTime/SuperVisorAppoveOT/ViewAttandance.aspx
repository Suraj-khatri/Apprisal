<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ViewAttandance.aspx.cs" Inherits="SwiftHrManagement.web.OverTime.SuperVisorAppoveOT.ViewAttandance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
        .style10
        {
            height: 3px;
        }
    </style>
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
					    <table border="0" cellspacing="3" cellpadding="0" style="margin-left:20px; margin-top:20px;" align="center" width="100%">
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
                                <div align="center"><strong> <span class="style10">Daily Attendence Report on</span> </strong> 
                                <asp:Label ID="lblReportDate"  Text="test it " runat="server"></asp:Label> </div>
                                
                             </td>
                           
                             
                         </tr>
                        <tr>
                          <td>
                            <div align="center">                           
                            <table border="0">                                       
                                <tr>                                   
                                    <td>
                                        <div id="rptDiv" runat="server"></div>
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
