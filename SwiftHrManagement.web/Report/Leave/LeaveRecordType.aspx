<%@ Page Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="LeaveRecordType.aspx.cs" Inherits="SwiftHrManagement.web.Report.Leave.LeaveRecordType"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
  <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left:20px;">
  <tr>
    <td>  
	<div align="center"><strong><font size="+1">
                                    <asp:Label ID="lblHeading" Text= "myHeading" runat="server"></asp:Label><br />
                                   </font></strong>
                                   <font size="-1"><strong>
                                 <asp:Label ID="lbldesc"  Text="test it " runat="server"></asp:Label></strong></font>
    </div> 
							
	<div align="center">
                                        <strong><span class="style10">&nbsp;Branch : 
                                        <asp:Label ID="lblbranch" runat="server"></asp:Label>
                                        </span><br />
                                         <strong><span class="style10">&nbsp;Departmant : 
                                        <asp:Label ID="lbldepartmant" runat="server"></asp:Label>
                                        </span><br />
                                        <span class="style10"> Employee Name :
                                       	 <asp:Label ID="lblEmployeeName"  runat="server"></asp:Label>
                                        </span> <br />
                                        <asp:Label ID="Lbldatetype" runat="server"></asp:Label> Requested From Date: <asp:Label ID="DateFrom"   runat="server">
										</asp:Label>  To Date: 
                                         <asp:Label ID="DateTo"  runat="server"></asp:Label>
                                         
                                         </div><br />
		</td>
  </tr>
  <tr>
    <td> <div id="rptDiv" runat="server"></div>  </td>
  </tr>
</table>

    
</asp:Content>