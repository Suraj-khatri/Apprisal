<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="ViewAppraisalIndvRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.SupervisorReport.ViewAppraisalIndvRpt" %>

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
					<table border="0" cellspacing="3" width="100%" height="30" cellpadding="0" style="margin-top:20px;" align="center">
                    <tr>
                        <td>
                            <div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
                            </div>                             
                        </td>
                    </tr>
                   
                    <tr>
                       
                        <td>
                            <div align="center">
                                <strong><span class="style10"> Employee Appraisal Report on </span></strong> &nbsp; 
                                <br />                             
                            From Date : <strong><asp:Label ID="lblFromDate"  Text="" runat="server"></asp:Label></strong>  &nbsp;
                                To : <strong><asp:Label ID="lblToDate"  runat="server"></asp:Label></strong>
                            </div>                                    
                        </td>
                                     
                   </tr>
                    <tr><td>&nbsp;</td></tr>
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
