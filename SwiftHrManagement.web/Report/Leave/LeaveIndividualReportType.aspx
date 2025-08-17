<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveIndividualReportType.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveIndividualReportType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
    <td>
     <div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
    </div>
	  <div align="center">				
	              	
	                 <asp:Panel ID="Leave_details" runat="server" Visible="true">
                                <strong>
                                
                                        <span class="style10"> Leave Detail Report </span> 
                                        <br />
                                        <span class="style10">&nbsp;Branch Name : </span>
                                        <asp:Label ID="lblleaveBranchName" runat="server"></asp:Label>
                                        <br />
                                        <span class="style10">&nbsp;Departmant Name : </span>
                                        <asp:Label ID="lblleaveDeptName" runat="server"></asp:Label>
                                        <br />
                                        <span class="style10"> Employee Name :</span>
                                        <asp:Label ID="lblleaveEmpname"  runat="server"></asp:Label>
                                         <br />
                                           <br />
                                             From Date: 
                                            <asp:Label ID="From_Date1"   runat="server"></asp:Label> To Date: 
                                            <asp:Label ID="To_Date1"  runat="server"></asp:Label> <br />
                     </asp:Panel> 
      </div>                                    
                        
                       
						
	<br />
										 
	</td>
  </tr>
  
  <tr>
    <td>
	
	<div id="rptDiv" runat="server"></div>  
	
	</td>
  </tr>
  
</table>
</asp:Content>
