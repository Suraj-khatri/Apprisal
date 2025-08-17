<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="AppraisalRpt.aspx.cs" Inherits="SwiftHrManagement.web.Report.SupervisorReport.AppraisalRpt"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style10
        {
            color:#666666;           
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
                   <a href="../AppraisalSummary/ViewAppraisal.aspx"
                    <tr>
                        <asp:Panel ID="Report_History" runat="server">  
                        <td>
                            <div align="center">
                                <strong><span class="style10"> Employee Appraisal Report on </span> &nbsp; 
                                From Date :</strong> <asp:Label ID="From_Date"  Text="" runat="server" CssClass="label"></asp:Label>  &nbsp;
                                <strong>To : </strong><asp:Label ID="To_Date"  runat="server" CssClass="label"></asp:Label>
                            </div>                                    
                        </td>
                        </asp:Panel>                       
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
