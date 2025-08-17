<%@ Page Title="" Language="C#" MasterPageFile="~/SwiftHRManager.Master" AutoEventWireup="true" CodeBehind="WorkHistory.aspx.cs" Inherits="SwiftHrManagement.web.Report.EmployeeMovements.WorkHistory" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
						<td valign="bottom" class="wellcome">
						<img src="/images/spacer.gif" width="5" height="1">
						<img src="/images/big_bullit.gif">&nbsp;&nbsp;Employee Work History</td>
					</tr>
					<tr>
						<td valign="top" bgcolor="#999999" height="1"><img src="/images/spacer.gif" width="100%" height="1"></td>
					</tr>
				</table>
				<table width="60%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td valign="top" align="center"><br>

						<!--		Begin content	-->

<!--START FORM STYLE-->
 <table class="container" border="0" cellpadding="0" cellspacing="0" width="30%">
  <tbody><tr>
    <td width="1%" class="container_tl"><div></div></td>
    <td width="91%" class="container_tmid"><div class="nowarp">Employee Work History</div></td>
    <td width="8%" class="container_tr"><div></div></td>
  </tr>
      <tr>
        <td class="container_l"></td>
        <td class="container_content">
        
<!--END FORM STYLE-->   


    <table border="0" cellspacing="5" cellpadding="5" class="container">
        <tr>
             <td><div align="right" class="text_form1">Employee Name :</div></td>
             <td>
                <asp:DropDownList ID="DdlEmpName" runat="server" CssClass="CMBDesign" Width="300px">
                </asp:DropDownList>         
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td "nowarp" ><asp:Button ID="BtnViewRpt"   runat="server" CssClass="button" onclick="BtnViewRpt_Click" Text=" Show Report "  /></td>
        </tr>
    </table>
  
<!--START FORM STYLE-->
	</td>
    <td class="container_r"></td>
  </tr>
  <tr>
    <td class="container_bl"></td>
    <td class="container_bmid"></td>
    <td class="container_br"></td>
  </tr>
	</tbody>
  </table>

<!--END FORM STYLE-->
				
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
