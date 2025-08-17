<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SwiftHRManager.Master" CodeBehind="GenerateReport.aspx.cs" Inherits="SwiftHrManagement.web.EmployeeMovement.TravelOrder.GenerateReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style10
        {
            color:#666666;           
        }
</style>
<style type="text/css" media="print">     
   #hiddenTd { display:none }     
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
                                     From Date: 
                                    <asp:Label ID="lblFrom"   runat="server"></asp:Label> To Date: 
                                    <asp:Label ID="lblTo"  runat="server"></asp:Label> <br />
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
