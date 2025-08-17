<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="ActivityReport.aspx.cs" Inherits="SwiftHrManagement.web.DailyActivityReport.ActivityReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css" media="print">     
   #hiddenTd { display:none }     
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
<table width="80%" border="0" cellspacing="0" cellpadding="0" align="center">
  
  <tr>
    <td>
     <div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
    </div>
	  <div align="center">				
             <asp:Panel ID="ActivityRecord" runat="server" Visible="true">
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
