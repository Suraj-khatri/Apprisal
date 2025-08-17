<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="TDSReportForBranchWise.aspx.cs" Inherits="SwiftHrManagement.web.Report.PayRollReport.TaxReport.TDSReportForBranchWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style10
        {
            color:#666666;           
        }
        .style11
        {
            height: 181px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  
  <tr>
    <td class="style11">
     <div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
    </div>
	  <div align="center">				
	         
	                 <asp:Panel ID="Tax" runat="server" Visible="true">
                                <strong>
                                
                                        <span class="style10"> TDS Detail Report </span> 
                                         <br />
                                        <span class="style10">&nbsp;Fiscal Year : </span>
                                        <asp:Label ID="lblYear" runat="server"></asp:Label>
                                        <br />
                                        <span class="style10">&nbsp;Branch Name : </span>
                                        <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                                        <br />
                                        <span class="style10">&nbsp;Departmant Name : </span>
                                        <asp:Label ID="lbldeptName" runat="server"></asp:Label>
                                        <br />
                                       <%-- <span class="style10"> Employee Name :</span>
                                        <asp:Label ID="lblEmpName"  runat="server"></asp:Label>
                                         <br />--%>
                                        
                                            <%-- From Date: 
                                            <asp:Label ID="From_Date"   runat="server"></asp:Label> To Date: 
                                            <asp:Label ID="To_Date"  runat="server"></asp:Label> <br />--%>
                                            </strong>
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
